using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public enum Sound
    {
        Player_Jump,
        Player_Grapple,
        Player_Collect_Star,
        Player_Death,
        World_1_Music,
        World_2_Music,
        World_3_Music,
        Level_Finish
    }
    public static void PlaySound(Sound sound)
    {
        GameObject soundGameObj = new GameObject("Sound");
        AudioSource audio = soundGameObj.AddComponent<AudioSource>();
        audio.PlayOneShot(GetAudioClip(sound));
    }

    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach (Sounds.SoundAudioClip soundAudioClip in Sounds.i.soundAudioClipArray)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }
        return null;
    }
}
