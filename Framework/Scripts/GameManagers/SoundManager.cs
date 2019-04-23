using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SoundChannel
{
    FX,music, ambient, speech
}
public class SoundManager : MonoBehaviour
{
    AudioSource fxAudioSource;
    AudioSource musicAudioSource;
    AudioSource ambientAudioSource;
    AudioSource speechAudioSource;
    [Header("Most common audios")]
    public AudioClip click;


    private void Awake()
    {
        InitAudioSources();
    }
    /// <summary>
    /// Plays clip from loaded clips depend on its purpose.Default - FX
    /// </summary>
    /// <param name="clip">name of the clip in this SoundManager inspector</param>
    /// <param name="channel"></param>
    public void Play(string clip, SoundChannel channel = SoundChannel.FX)
    {
        AudioClip audioClip = (AudioClip) this.GetType().GetField(clip).GetValue(this);
        

        if (audioClip != null)
        {
            Play(audioClip, channel);

        }
        else
        {
            Debug.Log("no file");
        }
    }
    /// <summary>
    /// Directly plays clip on certain channel
    /// </summary>
    /// <param name="audioClip"></param>
    /// <param name="channel"></param>
    public void Play(AudioClip audioClip, SoundChannel channel)
    {
        if (channel == SoundChannel.FX)
        {
            fxAudioSource.loop = false;
            fxAudioSource.PlayOneShot(audioClip);
        }
        else if (channel == SoundChannel.music)
        {
            musicAudioSource.loop = true;
            musicAudioSource.clip = audioClip;
            musicAudioSource.Play();
        }
        else if (channel == SoundChannel.ambient)
        {
            ambientAudioSource.loop = true;
            ambientAudioSource.clip = audioClip;
            musicAudioSource.Play();
        }
        else if (channel == SoundChannel.speech)
        {
            speechAudioSource.loop = false;
            speechAudioSource.Stop();
            speechAudioSource.clip = audioClip;
            fxAudioSource.Play();
        }
        
    }
    
    #region extracted methods


    private void InitAudioSources()
    {
        if (fxAudioSource == null)
        {
            GameObject fx = new GameObject("fx");
            fx.transform.parent = transform;
            fxAudioSource = fx.AddComponent<AudioSource>();
        }
        if (musicAudioSource == null)
        {
            GameObject music = new GameObject("music");
            music.transform.parent = transform;
            musicAudioSource = music.AddComponent<AudioSource>();
        }
        if (ambientAudioSource == null)
        {
            GameObject ambient = new GameObject("ambient");
            ambient.transform.parent = transform;
            ambientAudioSource = ambient.AddComponent<AudioSource>();
        }
        if (speechAudioSource == null)
        {
            GameObject speech = new GameObject("speech");
            speech.transform.parent = transform;
            speechAudioSource = speech.AddComponent<AudioSource>();
        }
    }
    #endregion


}
