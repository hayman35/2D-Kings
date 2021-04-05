using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour{
				[SerializeField] private int mainMenuID;
				[SerializeField] private PlayerController player;
				[SerializeField] private GameObject help;
				private bool helpBool = false;

				public void resume() {
								player.pause();
				}
				public void mainMenu() {
								SceneManager.LoadScene(mainMenuID);
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
