using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonVariables : MonoBehaviour{
    [SerializeField]private PlatformType type;
    [SerializeField]private int quantity;
    [SerializeField]private PlatformSelectUI selector;

	[SerializeField]private Text textfield;




    private int used=0;

	void Start(){
		textfield.text = "Remaining: " + quantity.ToString();
	}

	public void OnButtonPress() {
        if (used < quantity) {
            used++;
			int count = quantity - used;
			textfield.text = "Remaining: " + count.ToString();
            selector.createGhost(type);
       }
        
				}
}
