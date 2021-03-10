using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformSelectUI : MonoBehaviour
{
    [SerializeField] private ItemBuilder builder;

    [SerializeField] private PlatformType platformLarge;
    [SerializeField] private PlatformType platformMedium;
    [SerializeField] private PlatformType platformSmall;
    [SerializeField] private PlatformType spikyPlatfromLarge;
    [SerializeField] private PlatformType spikyPlatformMedium;
    [SerializeField] private PlatformType spikyPlatformSmall;

    void Awake() {
        //Not sure how to loop this.
        //Finds all the buttons and assigns them to a variable.
        Transform PlatformLargeButton = transform.Find("PlatformLargeButton");
        Transform PlatformMediumButton = transform.Find("PlatformMediumButton");
        Transform PlatformSmallButton = transform.Find("PlatformSmallButton");
        Transform SpikyPlatformLargeButton = transform.Find("SpikyPlatformLargeButton");
        Transform SpikyPlatformMediumButton = transform.Find("SpikyPlatformMediumButton");
        Transform SpikyPlatformSmallButton = transform.Find("SpikyPlatformSmallButton");

        //Sets what the buttons do when they are clicked on.
        //When a button is clicked, sets the selected platform to be of the type specified by the button.
        PlatformLargeButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            builder.setSelectedPlatformType(platformLarge);
        });

        PlatformMediumButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            builder.setSelectedPlatformType(platformMedium);
        });

        PlatformSmallButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            builder.setSelectedPlatformType(platformSmall);
        });

        SpikyPlatformLargeButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            builder.setSelectedPlatformType(spikyPlatfromLarge);
        });

        SpikyPlatformMediumButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            builder.setSelectedPlatformType(spikyPlatformMedium);
        });

        SpikyPlatformSmallButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            builder.setSelectedPlatformType(spikyPlatformSmall);
        });

    }
}
