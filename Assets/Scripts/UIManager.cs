﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{
	public GameObject comboObj;
	public GameObject nameObj;
	public GameObject pointsObj;
	
	private Vector3 currentScaleCombo;
	private float timerScaleCombo;
	private bool startedCombo;
	internal int currentComboScore;
	private float speedScaleCombo = 2f;
	
	private bool startedName;
	private float timerScaleName;
	private Vector3 currentScaleName;
	private float speedScaleName = 1f;
	
	private bool startedPoints;
	private float timerScalePoints;
	private Vector3 currentScalePoints;
	private float speedScalePoints = 1f;
	
	private float testTimer = 0.0f;
	private int testScore = 0;
	
	private float xRangeCombo = 100;
	private float yRangeCombo = 50;
	private float xStartCombo;
	private float yStartCombo;

	bool ultimate = false;

	void Start() 
	{
		timerScaleCombo = 0.5f;
		currentScaleCombo = new Vector3(timerScaleCombo, timerScaleCombo, timerScaleCombo);
		startedCombo = false;
		comboObj.SetActive(false);
		
		timerScaleName = 0.5f;
		currentScaleName = new Vector3(timerScaleName, timerScaleName,timerScaleName);
		nameObj.SetActive(false);
		startedName = false;
		
		timerScalePoints = 0.5f;
		currentScalePoints = new Vector3(timerScalePoints, timerScalePoints,timerScalePoints);
		pointsObj.SetActive(false);
		startedPoints = false;
		
		xStartCombo = comboObj.transform.position.x;
		yStartCombo = comboObj.transform.position.y;
		
		//StartAppearName(1);
	}
	
	void Update() 
	{
		/*testTimer += Time.deltaTime;
		
		if (testTimer >= 0.3f)
		{
			testScore++;
			StartAppearComboObj(testScore);
			testTimer = 0.0f;
		}*/
	
		if (startedCombo)
		{
			AppearComboObj();
		}
		
		if (startedName)
		{
			AppearName();
		}
		
		if (startedPoints)
		{
			AppearPoints();
		}
	}
	
	internal void StartAppearName(int indice)
	{
		nameObj.SetActive(true);
		
		if (indice == 1)
		{
			nameObj.GetComponent<Image>().color = new Color(200f/255f, 0f/255f, 0f/255f, 150f/255f);
			nameObj.transform.GetComponentInChildren<Text>().text = "Super Slash!";
		}
		if (indice == 2)
		{
			nameObj.GetComponent<Image>().color = new Color(0f/255f, 200f/255f, 0f/255f, 150f/255f);
			nameObj.transform.GetComponentInChildren<Text>().text = "Whirlwind!";
		}
		if (indice == 3)
		{
			nameObj.GetComponent<Image>().color = new Color(0f/255f, 0f/255f, 200f/255f, 150f/255f);
			nameObj.transform.GetComponentInChildren<Text>().text = "Crushing Blow!";
		}
		if (indice == 4)
		{
			nameObj.GetComponent<Image>().color = new Color(200f/255f, 200f/255f, 0f/255f, 150f/255f);
			nameObj.transform.GetComponentInChildren<Text>().text = "Heavy Strike!";
		}
		if (indice == 5)
		{
			nameObj.GetComponent<Image>().color = new Color(255f/255f, 255f/255f, 255f/255f, 150f/255f);
			nameObj.transform.GetComponentInChildren<Text>().text = "Ultimate Attack!";
			ultimate = true;
			
		}
		nameObj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
		
		startedName = true;
	}
	
	internal void AppearName()
	{
		if (timerScaleName <= 1.0f)
		{
			timerScaleName += Time.deltaTime * speedScaleName;
			nameObj.transform.localScale = new Vector3(timerScaleName, timerScaleName, timerScaleName);
		}
		else if (timerScaleName > 1.0f && timerScaleName <= 1.5f)
		{
			timerScaleName += Time.deltaTime * speedScaleName;
		}
		else
		{
			startedName = false;
			nameObj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
			ultimate = false;
			nameObj.SetActive(false);
			timerScaleName = 0.5f;
		}
		
		if (ultimate)
		{
			nameObj.GetComponent<Image>().color = new Color(Random.Range(0.0f, 1.0f),
			                                                Random.Range(0.0f, 1.0f), 
			                                                Random.Range(0.0f, 1.0f),
			  												150f/255f);
		}
	}
	
	internal void StartAppearComboObj(int score)
	{
		comboObj.SetActive(true);
		startedCombo = true;
		currentComboScore = score;
		timerScaleCombo -= 0.2f;
		comboObj.transform.GetComponentInChildren<Text>().text = "x" + score;
		comboObj.transform.rotation = new Quaternion(0, 0, 0, 0);
		
		float xRand = Random.Range(-xRangeCombo, xRangeCombo);
		float yRand = Random.Range(-yRangeCombo, yRangeCombo);
		
		comboObj.transform.position = new Vector2(xStartCombo + xRand, yStartCombo + yRand);
		
		float rotAmount = Random.Range(-20, 20);
		
		comboObj.transform.Rotate(new Vector3(0, 0, 1), rotAmount);
	}
	
	internal void AppearComboObj()
	{
		if (timerScaleCombo <= 1.3f)
		{
			timerScaleCombo += Time.deltaTime * speedScaleCombo;
			comboObj.transform.localScale = new Vector3(timerScaleCombo, timerScaleCombo, timerScaleCombo);
		}
		else
		{
			startedCombo = false;
			comboObj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
			comboObj.SetActive(false);
			timerScaleCombo = 0.5f;
		}
	}
	
	internal void StartAppearPoints(int score)
	{
		startedPoints = true;
		timerScalePoints -= 0.2f;
		pointsObj.SetActive(true);
		pointsObj.transform.GetComponentInChildren<Text>().text = "+" + score;
	}
	
	internal void AppearPoints()
	{
		if (timerScalePoints <= 1.3f)
		{
			timerScalePoints += Time.deltaTime * speedScalePoints;
			pointsObj.transform.localScale = new Vector3(timerScalePoints, timerScalePoints, timerScalePoints);
		}
		else
		{
			startedPoints = false;
			pointsObj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
			pointsObj.SetActive(false);
			timerScalePoints = 0.5f;
		}
	}
}
