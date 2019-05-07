using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public GameObject PauseUI;

	private bool paused = false;

	void Start(){

		// Zet het menu uit
		PauseUI.SetActive (false);

	}

	void Update(){

		// Als esc wordt in geklikt
		if (Input.GetButtonDown ("Pause")) {

			// Zet "paused" uit
			paused = !paused;

		}

		// Als de game "paused" is
		if (paused) {

			// Zet het "PauseUI" aan
			PauseUI.SetActive (true);

			// Freeze time
			Time.timeScale = 0;

		}

		// Als de game NIET "paused" is
		if (!paused) {

			// Zet het "PauseUI" uit
			PauseUI.SetActive (false);

			// UNfreeze time
			Time.timeScale = 1;

		}

	}

	// Knoppen in het pauze menu

	public void Resume(){

		paused = false;

	}

	public void Restart(){

		// Laad het level opnieuw
		Application.LoadLevel (Application.loadedLevel);

	}

	public void MainMenu(){

		// Ga naar een ander level (Main Menu)
		Application.LoadLevel (0);

	}

	public void Quit(){

		// Sluit de applicatie af
		Application.Quit();

	}

}
