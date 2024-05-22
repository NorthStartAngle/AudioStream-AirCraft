using Microsoft.Win32.SafeHandles;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Timers;


namespace AudioStream.Modules
{
    public class PlayEvent : EventArgs
    {
        public FileType playedType;
    }
    public class CusomAudioStream
    {
        LocalAudio? _local;
        StreamAudio? _stream;
        System.Timers.Timer? aTimer;
        public int beforePos;

        public event EventHandler<PlayEvent>? PlayDone;
        public event EventHandler<EventArgs>? PlayingNow;

        struct PlayParam
        {
            public bool islocal;
            public string filePath;
            public int delay;
            public float volumn;
            public bool ispause;
        }
        PlayParam play_param;

        public CusomAudioStream()
        {
            _local = new LocalAudio();
            _stream = new StreamAudio();
            PlayDone = null;
            beforePos = -1;
            _local.playdoneDelegate += OnPlayedDone;
            _stream.playdoneDelegate += OnPlayedDone;

            aTimer = null;
        }

        public void Play(bool isLocal,string filePath, int delay = 0,float volumn = 0.5f,bool isPause = false)
        {
            play_param.islocal = isLocal;
            play_param.filePath = filePath;
            play_param.delay = delay;
            play_param.volumn = volumn;
            play_param.ispause = isPause;
            
            PlayingNow?.Invoke(null, new EventArgs());

            Stop();

            if (aTimer != null)
            {
                aTimer.Stop();aTimer.Dispose();
                
            }
            if(delay == 0)
            {
                OnTimedEvent(aTimer, null);
                return;
            }
            aTimer = new System.Timers.Timer();
            aTimer.Elapsed += OnTimedEvent;
            if(delay >0) aTimer.Interval = delay * 1000;
            aTimer.Start();
        }

        void OnTimedEvent(Object? source, ElapsedEventArgs? e)
        {
            aTimer?.Stop(); aTimer?.Dispose();

            //Stop();

            if (play_param.islocal)
                _local?.Play(play_param.filePath, play_param.volumn, play_param.ispause);
            else
                _stream?.Play(play_param.filePath, play_param.volumn, play_param.ispause);
        }

        public void StopBySim()
        {
            _stream?.Stop(false);
        }

        public void Stop(bool _isdispatch = false)
        {
            _local?.Stop(_isdispatch); _stream?.Stop(_isdispatch);
        }

        public void Pause()
        {
            if(_local != null)
            {
                if (_local.State() == PlaybackState.Playing)
                {
                    _local.Pause();
                }
            }
            
            if(_stream != null)
            {
                if (_stream.State() == PlaybackState.Playing)
                {
                    _stream.Pause();
                }
            }            
        }

        public NAudio.Wave.PlaybackState State()
        {
            NAudio.Wave.PlaybackState s1 = _local.State();
            NAudio.Wave.PlaybackState s2 = _stream.State();

            if (s1 == PlaybackState.Playing || s2 == PlaybackState.Playing) return PlaybackState.Playing;
            if (s1 ==PlaybackState.Paused || s2 == PlaybackState.Paused) return PlaybackState.Paused;
            return NAudio.Wave.PlaybackState.Stopped;
        }

        public void Resume()
        {
            if (_local != null)
            {
                if (_local.State() == PlaybackState.Paused)
                {
                    _local.Resume();
                }
            }

            if (_stream != null)
            {
                if (_stream.State() == PlaybackState.Paused)
                {
                    _stream.Resume();
                }
            }
        }

        public void SetDevice(int index)
        {
            _local?.SetDevice(index);
            _stream?.SetDevice(index);
        }

        public void SetVolumn(float volumn)
        {
            _local?.SetVolume(volumn);_stream?.SetVolume(volumn);
        }

        void OnPlayedDone(object? sender,PlayEvent e)
        {
            PlayDone?.Invoke(null, e);
        }

        ~CusomAudioStream()
        {
            _local?.Dispose();
            _stream?.Dispose();
            aTimer.Dispose();
        }

        public static List<string> GetOutputDevices()
        {
            List<string> devices = new List<string>();
            var objSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_SoundDevice");

            var objCollection = objSearcher.Get();
            foreach (var d in objCollection)
            {
                foreach (var p in d.Properties)
                {
                    if (p.Name == "Caption")
                    {
                        string a = $"{p.Value}";
                        if (!devices.Contains(a)) devices.Add($"{p.Value}");
                    }
                }
            }

            return devices;
        }
    }

    class LocalAudio : IDisposable
    {
        IWavePlayer? wavePlayer;
        AudioFileReader? audioFileReader;
        int _device = 0;
        private bool _disposedValue;
        private SafeHandle? _safeHandle = new SafeFileHandle(IntPtr.Zero, true);
        string _filepath ="";
        public event EventHandler<PlayEvent>? playdoneDelegate;
        bool _repeated = false;
        bool isDispatch = false;

        public LocalAudio()
        {
            playdoneDelegate = null;
        }

        ~LocalAudio()
        {
            CleanUp();
        }

        public NAudio.Wave.PlaybackState State()
        {
            if (wavePlayer == null) return NAudio.Wave.PlaybackState.Stopped;
            return wavePlayer.PlaybackState;
        }

        public void SetDevice(int deviceNumber)
        {
            _device = deviceNumber;
        }

        public void Play(string filePath,float volume = 0.5f,bool isPaused = false,bool repeated = false,bool _isdispatch = true)
        {
            try
            {
                wavePlayer = CreateWavePlayer();
                audioFileReader = new AudioFileReader(filePath);
                audioFileReader.Volume = volume;
                wavePlayer.Init(audioFileReader);
                wavePlayer.PlaybackStopped += OnPlaybackStopped;
                wavePlayer.Play();
                _repeated = repeated;
                _filepath = filePath;
                isDispatch = _isdispatch;
                if (isPaused)
                {
                    Pause();
                }
            }
            catch(Exception)
            {
                playdoneDelegate?.Invoke(this, new PlayEvent() { playedType = FileType.File });
                CleanUp();
            }            
        }

