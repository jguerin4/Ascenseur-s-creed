using UnityEngine;
using System.Collections;

public class ObjectifScene_1 : Objectifs{

	
	// Use this for initialization
	void Start () {
	
		Kill.name = "Kill 10 spiders";
		Kill.toDo = 10;

		Combos.name = "Do 5 combos in a row";
		Combos.toDo = 5;

		Carry.name = "Carry 5 night light";
		Carry.toDo = 5;
	
		Ultime.name = "Do an Ultime Attack";
		Ultime.toDo = 1;
	
		Discovert.name = "Discovert the caverne";
		Discovert.toDo = 1;

		HighScores.name = " High Score 10 000";
		HighScores.toDo = 10000;

	}

	void Update () {
	

	}
}
