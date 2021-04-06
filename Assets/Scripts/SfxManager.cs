using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public static SfxManager sfxInstance;
    public AudioSource Audio;

    public AudioClip Player_Jump,
        Player_Grapple,
        Player_Collect_Star,
        Player_Death,
        World_1_Music,
        World_2_Music,
        World_3_Music,
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

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
