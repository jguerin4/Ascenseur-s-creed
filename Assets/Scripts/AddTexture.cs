using UnityEngine;
using System.Collections;

public class AddTexture : MonoBehaviour {

	public Texture newText;


	// Use this for initialization
	void Start () {
		renderer.material.SetTexture("_MyTexture", newText);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
