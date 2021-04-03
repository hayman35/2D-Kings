using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonVariables : MonoBehaviour{
    [SerializeField]private PlatformType type;
    [SerializeField]private int quantity;
    [SerializeField]private PlatformSelectUI selector;
    private int used=0;
    
				public void OnButtonPress() {
        if (used < quantity) {
            used++;
            selector.createGhost(type);
            
        }
        
				}
}
