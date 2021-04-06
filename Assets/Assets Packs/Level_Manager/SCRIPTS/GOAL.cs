﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GOAL : MonoBehaviour {

    public GameObject level_complete;

    public int unlock;

    void Start ()
    {
        Time.timeScale = 1;

        unlock = SceneManager.GetActiveScene().buildIndex + 1;

        level_complete.SetActive(false);


    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Player"))
        {
            print("Hit");
            PlayerPrefs.SetInt("levelReached", unlock);
            level_complete.SetActive(true);
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Level_Finish);



        }
    }
}
