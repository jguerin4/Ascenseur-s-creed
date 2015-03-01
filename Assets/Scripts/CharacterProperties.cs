using UnityEngine;
using System.Collections;

public class CharacterProperties : MonoBehaviour {

	static public int fearProgression;
	public int fearAccumulationMax;
	static public bool UltimeActivate;
	// Use this for initialization
	void Start () {
		fearProgression = 0;
		fearAccumulationMax = 10;
		UltimeActivate = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
