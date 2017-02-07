using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour {

	GameObject[] pauseObjects;
	public Canvas pauseMenu;
	public Button resumeText;
	public Button exitToMenuText;
	public Button exitToDesktopText;

	void Start () {
		pauseMenu = pauseMenu.GetComponent<Canvas> ();
		resumeText = resumeText.GetComponent<Button> ();
		exitToMenuText = exitToMenuText.GetComponent<Button> ();
		exitToDesktopText = exitToDesktopText.GetComponent<Button> ();
		hidePaused ();
	}
	

	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			if (Time.timeScale == 1) {
				Time.timeScale = 0;
				showPaused ();
			} else if (Time.timeScale == 0) {
				Time.timeScale = 1;
				hidePaused ();
			}
		}
	}

	public void hidePaused(){
		pauseMenu.enabled = false;
		resumeText.enabled = false;
		exitToMenuText.enabled = false;
		exitToDesktopText.enabled = false;
	}

	public void showPaused(){
		pauseMenu.enabled = true;
		resumeText.enabled = true;
		exitToMenuText.enabled = true;
		exitToDesktopText.enabled = true;
	}

	public void onResume(){
		Time.timeScale = 1;
		hidePaused ();
	}

	public void onExitToMenu(){
		SceneManager.LoadScene ("title");
	}

	public void onExitToDesktop(){
		Application.Quit ();
	}
}
