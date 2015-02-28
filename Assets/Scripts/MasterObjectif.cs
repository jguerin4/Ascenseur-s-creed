using UnityEngine;
using System.Collections;

public class MasterObjectif : MonoBehaviour {

	public Objectifs SceneObjectifs;
	int kill_n;
	int carry_n;
	int ultime_n;
	int discovert_n;
	int combos_n;
	int scores_n;
	LevelProperties Level;
	// Use this for initialization
	void Start () {
		kill_n = SceneObjectifs.Kill.toDo;
		carry_n = SceneObjectifs.Carry.toDo;
		ultime_n = SceneObjectifs.Ultime.toDo;
		discovert_n = SceneObjectifs.Discovert.toDo;
		combos_n = SceneObjectifs.Combos.toDo;
		scores_n = SceneObjectifs.HighScores.toDo;

		Level = GameObject.Find ("LevelProperties").GetComponent<LevelProperties> ();
	}

	public void kill()
	{
		// si le le nombre de kill de kill.ennemy est égale a kill.todo debloquer l'objectif
		if (Level.getKill (SceneObjectifs.Kill.ennemy) == kill_n) {
			SceneObjectifs.Kill.State = true;
		}

	}
	public void combos()
	{
		// si le nombre de combos est égale a combos.todo debloquer l'objectif
		if (Level.getCombos() == combos_n) {
			SceneObjectifs.Combos.State = true;
		}
	}
	public void carry()
	{
		// si le nombre de carry object est égale a carry.todo debloquer l'objectif
		carry_n--;
		if (carry_n == 0) {

			SceneObjectifs.Carry.State = true;
			Debug.Log ("Terminé objectif");
		}

	}
	public void Ultime()
	{
		// a chaque fois qu'un ultime est déclancher appeler ultime() et si ultime_n est égale a 0 debloquer l'objectif
		ultime_n--;
		if(ultime_n == 0)
		{
			SceneObjectifs.Ultime.State = true;
		}
	}
	public void discovert()
	{
		// a chaque fois qu'un endoirt a découvrir est découvert appeler discovert() et si discovert_n est égale a 0 debloquer l'objectif
		discovert_n--;
		if (discovert_n == 0) {
			SceneObjectifs.Discovert.State = true;
		}
	}
	public void highscore()
	{
		// si le scores est egale a highscore.todo debloquer l'objectif
	}

	// Update is called once per frame
	void Update () {
	
		kill ();
		combos ();
		highscore ();
	}
}
