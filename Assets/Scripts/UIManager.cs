using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{
	public GameObject comboObj;
	
	private Vector3 currentScaleCombo;
	private float timerScaleCombo;
	private bool startedCombo;
	internal int currentComboScore;

	void Start() 
	{
		currentScaleCombo = new Vector3(0, 0, 0);
		timerScaleCombo = 0.5f;
		startedCombo = false;
		comboObj.SetActive(false);
	}
	
	void Update() 
	{
		if (startedCombo)
		{
			AppearComboObj(currentComboScore);
		}
	}
	
	internal void StartAppearComboObj(int score)
	{
		comboObj.SetActive(true);
		startedCombo = true;
		currentComboScore = score;
		timerScaleCombo -= 0.2f;
		comboObj.transform.GetComponentInChildren<Text>().text = "Combo x" + score;
	}
	
	internal void AppearComboObj(int score)
	{
		if (timerScaleCombo <= 1.0f)
		{
			timerScaleCombo += Time.deltaTime;
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
