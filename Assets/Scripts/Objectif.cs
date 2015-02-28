using UnityEngine;
using System.Collections;

public class Objectifs : MonoBehaviour {

	public Objectif Kill;
	public Objectif Combos;
	public Objectif Carry;
	public Objectif Ultime;
	public Objectif Discovert;
	public Objectif HighScores;

	// Use this for initialization
	void Start () {

		Kill.State = false;
		Kill.value = 100;

		Combos.State = false;
		Combos.value = 200;

		Carry.State = false;
		Carry.value = 500;

		Ultime.State = false;
		Ultime.value = 200;

		Discovert.State = false;
		Discovert.value = 250;

		HighScores.State = false;
		HighScores.value = 1000;
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
