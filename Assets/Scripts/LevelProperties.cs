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
	private bool flasfOff;
	float lastFear;
	float timerFear;
	float timerPopUP;
	bool PopUP;
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
		lastFear = 0;
		timerFear = 0;
		timerPopUP = 0;
		PopUP = false;


		flasfOff = false;
		endgame = false;
		ActivateMenu = false;
		EndGame.SetActive(false);
		HUD.SetActive (true);
		HUD.transform.FindChild ("Score").GetComponent<Text> ().text = "Score : 0";
		HUD.transform.FindChild ("TimerButton").GetComponentInChildren<Text> ().text = TimeSpan.FromMinutes(Math.Round(timerMax,1)).ToString();
		MasterScore = GameObject.Find ("MasterScore").GetComponent<CharacterScore> ();

		if (levelName == null)
			levelName = "Mon premier reve";

		//set le best score
		if (PlayerPrefs.HasKey("BestScore_" + levelName))
			bestScore = PlayerPrefs.GetInt ("BestScore_" + levelName);
		else
			bestScore = 0;
	}
	public void resetInstance()
	{
		Start();
	}

	public void updatEnnemy(string ennemy)
	{
		if (ennemy == "Spider")
			spider++;
		else if (ennemy == "Clown")
			clown++;
		else if (ennemy == "Dog")
			dog++;
	}
	public void AddCombos()
	{
		combos++;
	}
	public void setCombo(int nbComboMax)
	{
		combos = nbComboMax;
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
		if (ennemy == "Spider")
			return spider;
		else if (ennemy == "Clown")
			return clown;
		else if (ennemy == "Dog")
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
		Spawning.m_numberOfMobs = 0;
		CharacterProperties.fearProgression = 0;
		Application.LoadLevel (Application.loadedLevel);
	}
	public void endGame()
	{
		endgame = true;
		if (ActivateMenu) {
			EndGame.SetActive (true);
			EndGame.transform.FindChild ("Menu").transform.FindChild("Score text").GetComponent<Text>().text = MasterScore.ScoreTotal.ToString();
			if(bestScore < scores)
			{
				PlayerPrefs.SetInt("BestScore_" +levelName, scores);
				PlayerPrefs.Save();
			}
			EndGame.transform.FindChild("YourScore").GetComponent<Text>().text = "Ton score: " + scores.ToString();
			EndGame.transform.FindChild("BestScore").GetComponent<Text>().text = "Meilleur score: " + bestScore.ToString();
			GameObject.Find("Character").GetComponent<CharacterAnims>().enabled = false;

		}

	}

	public void PopObjectif(string theObjectif)
	{
		string Objectif = theObjectif;
		HUD.transform.FindChild ("PopUP").GetComponent<Text> ().text = Objectif;
	}
	// Update is called once per frame
	void Update () {
	


		if (!endgame) {
			timerInTime += Time.deltaTime;
			if(CharacterProperties.isSpecialAvailable())
			{
				if(flasfOff == true)
				{
					flasfOff = false;
					HUD.transform.FindChild ("FearBar").GetComponent<RawImage> ().color = new Vector4 (255, 255/2, 0, 255/2);
				}
				else
				{
					flasfOff = true;
					HUD.transform.FindChild ("FearBar").GetComponent<RawImage> ().color = new Vector4 (255, 0, 0, 255);
				}
				HUD.transform.FindChild ("FearBar").GetComponentInChildren<Text> ().text = "Ultime Valide"; 
				HUD.transform.FindChild ("FearBar").GetComponentInChildren<Text> ().color = new Vector4 (255, 0, 0, 255);
			}
			else
			{
				HUD.transform.FindChild ("FearBar").GetComponentInChildren<Text> ().color = new Vector4 (0, 0, 0, 255);
				if(lastFear != CharacterProperties.fearProgression){
					HUD.transform.FindChild ("FearBar").GetComponentInChildren<Text> ().text = "Peur -" + CharacterProperties.fearProgression.ToString (); 
					timerFear += Time.deltaTime;
					if(timerFear >= 1.0f)
					{
					lastFear = CharacterProperties.fearProgression;
						timerFear = 0;
					}
				}
				else{
					HUD.transform.FindChild ("FearBar").GetComponentInChildren<Text> ().text = "Peur " ; 
				}
				HUD.transform.FindChild ("FearBar").GetComponent<RawImage> ().color = new Vector4 (/*64 + (*/CharacterProperties.fearProgression/CharacterProperties.fearAccumulationMax/*)/4*/, 0, 0, 255);	                                                                                  
			}
			HUD.transform.FindChild ("TimerButton").GetComponentInChildren<Text> ().text = TimeSpan.FromMinutes (Math.Round (timerMax - timerInTime, 1)).ToString ();
		} else
			HUD.SetActive (false);
		if (timerInTime >= timerMax) {
			//end level
			endGame();
		}


		//Input
		if(Input.GetButtonDown("Jump") & ActivateMenu)
		{
			reload();
		}
		if (Input.GetButtonDown ("B") & ActivateMenu) {
			//Aller a la selection de niveau
			Spawning.m_numberOfMobs = 0;
			CharacterProperties.fearProgression = 0;
			Application.LoadLevel("LevelSelection");
		}
		if(Input.GetButtonDown("Back")& ActivateMenu){
			//Quitter
			Application.Quit();
		
		}
	}
}
