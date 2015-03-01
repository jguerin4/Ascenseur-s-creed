using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class LevelSelection : MonoBehaviour {

	// Use this for initialization

	public GameObject UI;
	public Objectifs objectif;

	public int nombreLevel;

	string levelName;

	public Sprite level1;
	public Sprite level2;
	void Start () {
	

		if (nombreLevel > 1) {

			UI.transform.FindChild ("Next").GetComponent<Button> ().interactable = true;
			UI.transform.FindChild ("Prev").GetComponent<Button> ().interactable = true;
		} else {
			UI.transform.FindChild ("Next").GetComponent<Button> ().interactable = false;
			UI.transform.FindChild ("Prev").GetComponent<Button> ().interactable = false;
		}
		levelName = "Mon premier reve";
		UI.transform.FindChild ("Level Panel").transform.FindChild ("Image").GetComponent<Image> ().sprite = level1;
		UI.transform.FindChild ("Level Panel").transform.FindChild ("Text").GetComponent<Text> ().text = "<< " + levelName + " >>";


		UI.transform.FindChild ("Level Panel").transform.FindChild ("Kill").GetComponent<Text> ().text = objectif.Kill.name;
		if (PlayerPrefs.GetString ("kill_" + levelName) == "true") {
			UI.transform.FindChild ("Level Panel").transform.FindChild ("Kill").GetComponent<Text> ().color = new Vector4 (255, 255, 255, 255);
			UI.transform.FindChild ("Level Panel").transform.FindChild ("Kill").FindChild ("Check").GetComponent<Image> ().color = new Vector4 (0, 0, 0, 255);
		} else {
			UI.transform.FindChild ("Level Panel").transform.FindChild ("Kill").GetComponent<Text> ().color = new Vector4 (255, 0, 0, 255);
			UI.transform.FindChild ("Level Panel").transform.FindChild ("Kill").FindChild ("Check").GetComponent<Image> ().color = new Vector4 (0, 0, 0, 0);
		}


		UI.transform.FindChild ("Level Panel").transform.FindChild ("Combos").GetComponent<Text> ().text = objectif.Combos.name;
		if (PlayerPrefs.GetString ("combos_" + levelName) == "true") {
			UI.transform.FindChild ("Level Panel").transform.FindChild ("Combos").GetComponent<Text> ().color = new Vector4 (255, 255, 255, 255);
			UI.transform.FindChild ("Level Panel").transform.FindChild ("Combos").FindChild ("Check").GetComponent<Image> ().color = new Vector4 (0, 0, 0, 255);
		} else {
			UI.transform.FindChild ("Level Panel").transform.FindChild ("Combos").GetComponent<Text> ().color = new Vector4 (255, 0, 0, 255);
			UI.transform.FindChild ("Level Panel").transform.FindChild ("Combos").FindChild ("Check").GetComponent<Image> ().color = new Vector4 (0, 0, 0, 0);
		}


		UI.transform.FindChild ("Level Panel").transform.FindChild ("Carry").GetComponent<Text> ().text = objectif.Carry.name;
		if (PlayerPrefs.GetString ("carry_" + levelName) == "true") {
			UI.transform.FindChild ("Level Panel").transform.FindChild ("Carry").GetComponent<Text> ().color = new Vector4 (255, 255, 255, 255);
			UI.transform.FindChild ("Level Panel").transform.FindChild ("Carry").FindChild ("Check").GetComponent<Image> ().color = new Vector4 (0, 0, 0, 255);
		} else {
			UI.transform.FindChild ("Level Panel").transform.FindChild ("Carry").GetComponent<Text> ().color = new Vector4 (255, 0, 0, 255);
			UI.transform.FindChild ("Level Panel").transform.FindChild ("Carry").FindChild ("Check").GetComponent<Image> ().color = new Vector4 (0, 0, 0, 0);
		}


		UI.transform.FindChild ("Level Panel").transform.FindChild ("Ultime").GetComponent<Text> ().text = objectif.Ultime.name;
		if (PlayerPrefs.GetString ("ultime_" + levelName) == "true") {
			UI.transform.FindChild ("Level Panel").transform.FindChild ("Ultime").GetComponent<Text> ().color = new Vector4 (255, 255, 255, 255);
			UI.transform.FindChild ("Level Panel").transform.FindChild ("Ultime").FindChild ("Check").GetComponent<Image> ().color = new Vector4 (0, 0, 0, 255);
		} else {
			UI.transform.FindChild ("Level Panel").transform.FindChild ("Ultime").GetComponent<Text> ().color = new Vector4 (255, 0, 0, 255);
			UI.transform.FindChild ("Level Panel").transform.FindChild ("Ultime").FindChild ("Check").GetComponent<Image> ().color = new Vector4 (0, 0, 0, 0);
		}


		UI.transform.FindChild ("Level Panel").transform.FindChild ("Discovert").GetComponent<Text> ().text = objectif.Discovert.name;
		if (PlayerPrefs.GetString ("discovert_" + levelName) == "true") {
			UI.transform.FindChild ("Level Panel").transform.FindChild ("Discovert").GetComponent<Text> ().color = new Vector4 (255, 255, 255, 255);
			UI.transform.FindChild ("Level Panel").transform.FindChild ("Discovert").FindChild ("Check").GetComponent<Image> ().color = new Vector4 (0, 0, 0, 255);
		} else {
			UI.transform.FindChild ("Level Panel").transform.FindChild ("Discovert").GetComponent<Text> ().color = new Vector4 (255, 0, 0, 255);
			UI.transform.FindChild ("Level Panel").transform.FindChild ("Discovert").FindChild ("Check").GetComponent<Image> ().color = new Vector4 (0, 0, 0, 0);
		}


		UI.transform.FindChild ("Level Panel").transform.FindChild ("High Score").GetComponent<Text> ().text = objectif.HighScores.name;
		if (PlayerPrefs.GetString ("highscore" + levelName) == "true") {
			UI.transform.FindChild ("Level Panel").transform.FindChild ("High Score").GetComponent<Text> ().color = new Vector4 (255, 255, 255, 255);
			UI.transform.FindChild ("Level Panel").transform.FindChild ("High Score").FindChild ("Check").GetComponent<Image> ().color = new Vector4 (0, 0, 0, 255);
		} else {
			UI.transform.FindChild ("Level Panel").transform.FindChild ("High Score").GetComponent<Text> ().color = new Vector4 (255, 0, 0, 255);
			UI.transform.FindChild ("Level Panel").transform.FindChild ("High Score").FindChild ("Check").GetComponent<Image> ().color = new Vector4 (0, 0, 0, 0);
		}
	}

	public void loadLevel()
	{
		if(levelName == "Mon premier reve")
			Application.LoadLevel ("Map");
	}
	public void Back()
	{
		Application.LoadLevel ("MainMenu");
	}
	// Update is called once per frame
	void Update () {
	
	}
}
