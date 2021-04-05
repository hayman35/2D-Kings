using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{
    [SerializeField] private int levelSelectID;
    [SerializeField] private GameObject help;
				private bool helpBool = false;
    

    public void startGame() {
        SceneManager.LoadScene(levelSelectID);
				}
    public void quitGame() {
        Application.Quit();
				}
    public void showHelp() {
								if (!helpBool) {
												help.SetActive(true);
												helpBool = true;
								}
								else {
												help.SetActive(false);
												helpBool = false;
								}
				}
    
}
