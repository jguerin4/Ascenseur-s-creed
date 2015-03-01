using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MasterObjectifs : MonoBehaviour {
	
	public Objectifs SceneObjectifs;
	int kill_n;
	int carry_n;
	int ultime_n;
	int discovert_n;
	int combos_n;
	int scores_n;
	public LevelProperties Level;
	CharacterScore MasterScore;
	public GameObject ObjectifHud;
	
	float timerValidateObjectif;
	bool validate;
	float endMenuTimer;
	
	int winScore;
	// Use this for initialization
	void Start () {
		if(MainMenuManager.loadedFromLevelSelection == true || resetObjectives.loadedFromReset == true)
		{
			Debug.Log("Reseting obj");
			resetObjectif();
		}
		else
		{
			kill_n = SceneObjectifs.Kill.toDo;
			carry_n = SceneObjectifs.Carry.toDo;
			ultime_n = SceneObjectifs.Ultime.toDo;
			discovert_n = SceneObjectifs.Discovert.toDo;
			combos_n = SceneObjectifs.Combos.toDo;
			scores_n = SceneObjectifs.HighScores.toDo;
		}
		
		winScore = 0;
		timerValidateObjectif = 0.5f;
		endMenuTimer = 3;
		validate = false;
		
		Level = GameObject.Find ("Level").GetComponent<LevelProperties> ();
		MasterScore = GameObject.Find ("MasterScore").GetComponent<CharacterScore> ();

		initialiseObjectif ();
		ObjectifHud.SetActive (false);

	}
	void resetObjectif()
	{
		SceneObjectifs.Kill.toDo = 10;
		SceneObjectifs.Carry.toDo = 3;
		SceneObjectifs.Ultime.toDo = 1;
		SceneObjectifs.Discovert.toDo = 1;
		SceneObjectifs.Combos.toDo = 5;
		SceneObjectifs.HighScores.toDo = 40000;
		/*
		PlayerPrefs.SetString ("kill_" + Level.levelName, "false");
		PlayerPrefs.SetString ("combos_" + Level.levelName, "false");
		PlayerPrefs.SetString ("carry_" + Level.levelName, "false");
		PlayerPrefs.SetString ("ultime_" + Level.levelName, "false");
		PlayerPrefs.SetString ("discovert_" + Level.levelName, "false");
		PlayerPrefs.SetString ("highscore_" + Level.levelName, "false");
*/
		PlayerPrefs.DeleteAll();


		kill_n = SceneObjectifs.Kill.toDo;
		carry_n = SceneObjectifs.Carry.toDo;
		ultime_n = SceneObjectifs.Ultime.toDo;
		discovert_n = SceneObjectifs.Discovert.toDo;
		combos_n = SceneObjectifs.Combos.toDo;
		scores_n = SceneObjectifs.HighScores.toDo;

		SceneObjectifs.Kill.State = false;
		SceneObjectifs.Combos.State = false;
		SceneObjectifs.Carry.State = false;
		SceneObjectifs.Ultime.State = false;
		SceneObjectifs.Discovert.State = false;
		SceneObjectifs.HighScores.State = false;

	}

	void initialiseObjectif()
	{
		if (PlayerPrefs.GetString ("kill_" + Level.levelName) == "true") {
			SceneObjectifs.Kill.alreadyDone = true;
			SceneObjectifs.Kill.State = true;
		}
		if (PlayerPrefs.GetString ("combos_" + Level.levelName) == "true") {
			SceneObjectifs.Combos.alreadyDone = true;
			SceneObjectifs.Combos.State = true;
		}
		if (PlayerPrefs.GetString ("carry_" + Level.levelName) == "true") {
			SceneObjectifs.Carry.alreadyDone = true;
			SceneObjectifs.Carry.State = true;
		}
		if (PlayerPrefs.GetString ("ultime_" + Level.levelName) == "true") {
			SceneObjectifs.Ultime.alreadyDone = true;
			SceneObjectifs.Ultime.State = true;
		}
		if (PlayerPrefs.GetString ("discovert_" + Level.levelName) == "true") {
			SceneObjectifs.Discovert.alreadyDone = true;
			SceneObjectifs.Discovert.State = true;
		}
		if (PlayerPrefs.GetString ("highscore_" + Level.levelName) == "true") {
			SceneObjectifs.HighScores.alreadyDone = true;
			SceneObjectifs.HighScores.State = true;
		}
	}
	public void kill()
	{
		// si le le nombre de kill de kill.ennemy est égale a kill.todo debloquer l'objectif
		if (Level.getKill (SceneObjectifs.Kill.ennemy) == kill_n) {
			SceneObjectifs.Kill.State = true;
			Level.PopObjectif(SceneObjectifs.Kill.name);

//			Debug.Log("set true");
		}
		
	}
	public void combos()
	{
		// si le nombre de combos est égale a combos.todo debloquer l'objectif
		if (Level.getCombos() >= combos_n) {
			SceneObjectifs.Combos.State = true;
			Level.PopObjectif(SceneObjectifs.Combos.name);

			
		}
	}
	public void carry()
	{
		// si le nombre de carry object est égale a carry.todo debloquer l'objectif
		carry_n--;
		if (carry_n == 0) {
			
			SceneObjectifs.Carry.State = true;
			Level.PopObjectif(SceneObjectifs.Carry.name);


			
		}
		
	}
	public void Ultime()
	{
		// a chaque fois qu'un ultime est déclancher appeler ultime() et si ultime_n est égale a 0 debloquer l'objectif
		ultime_n--;
		if(ultime_n == 0)
		{
			SceneObjectifs.Ultime.State = true;
			Level.PopObjectif(SceneObjectifs.Ultime.name);


			
		}
	}
	public void discovert()
	{
		// a chaque fois qu'un endoirt a découvrir est découvert appeler discovert() et si discovert_n est égale a 0 debloquer l'objectif
		discovert_n--;
		if (discovert_n <= 0) {
			SceneObjectifs.Discovert.State = true;
			Level.PopObjectif(SceneObjectifs.Discovert.name);

			
		}
	}
	public void highscore()
	{
		// si le scores est egale a highscore.todo debloquer l'objectif
		if (Level.getScores () == scores_n) {
			SceneObjectifs.HighScores.State = true;
			Level.PopObjectif(SceneObjectifs.HighScores.name);

			
		}
	}
	internal void PrintObjectifDone()
	{
		ObjectifHud.SetActive (true);
		
		//Set les texts des objectif
		ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Kill").GetComponent<Text> ().text = SceneObjectifs.Kill.name;
		ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Combos").GetComponent<Text> ().text = SceneObjectifs.Combos.name;
		ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Carry").GetComponent<Text> ().text = SceneObjectifs.Carry.name;
		ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Ultime").GetComponent<Text> ().text = SceneObjectifs.Ultime.name;
		ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Discovert").GetComponent<Text> ().text = SceneObjectifs.Discovert.name;
		ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("High Score").GetComponent<Text> ().text = SceneObjectifs.HighScores.name;
		
		if (SceneObjectifs.Kill.alreadyDone == true) {
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Kill").GetComponent<Text> ().color = new Vector4 (150,150,150,255);
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Kill").GetComponent<Text> ().fontStyle = FontStyle.Italic;
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Kill").transform.FindChild("Check").GetComponent<Image>().color = new Vector4(150,150,150,255);
		} else {
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Kill").GetComponent<Text> ().color = new Vector4 (0, 0, 0, 255);
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Kill").GetComponent<Text> ().fontStyle = FontStyle.Normal;
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Kill").transform.FindChild("Check").GetComponent<Image>().color = new Vector4(0,0,0,0);
		}
		if (SceneObjectifs.Combos.alreadyDone == true) {
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Combos").GetComponent<Text> ().color = new Vector4 (150,150,150,255);
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Combos").GetComponent<Text> ().fontStyle = FontStyle.Italic;
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Combos").transform.FindChild("Check").GetComponent<Image>().color = new Vector4(150,150,150,255);
		} else {
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Combos").GetComponent<Text> ().color = new Vector4 (0, 0, 0, 255);
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Combos").GetComponent<Text> ().fontStyle = FontStyle.Normal;
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Combos").transform.FindChild("Check").GetComponent<Image>().color = new Vector4(0,0,0,0);
		}
		if (SceneObjectifs.Carry.alreadyDone == true) {
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Carry").GetComponent<Text> ().color = new Vector4 (150,150,150,255);
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Carry").GetComponent<Text> ().fontStyle = FontStyle.Italic;
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Carry").transform.FindChild("Check").GetComponent<Image>().color = new Vector4(150,150,150,255);
		} else {
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Carry").GetComponent<Text> ().color = new Vector4 (0, 0, 0, 255);
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Carry").GetComponent<Text> ().fontStyle = FontStyle.Normal;
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Carry").transform.FindChild("Check").GetComponent<Image>().color = new Vector4(0,0,0,0);
		}
		if (SceneObjectifs.Ultime.alreadyDone == true) {
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Ultime").GetComponent<Text> ().color = new Vector4 (150,150,150,255);
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Ultime").GetComponent<Text> ().fontStyle = FontStyle.Italic;
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Ultime").transform.FindChild("Check").GetComponent<Image>().color = new Vector4(150,150,150,255);
		} else {
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Ultime").GetComponent<Text> ().color = new Vector4 (0, 0, 0, 255);
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Ultime").GetComponent<Text> ().fontStyle = FontStyle.Normal;
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Ultime").transform.FindChild("Check").GetComponent<Image>().color = new Vector4(0,0,0,0);
		}
		if (SceneObjectifs.Discovert.alreadyDone == true) {
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Discovert").GetComponent<Text> ().color = new Vector4 (150,150,150,255);
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Discovert").GetComponent<Text> ().fontStyle = FontStyle.Italic;
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Discovert").transform.FindChild("Check").GetComponent<Image>().color = new Vector4(150,150,150,255);
		} else {
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Discovert").GetComponent<Text> ().color = new Vector4 (0, 0, 0, 255);
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Discovert").GetComponent<Text> ().fontStyle = FontStyle.Normal;
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Discovert").transform.FindChild("Check").GetComponent<Image>().color = new Vector4(0,0,0,0);
		}
		if (SceneObjectifs.HighScores.alreadyDone == true) {
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("High Score").GetComponent<Text> ().color = new Vector4 (150,150,150,255);
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("High Score").GetComponent<Text> ().fontStyle = FontStyle.Italic;
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("High Score").transform.FindChild("Check").GetComponent<Image>().color = new Vector4(150,150,150,255);
		} else {
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("High Score").GetComponent<Text> ().color = new Vector4 (0, 0, 0, 255);
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("High Score").GetComponent<Text> ().fontStyle = FontStyle.Normal;
			ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("High Score").transform.FindChild("Check").GetComponent<Image>().color = new Vector4(0,0,0,0);
		}
	}
	void ValidateObjectif()
	{
		if (!validate) {
			Debug.Log(SceneObjectifs.Kill.State);
			if (SceneObjectifs.Kill.alreadyDone != true & SceneObjectifs.Kill.State == true) {
				ObjectifHud.transform.FindChild ("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Kill").GetComponent<Text> ().color = new Vector4 (255, 0, 0, 255);
				ObjectifHud.transform.FindChild ("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Kill").GetComponent<Text> ().fontStyle = FontStyle.Bold;
				ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Kill").transform.FindChild("Check").GetComponent<Image>().color = new Vector4(0,0,0,255);
				PlayerPrefs.SetString("kill_"+Level.levelName,"true");
				winScore += SceneObjectifs.Kill.value; 
			} 
			if (SceneObjectifs.Combos.alreadyDone != true & SceneObjectifs.Combos.State == true) {
				ObjectifHud.transform.FindChild ("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Combos").GetComponent<Text> ().color = new Vector4 (255, 0, 0, 255);
				ObjectifHud.transform.FindChild ("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Combos").GetComponent<Text> ().fontStyle = FontStyle.Bold;
				ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Combos").transform.FindChild("Check").GetComponent<Image>().color = new Vector4(0,0,0,255);
				PlayerPrefs.SetString("combos_"+Level.levelName,"true");
				winScore += SceneObjectifs.Combos.value; 
			} 
			if (SceneObjectifs.Carry.alreadyDone != true & SceneObjectifs.Carry.State == true) {
				ObjectifHud.transform.FindChild ("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Carry").GetComponent<Text> ().color = new Vector4 (255, 0, 0, 255);
				ObjectifHud.transform.FindChild ("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Carry").GetComponent<Text> ().fontStyle = FontStyle.Bold;
				ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Carry").transform.FindChild("Check").GetComponent<Image>().color = new Vector4(0,0,0,255);
				PlayerPrefs.SetString("carry_"+Level.levelName,"true");
				winScore += SceneObjectifs.Carry.value; 
			} 
			if (SceneObjectifs.Ultime.alreadyDone != true & SceneObjectifs.Ultime.State == true) {
				ObjectifHud.transform.FindChild ("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Ultime").GetComponent<Text> ().color = new Vector4 (255, 0, 0, 255);
				ObjectifHud.transform.FindChild ("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Ultime").GetComponent<Text> ().fontStyle = FontStyle.Bold;
				ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Ultime").transform.FindChild("Check").GetComponent<Image>().color = new Vector4(0,0,0,255);
				PlayerPrefs.SetString("ultime_"+Level.levelName,"true");
				winScore += SceneObjectifs.Ultime.value; 
			} 
			if (SceneObjectifs.Discovert.alreadyDone != true & SceneObjectifs.Discovert.State == true) {
				ObjectifHud.transform.FindChild ("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Discovert").GetComponent<Text> ().color = new Vector4 (255, 0, 0, 255);
				ObjectifHud.transform.FindChild ("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Discovert").GetComponent<Text> ().fontStyle = FontStyle.Bold;
				ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("Discovert").transform.FindChild("Check").GetComponent<Image>().color = new Vector4(0,0,0,255);
				PlayerPrefs.SetString("discovert_"+Level.levelName,"true");
				winScore += SceneObjectifs.Discovert.value; 
			} 
			if (SceneObjectifs.HighScores.alreadyDone != true & SceneObjectifs.HighScores.State == true) {
				ObjectifHud.transform.FindChild ("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("High Score").GetComponent<Text> ().color = new Vector4 (255, 0, 0, 255);
				ObjectifHud.transform.FindChild ("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("High Score").GetComponent<Text> ().fontStyle = FontStyle.Bold;
				ObjectifHud.transform.FindChild("First Panel").transform.FindChild ("Objectif Name").transform.FindChild ("High Score").transform.FindChild("Check").GetComponent<Image>().color = new Vector4(0,0,0,255);
				PlayerPrefs.SetString("highscore_"+Level.levelName,"true");
				winScore += SceneObjectifs.HighScores.value; 
			}
			ObjectifHud.transform.FindChild ("First Panel").transform.FindChild ("Score gagner").GetComponent<Text> ().text = "+ " + winScore.ToString ();
			MasterScore.ScoreTotal += winScore;
			PlayerPrefs.SetInt("TotalScore",MasterScore.ScoreTotal);
		}
		validate = true;
	}
	// Update is called once per frame
	void Update () {
		
		if (Level.endgame) {
			if(timerValidateObjectif <=0){
				ValidateObjectif();
				if(endMenuTimer <= 0){
					ObjectifHud.transform.FindChild ("First Panel").transform.FindChild ("Score gagner").GetComponent<Text> ().text = " " ;
					Level.ActivateMenu = true;
				}
				else
					endMenuTimer -= Time.deltaTime;
			}
			else{
				PrintObjectifDone();
				timerValidateObjectif -= Time.deltaTime;
			}
		}
		kill ();
		combos ();
		highscore ();

		if (Input.GetButtonDown ("Back"))
			PrintObjectifDone ();
		if (Input.GetButtonUp ("Back") & !Level.endgame)
			ObjectifHud.SetActive (false);
	}
}

