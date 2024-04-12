using Etermium.Entity;
using NAudio.Wave;

namespace Etermium.Mechanic;

public abstract class MusicPlayer
{
    private static WaveOutEvent? _outputDevice;
    private static AudioFileReader? _audioFile;
    private static Thread _t = null!;

    [Obsolete("Obsolete")]
    public static void Play(string filename, Enemy enemy)
    {
        if (enemy.BossEnd)
            PlayOnce(filename, enemy);
        else
            PlayLoop(filename);
    }

    [Obsolete("Obsolete")]
    public static void PlayOnce(string filename, Enemy enemy)
    {
        if (_t.IsAlive) _t.Abort(); // _t != null && 

        if (_outputDevice != null)
        {
            _outputDevice.Stop();
            _outputDevice.Dispose();
            _outputDevice = null;
        }

        _audioFile = new AudioFileReader(filename);
        _outputDevice = new WaveOutEvent();
        _outputDevice.Init(_audioFile);
        _outputDevice.Play();
    }

    public static void PlayLoop(string filename)
    {
        _t = new Thread(o =>
            {
                while (true)
                {
                    if (_outputDevice != null)
                    {
                        _outputDevice.Stop();
                        _outputDevice.Dispose();
                        _outputDevice = null;
                    }

                    _audioFile = new AudioFileReader(filename);
                    _outputDevice = new WaveOutEvent();
                    _outputDevice.Init(_audioFile);
                    _outputDevice.Play();
                    Thread.Sleep(174000);
                }
            }
        );
        _t.Start();
    }

    public static void Stop()
    {
        if (_outputDevice != null)
        {
            _outputDevice.Stop();
            _outputDevice.Dispose();
            _outputDevice = null;
        }

        _audioFile!.Dispose();
        _audioFile = null;
    }
}