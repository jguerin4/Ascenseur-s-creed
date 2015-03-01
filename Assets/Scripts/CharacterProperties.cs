using UnityEngine;
using System.Collections;

public class CharacterProperties : MonoBehaviour {

	static public float fearProgression;
	static public float fearAccumulationMax = 10f;
	static public bool UltimeActivate;
	// Use this for initialization
	void Start () {
		fearProgression = 0;
		UltimeActivate = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	static public void increaseFear(int addFear)
	{
		fearProgression += addFear;
		if (fearProgression > fearAccumulationMax)
		{
			UltimeActivate = true;
			fearProgression = fearAccumulationMax;
		}
		else if(fearProgression == fearAccumulationMax)
		{
			UltimeActivate = true;
		}
		//Debug.Log("Fear progression: " + fearProgression);
	}

	static public void resetFearProgression()
	{
		fearProgression = 0;
		UltimeActivate = false;
	}

	static public bool isSpecialAvailable()
	{
		if (UltimeActivate == true)
		{
			return true;
		}
		else
			return false;
	}


}
