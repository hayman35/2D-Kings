using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PickUp : MonoBehaviour
{
    public TextMeshProUGUI starsText;

    private float numberOfStarsCollected = 0;


    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Stars"))
        {
            numberOfStarsCollected += 1;
            starsText.text = numberOfStarsCollected.ToString();
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Player_Collect_Star);

            Destroy(other.gameObject);
        }
    }
}
