using UnityEngine;
using System.Collections;

public class player_script : MonoBehaviour {

	public float maxSpeed = 3;
	public float speed = 150f;
	public float jumpPower = 250f;

	public bool grounded;

	private Rigidbody2D rb2d;
	private Animator anim;

	public AudioClip geluid1;

	public static Vector2 player1Spawn = new Vector2(-47f, 9f);

	// Use this for initialization
	void Start () {

		// Haal de rigibody en de animator op
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();

	}

	// Update is called once per frame
	void Update() {

		anim.SetBool("Grounded",grounded);
		anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

		// Lopen
		if (Input.GetAxis ("Horizontal") < -0.1f) {
			transform.localScale = new Vector3(-1, 1, 1);
		}
		if (Input.GetAxis ("Horizontal") > 0.1f) {
			transform.localScale = new Vector3(1, 1, 1);
		}

		// Springen (kan alleen springen als "grounded" true is)
		if (Input.GetButtonDown ("Jump") && grounded) {

			// Geef de "JumpPower mee"
			rb2d.AddForce(Vector2.up * jumpPower);
		}

		// Als je van de map afvalt
		if (transform.position.y < -10) {

			// Zet de speler terug naar spawn
			transform.position = player1Spawn;

			// Speel geluid af
			this.GetComponent<AudioSource> ().PlayOneShot (geluid1);
		}

		// Als je de kroon bereikt hebt
		if (transform.position.x > 46) {

			// Ga naar het winner scherm
			Application.LoadLevel(2);
		}
	}

	void FixedUpdate() {

		Vector3 easeVelocity = rb2d.velocity;

		// Maak gelijk aan de "rb2d.velocity.y"
		easeVelocity.y = rb2d.velocity.y;

		// Zet naar 0
		easeVelocity.z = 0.0f;

		// Verminder snelheid
		easeVelocity.x *= 0.75f;

		float h = Input.GetAxis("Horizontal");

		// Als "grounded" true is
		if (grounded){

			// Ga langzaam slomer (wrijving)
			rb2d.velocity = easeVelocity;

		}

		// Beweging
		rb2d.AddForce ((Vector2.right * speed) * h);

		// Zorg ervoor dat de speler een snelheidslimiet heeft
		if (rb2d.velocity.x > maxSpeed) {

			// Voeg "maxSpeed" toe
			rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
		}

		if (rb2d.velocity.x < -maxSpeed) {
			// Voeg "-maxSpeed" toe
			rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
		}

	}


}
