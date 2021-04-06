using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public static SfxManager sfxInstance;
    public AudioSource Audio, background;

    public AudioClip Player_Jump,
        Player_Grapple,
        Player_Collect_Star,
        Player_Death,
        World_Music,
        Error,
        Selection,
        Level_Finish;

    private void Awake()
    {
        if (sfxInstance != null && sfxInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        sfxInstance = this;
        DontDestroyOnLoad(this);

        if (background != null)
        {
            background.Play();
        }
    }
}
