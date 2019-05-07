using UnityEngine;
using System.Collections;

public class scriptgeluid : MonoBehaviour {

	public AudioClip geluid1;

	// Use this for initialization
	void Start () {

		// Het het geluid op
		this.GetComponent<AudioSource> ().PlayOneShot (geluid1);

	}

}
