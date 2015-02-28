using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{
	public GameObject comboObj;
	public GameObject nameObj;
	
	private Vector3 currentScaleCombo;
	private float timerScaleCombo;
	private bool startedCombo;
	internal int currentComboScore;
	private float speedScaleCombo = 2f;
	
	private bool startedName;
	private float timerScaleName;
	private Vector3 currentScaleName;
	private float speedScaleName = 1f;
	
	private float testTimer = 0.0f;
	private int testScore = 0;
	
	private float xRangeCombo = 100;
	private float yRangeCombo = 50;
	private float xStartCombo;
	private float yStartCombo;

	void Start() 
	{
		currentScaleCombo = new Vector3(0, 0, 0);
		timerScaleCombo = 0.5f;
		startedCombo = false;
		comboObj.SetActive(false);
		
		currentScaleName = new Vector3(0, 0, 0);
		timerScaleName = 0.5f;
		nameObj.SetActive(false);
		startedName = false;
		
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
			nameObj.transform.GetComponentInChildren<Text>().text = "Annihilate!";
		}
		if (indice == 3)
		{
			nameObj.GetComponent<Image>().color = new Color(0f/255f, 0f/255f, 200f/255f, 150f/255f);
			nameObj.transform.GetComponentInChildren<Text>().text = "Crushing Blow!";
		}
		
		startedName = true;
		timerScaleName -= 0.2f;
	}
	
	internal void AppearName()
	{
		if (timerScaleName <= 1.3f)
		{
			timerScaleName += Time.deltaTime * speedScaleName;
			nameObj.transform.localScale = new Vector3(timerScaleName, timerScaleName, timerScaleName);
		}
		else
		{
			startedName = false;
			nameObj.SetActive(false);
			timerScaleName = 0.5f;
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
			comboObj.SetActive(false);
			timerScaleCombo = 0.5f;
		}
	}
}
