using UnityEngine;
using System.Collections;

public class CharacterScore : MonoBehaviour {
	
	public int ScoreTotal;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
		ScoreTotal = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
