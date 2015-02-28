using UnityEngine;
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
	float timerInTime;
	// Use this for initialization
	void Start () {
		timerInTime = 0;
		timerMax = 90;
		spider = 0;
		clown = 0;
		dog = 0;
		combos = 0;
		scores = 0;

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
	// Update is called once per frame
	void Update () {
	
		timerInTime += Time.deltaTime;
		if (timerInTime >= timerMax) {
			//end level
		}
	}
}