        public IWavePlayer CreateWavePlayer()
        {
            return new WaveOut() { DeviceNumber = _device };
        }

        public void Stop(bool _isdispath = false)
        {
            wavePlayer?.Stop();
            isDispatch = _isdispath;
        }

        public void Pause()
        {
            if (wavePlayer?.PlaybackState == PlaybackState.Playing)
            {
                wavePlayer.Pause();
            }
        }

        public void Rewind()
        {
            if(audioFileReader != null) audioFileReader.Position = 0;
        }

        public void Resume()
        {
            if (wavePlayer?.PlaybackState == PlaybackState.Paused)
            {
                wavePlayer.Play();
            }
        }

        public void SetVolume(float volume)
        {
            if (audioFileReader != null)  audioFileReader.Volume = volume;
        }

        //-----------------------------
        void OnPlaybackStopped(object? sender, NAudio.Wave.StoppedEventArgs e)
        {            
            if(_repeated)
            {
                audioFileReader.Position = 0;
                wavePlayer.Init(audioFileReader);
                wavePlayer.Play();
                return;
            }

            if(isDispatch) playdoneDelegate?.Invoke(null, new PlayEvent() { playedType = FileType.File });

            CleanUp();
            if (e.Exception != null)
            {
                //
            }
        }

        public void CleanUp()
        {
            if (audioFileReader != null)
            {
                audioFileReader.Dispose();
                audioFileReader = null;
            }
            if (wavePlayer != null)
            {
                wavePlayer.Dispose();
                wavePlayer = null;
            }
        }

        public void Dispose()
        {
            CleanUp();
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _safeHandle?.Dispose();
                    _safeHandle = null;
                }

                _disposedValue = true;
            }
        }
    }

    class StreamAudio : IDisposable
    {
        System.Timers.Timer aTimer;
        MediaFoundationReader? mf;
        IWavePlayer? wavePlayer;
        int _device = 0;
        string _filepath = "";
        private bool _disposedValue;
        private SafeHandle? _safeHandle = new SafeFileHandle(IntPtr.Zero, true);
        public event EventHandler<PlayEvent>? playdoneDelegate;
        bool _repeated = false;
        bool isDispatch = false;
        Task? playTask;

        public StreamAudio()
        {
            aTimer = new System.Timers.Timer(200);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            aTimer.Stop();
            playdoneDelegate = null;

            playTask = null;
        }

        ~StreamAudio()
        {
            playTask?.Dispose();
            CleanUp();
        }

        void OnTimedEvent(Object? source, ElapsedEventArgs e)
        {
            
        }

        public PlaybackState State()
        {
            if (wavePlayer == null) return PlaybackState.Stopped;
            return wavePlayer.PlaybackState;
        }

        public void SetDevice(int deviceNumber)
        {
            _device = deviceNumber;
        }


        public void Play(string fileUrl, float volume = 0.5f,bool isPaused = false,bool repeated = false, bool _isdispatch = true)
        {
            playTask = Task.Run(() =>
            {
                wavePlayer = CreateWavePlayer();

                try
                {
                    mf = new MediaFoundationReader(fileUrl);
                    wavePlayer.Init(mf);
                    wavePlayer.PlaybackStopped += OnPlaybackStopped;
                    wavePlayer.Volume = volume;
                    wavePlayer.Play();
                    _filepath = fileUrl;
                    _repeated = repeated;
                    isDispatch = _isdispatch;
                    if (isPaused)
                    {
                        Pause();
                    }
                }
                catch (Exception)
                {
                    playdoneDelegate?.Invoke(this, new PlayEvent() { playedType = FileType.Url });
                    CleanUp();
                }
            });            
        }

        IWavePlayer CreateWavePlayer()
        {
            return new WaveOut() { DeviceNumber = _device };
        }

        public async void Stop(bool _dispatch = false)
        {
            isDispatch = _dispatch;
            wavePlayer?.Stop();
            
        }

        public void Pause()
        {
            if (wavePlayer?.PlaybackState == PlaybackState.Playing)
            {
                wavePlayer.Pause();
            }
        }

        public void Resume()
        {
            if (wavePlayer?.PlaybackState == PlaybackState.Paused)
            {
                wavePlayer.Play();
            }
        }

        public void SetVolume(float volume)
        {
            if (wavePlayer != null) wavePlayer.Volume = volume;
        }

        //-----------------------------
        async void OnPlaybackStopped(object? sender, NAudio.Wave.StoppedEventArgs e)
        {
            if (playTask != null && !playTask.IsCompleted) await playTask;
            playTask?.Dispose();

            if (_repeated)
            {
                mf.Position = 0;
                wavePlayer?.Init(mf);
                wavePlayer?.Play(); return;
            }
            if(isDispatch) playdoneDelegate?.Invoke(this, new PlayEvent() { playedType = FileType.Url });
            CleanUp();
            if (e.Exception != null)
            {
                //
            }
        }

        public void CleanUp()
        {
            if (mf != null)
            {
                mf.Dispose();
                mf = null;
            }
            if (wavePlayer != null)
            {
                wavePlayer.Dispose();
                wavePlayer = null;
            }
        }

        public void Dispose()
        {
            CleanUp();
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _safeHandle?.Dispose();
                    _safeHandle = null;
                }

                _disposedValue = true;
            }
        }
    }
}
