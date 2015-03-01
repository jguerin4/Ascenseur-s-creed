using UnityEngine;
using System.Collections;

public class ObjectifScene_1 : Objectifs{

	
	// Use this for initialization
	void Awake () {
	
		Kill.name = "Tuer 1 araignée";
		Kill.toDo = 1;

		Combos.name = "Donnez 5 coups de suite";
		Combos.toDo = 5;

		Carry.name = "Recolte 5 veilleuses";
		Carry.toDo = 5;
	
		Ultime.name = "Faites une Attaque Ultime";
		Ultime.toDo = 1;
	
		Discovert.name = "Découvrez la caverne";
		Discovert.toDo = 1;

		HighScores.name = " Ayez un score de 10 000";
		HighScores.toDo = 10000;

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
