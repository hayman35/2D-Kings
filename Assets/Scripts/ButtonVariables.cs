using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ButtonVariables : MonoBehaviour{
    [SerializeField]private PlatformType type;
    [SerializeField]private int quantity;
    [SerializeField]private PlatformSelectUI selector;
    [SerializeField]public TextMeshProUGUI platformCount;

    private int used=0;

	void Start(){
        platformCount.text = quantity.ToString();
    }

	public void OnButtonPress() {
        if (used < quantity) {
            used++;
			int count = quantity - used;
            platformCount.text = count.ToString();
            selector.createGhost(type);
        }
    }
}
