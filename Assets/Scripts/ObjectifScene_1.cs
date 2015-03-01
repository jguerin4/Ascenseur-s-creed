using UnityEngine;
using System.Collections;

public class ObjectifScene_1 : Objectifs{

	
	// Use this for initialization
	void Awake () {
	
		Kill.name = "Tuer 10 araignée";
		Kill.toDo = 1;
		Kill.ennemy = "Spider";

		Combos.name = "Faire 5 attaques réussites de suite";
		Combos.toDo = 5;

		Carry.name = "Récolter 3 veilleuses";
		Carry.toDo = 3;
	
		Ultime.name = "Faire une attaque Ultime";
		Ultime.toDo = 1;
	
		Discovert.name = "Découvrir la caverne";
		Discovert.toDo = 1;

		HighScores.name = "Avoir un score d'au moins 40 000";
		HighScores.toDo = 40000;

		//Values init
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

	void Update () {
	

	}
}
