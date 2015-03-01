using UnityEngine;
using System.Collections;

public class CharacterProperties : MonoBehaviour {

	static public int fearProgression;
	static public int fearAccumulationMax = 30;
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
	}

	static public void resetFearProgression()
	{
		fearProgression = 0;
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
