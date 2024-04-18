using Etermium.Entits;
using NAudio.Wave;
using System;
using System.Threading;

namespace Etermium.Mechanic;

/// <summary>
/// Class responsible for playing background music.
/// </summary>
public abstract class MusicPlayer
{
    private static WaveOutEvent? _outputDevice;
    private static AudioFileReader? _audioFile;
    private static Thread _t = null!;

    /// <summary>
    /// Plays the specified audio file once or in a loop based on whether the enemy is a boss.
    /// </summary>
    /// <param name="filename">The path to the audio file.</param>
    /// <param name="enemy">The enemy entity.</param>
    [Obsolete("Obsolete")]
    public static void Play(string filename, Enemy enemy)
    {
        if (enemy.BossEnd)
        {
            PlayOnce(filename, enemy);
        }
        else
        {
            PlayLoop(filename);
        }
    }

    /// <summary>
    /// Plays the specified audio file once.
    /// </summary>
    /// <param name="filename">The path to the audio file.</param>
    /// <param name="enemy">The enemy entity.</param>
    [Obsolete("Obsolete")]
    public static void PlayOnce(string filename, Enemy enemy)
    {
        if (_t.IsAlive) // _t != null && 
        {
            _t.Abort();
        }

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

    /// <summary>
    /// Plays the specified audio file in a loop.
    /// </summary>
    /// <param name="filename">The path to the audio file.</param>
    private static void PlayLoop(string filename)
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

    /// <summary>
    /// Stops the currently playing audio.
    /// </summary>
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