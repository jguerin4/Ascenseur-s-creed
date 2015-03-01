using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class LevelProperties : MonoBehaviour {

	public float timerMax;
	public string levelName;
	public int ScoreToPlay;
	int spider;
	int clown;
	int dog;
	int combos;
	int scores;
	int bestScore;
	float timerInTime;
	public bool endgame;
	public bool ActivateMenu;
	CharacterScore MasterScore;
	//UI
	public GameObject EndGame;
	public GameObject HUD;
	// Use this for initialization
	void Start () {
		timerInTime = 0;
		spider = 0;
		clown = 0;
		dog = 0;
		combos = 0;
		scores = 0;
		endgame = false;
		ActivateMenu = false;
		EndGame.SetActive (false);
		HUD.SetActive (true);
		HUD.transform.FindChild ("Score").GetComponent<Text> ().text = "Score : 0";
		HUD.transform.FindChild ("TimerButton").GetComponentInChildren<Text> ().text = TimeSpan.FromMinutes(Math.Round(timerMax,1)).ToString();
		MasterScore = GameObject.Find ("MasterScore").GetComponent<CharacterScore> ();

		//set le best score
		if (PlayerPrefs.HasKey("BestScore_" + levelName))
			bestScore = PlayerPrefs.GetInt ("BestScore_" + levelName);
		else
			bestScore = 0;
	}
	public void updatEnnemy(string ennemy)
	{
		if (ennemy == "spider")
			spider++;
		else if (ennemy == "clown")
			clown++;
		else if (ennemy == "dog")
			dog++;
	}
	public void AddCombos()
	{
		combos++;
	}
	public void DeleteCombos()
	{
		combos = 0;
	}
	public void UpdateScore(int newScore)
	{
		scores += newScore;
		HUD.transform.FindChild ("Score").GetComponent<Text> ().text = "Score : " + scores;
	}
	public int getKill(string ennemy)
	{
		if (ennemy == "spider")
			return spider;
		else if (ennemy == "clown")
			return clown;
		else if (ennemy == "dog")
			return dog;
		else
			return 0;
	}
	public int getCombos()
	{
		return combos;
	}
	public int getScores()
	{
		return scores;
	}
	public void reload()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
	public void endGame()
	{
		endgame = true;
		if (ActivateMenu) {
			HUD.SetActive (false);
			EndGame.SetActive (true);
			EndGame.transform.FindChild ("Menu").transform.FindChild("Score text").GetComponent<Text>().text = MasterScore.ScoreTotal.ToString();
			if(bestScore < scores)
			{
				PlayerPrefs.SetInt("BestScore_" +levelName, scores);
			}
			EndGame.transform.FindChild("YourScore").GetComponent<Text>().text = "Ton score: " + scores.ToString();
			EndGame.transform.FindChild("BestScore").GetComponent<Text>().text = "Meilleur score: " + bestScore.ToString();

		}

	}
	// Update is called once per frame
	void Update () {
	
		if (!endgame) {
			timerInTime += Time.deltaTime;
			HUD.transform.FindChild("FearBar").GetComponent<RawImage>().color = new Vector4((25.5f*timerInTime)/25.5f,0,0,255);
			HUD.transform.FindChild ("TimerButton").GetComponentInChildren<Text> ().text = TimeSpan.FromMinutes (Math.Round (timerMax - timerInTime, 1)).ToString ();
		}
		if (timerInTime >= timerMax) {
			//end level
			endGame();
		}
	}
}
