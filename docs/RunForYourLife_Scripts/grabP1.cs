using UnityEngine;
using System.Collections;

public class grabP1 : MonoBehaviour {

	public bool grabbed;
	RaycastHit2D hit;
	public float distance = 2f;
	public Transform holdpoint;
	public LayerMask notgrabbed;
	public GameObject other;

	void Start () {

		GameObject Speler = GameObject.Find("player2_script");

	}

	void Update () {

		// Klikt op E
		if (Input.GetKeyDown (KeyCode.E)) {

			// Als "grabbed" false is
			if (!grabbed) {

				// Haal NIET de colliders op waar de raycast in begint
				Physics2D.queriesStartInColliders = false;

				// Maak de raycast aan
				hit = Physics2D.Raycast (transform.position, Vector2.right * transform.localScale.x, distance);

				// Als je iets raakt en hij heeft de tag "grabbable" ("grabbable" is de tag die op het blokje staat)
				if (hit.collider != null && hit.collider.tag == "grabbable") {

					// Zet "grabbed" op true
					grabbed = true;

				}

				// Als je de andere speler raakt
				if (hit.collider != null && hit.collider.tag == "Player") {

					// Zet de andere speler terug naar zijn spawn positie
					other.transform.position = player2_script.player2Spawn;

				}
			
			// Check ofdat het in de layermask "notgrabbed" overlapt
			} else if (!Physics2D.OverlapPoint (holdpoint.position,notgrabbed)) {

				// Zet grabbed of flase
				grabbed = false;

				// Klik nog een keer E
				if (hit.collider.gameObject.GetComponent<Rigidbody2D> () != null) {

					// Zet of gooi het object (blokje) weg. Voor gooien moet je gewoon de kracht aanpassen
					hit.collider.gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (transform.localScale.x, 1);

				}

			}

		}

		// Als "grabbed" true is
		if (grabbed)

			// Waar je het object (blokje) vast hebt
			hit.collider.gameObject.transform.position = holdpoint.position;

	}

	// Nu kun je de range van de raycast makkelijk zien
	void OnDrawGizmos(){
		// Maak de lijn groen
		Gizmos.color = Color.green;

		// Teken de lijn op de juiste positie
		Gizmos.DrawLine (transform.position, transform.position + Vector3.right * transform.localScale.x * distance);
	}

}