using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Combos : MonoBehaviour {

	private string buttonPressed;
	private List<string> buttonList; 

	private BoxCollider collider;

	private string combo1 = "XXX";
	private string combo2 = "XXY";
	private string combo3 = "XBB";
	private string combo4 = "XYXY";
	private string combo5 = "YXY";
	private string combo6 = "YXX";
	private string combo7 = "YBXX";
	private string attackX = "X";
	private string attackY = "Y";
	private string attackB = "B";

	private float timerEndSimpleAttack;
	private float simpleAttackTimer;
	private float timerEndCombo;
	private float comboTimer;
	private float cooldownTimer;
	private float timerEndCooldown;

	private bool canCombo;
	private bool canAttack;
	private bool onCooldown;

	void Start () 
	{
		collider = gameObject.GetComponent<BoxCollider>();
		canCombo = false;

		timerEndCooldown = 0.0f;
		timerEndCombo = 0.0f;
		timerEndSimpleAttack = 0.0f;
		cooldownTimer = 1.0f;
		comboTimer = 0.25f;
		simpleAttackTimer = 0.5f;

		buttonList = new List<string>();

		buttonPressed = "";

		canAttack = true;
		onCooldown = false;
	}

	void Update () 
	{
		if(!canAttack)
		{
			timerEndSimpleAttack += Time.deltaTime;
		}

		if(timerEndSimpleAttack >= simpleAttackTimer)
		{
			canAttack = true;
		}

		if(onCooldown)
		{
			timerEndCooldown += Time.deltaTime;
			if(timerEndCooldown >= cooldownTimer)
			{
				onCooldown = false;
				timerEndCooldown = 0.0f;
			}
		}
		else
		{
			timerEndCombo += Time.deltaTime;

			if(timerEndCombo >= comboTimer)
			{
				buttonList.Clear();
				timerEndCombo = 0.0f;
			}

			if(Input.GetButtonDown("X"))
			{
				buttonPressed = "X";
				timerEndCombo = 0.0f;
				if(canAttack)
				{
					simpleAttack("X");
					canAttack = false;
					timerEndSimpleAttack = 0.0f;
				}
			}

			if(Input.GetButtonDown("Y"))
			{
				buttonPressed = "Y";
				timerEndCombo = 0.0f;
				if(canAttack)
				{
					simpleAttack("Y");
					canAttack = false;
					timerEndSimpleAttack = 0.0f;
				}
			}

			if(Input.GetButtonDown("B"))
			{
				buttonPressed = "B";
				timerEndCombo = 0.0f;
				if(canAttack)
				{
					simpleAttack("B");
					canAttack = false;
					timerEndSimpleAttack = 0.0f;
				}
			}

			if(buttonPressed != "")
			{
				buttonList.Add(buttonPressed);
				buttonPressed = "";
				timerEndCombo = 0.0f;

				addButton();
			}
		}
	}

	public void addButton()
	{
		string finalStr = "";
		
		foreach(string str in buttonList)
		{
			finalStr += str;
		}
		checkCombo(finalStr);
	}

	public void checkCombo(string str)
	{
		if (str.Contains(combo1) && buttonList.Count == 3)
		{
			buttonList.Clear();
			onCooldown = true;
			transform.GetComponent<CharacterAnims>().StartAttack1();

			Debug.Log(combo1);
			return;
		}

		if (str.Contains(combo2) && buttonList.Count == 3)
		{
			buttonList.Clear();
			onCooldown = true;
			transform.GetComponent<CharacterAnims>().StartAttack1();

			Debug.Log(combo2);
			return;
		}

		if (str.Contains(combo3) && buttonList.Count == 3)
		{
			buttonList.Clear();
			onCooldown = true;
			transform.GetComponent<CharacterAnims>().StartAttack1();

			Debug.Log(combo3);
			return;
		}

		if (str.Contains(combo4) && buttonList.Count == 4)
		{
			buttonList.Clear();
			onCooldown = true;
			transform.GetComponent<CharacterAnims>().StartAttack1();

			Debug.Log(combo4);
			return;
		}

		if (str.Contains(combo5) && buttonList.Count == 3)
		{
			buttonList.Clear();
			onCooldown = true;
			transform.GetComponent<CharacterAnims>().StartAttack1();

			Debug.Log(combo5);
			return;
		}

		if (str.Contains(combo6) && buttonList.Count == 3)
		{
			buttonList.Clear();
			onCooldown = true;
			transform.GetComponent<CharacterAnims>().StartAttack1();

			Debug.Log(combo6);
			return;
		}

		if (str.Contains(combo7) && buttonList.Count == 4)
		{
			buttonList.Clear();
			onCooldown = true;
			transform.GetComponent<CharacterAnims>().StartAttack1();

			Debug.Log(combo7);
			return;
		}
	}

	public void simpleAttack(string str)
	{
		if(str == attackX)
		{
			transform.GetComponent<CharacterAnims>().StartAttack1();
			Debug.Log(attackX);
		}

		else if(str == attackB)
		{
			transform.GetComponent<CharacterAnims>().StartAttack1();
			Debug.Log(attackB);
		}

		else if(str == attackY)
		{
			transform.GetComponent<CharacterAnims>().StartAttack1();
			Debug.Log(attackY);
		}
	}

	void OnTriggerEnter(Collider col)
	{
		Debug.Log("collision");
	}
}
