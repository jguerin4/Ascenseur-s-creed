using UnityEngine;
using System.Collections;

public class SplashEnemie : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 30f);
		Destroy (this, 30f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
