using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	private player_script player;

	void Start(){

		// Haal de "player_script" uit het parent object op
		player = gameObject.GetComponentInParent<player_script>();

	}

	// Als de collider iets raakt "on..Enter"
	void OnTriggerEnter2D(Collider2D col){

		// Zet grounded in het player script naar true
		player.grounded = true;
	
	}

	// Als de collider iets raakt
	void OnTriggerStay2D(Collider2D col){

		// Zet grounded in het player script naar true
		player.grounded = true;
		
	}

	// Als de collider NIETS raakt
	void OnTriggerExit2D(Collider2D col){

		// Zet grounded in het player script naar false
		player.grounded = false;

	}

}
