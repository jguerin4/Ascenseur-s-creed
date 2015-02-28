using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Combos : MonoBehaviour {

	private string buttonPressed;
	private List<string> buttonList; 
	private List<GameObject> enemyList;

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
	
	private int nbCol;
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
		cooldownTimer = 0.5f;
		comboTimer = 0.25f;
		simpleAttackTimer = 0.5f;

		buttonList = new List<string>();
		enemyList = new List<GameObject>();

		buttonPressed = "";

		canAttack = true;
		onCooldown = false;
	}

	void Update () 
	{
		if(nbCol > 0)
		{
			canCombo = true;
		}
		else
		{
			canCombo = false;
		}


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
				if(canCombo)
				{
					buttonList.Add(buttonPressed);
					addButton();
				}
				buttonPressed = "";
				timerEndCombo = 0.0f;
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
		int damage = 0;

		if (str.Contains(combo1) && buttonList.Count == 3)
		{
			buttonList.Clear();
			onCooldown = true;
			transform.GetComponent<CharacterAnims>().StartCombo();

			damage = 2;
			doDamage(damage);

			Debug.Log(combo1);
			return;
		}

		if (str.Contains(combo2) && buttonList.Count == 3)
		{
			buttonList.Clear();
			onCooldown = true;
			transform.GetComponent<CharacterAnims>().StartCombo();

			damage = 2;
			doDamage(damage);

			Debug.Log(combo2);
			return;
		}

		if (str.Contains(combo3) && buttonList.Count == 3)
		{
			buttonList.Clear();
			onCooldown = true;
			transform.GetComponent<CharacterAnims>().StartCombo();

			damage = 2;
			doDamage(damage);

			Debug.Log(combo3);
			return;
		}

		if (str.Contains(combo4) && buttonList.Count == 4)
		{
			buttonList.Clear();
			onCooldown = true;
			transform.GetComponent<CharacterAnims>().StartCombo();

			damage = 3;
			doDamage(damage);

			Debug.Log(combo4);
			return;
		}

		if (str.Contains(combo5) && buttonList.Count == 3)
		{
			buttonList.Clear();
			onCooldown = true;
			transform.GetComponent<CharacterAnims>().StartCombo();

			damage = 2;
			doDamage(damage);

			Debug.Log(combo5);
			return;
		}

		if (str.Contains(combo6) && buttonList.Count == 3)
		{
			buttonList.Clear();
			onCooldown = true;
			transform.GetComponent<CharacterAnims>().StartCombo();

			damage = 2;
			doDamage(damage);

			Debug.Log(combo6);
			return;
		}

		if (str.Contains(combo7) && buttonList.Count == 4)
		{
			buttonList.Clear();
			onCooldown = true;
			transform.GetComponent<CharacterAnims>().StartCombo();

			damage = 3;
			doDamage(damage);

			Debug.Log(combo7);
			return;
		}
	}

	public void simpleAttack(string str)
	{
		int damage = 0;

		if(str == attackX)
		{
			transform.GetComponent<CharacterAnims>().StartAttack1();
			damage = 1;
			Debug.Log(attackX);
		}

		else if(str == attackB)
		{
			transform.GetComponent<CharacterAnims>().StartAttack2();
			damage = 1;
			Debug.Log(attackB);
		}

		else if(str == attackY)
		{
			transform.GetComponent<CharacterAnims>().StartAttack3();
			damage = 1;
			Debug.Log(attackY);
		}

		doDamage(damage);
	}

	void OnTriggerEnter(Collider col)
	{
		if((col.tag == "Spider" || col.tag == "Dog" || col.tag == "Clown") && col.GetType() == typeof(CapsuleCollider))
		{
			enemyList.Add(col.gameObject);

			nbCol++;
			rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
		}
	}

	void OnTriggerExit(Collider col)
	{
		if((col.tag == "Spider" || col.tag == "Dog" || col.tag == "Clown") && col.GetType() == typeof(CapsuleCollider))
		{
			enemyList.Remove(col.gameObject);

			nbCol--;
			rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
		}
	}

	private void doDamage(int damage)
	{
		int size = enemyList.Count;
		for (int i = 0; i < size; i++)
		{
			enemyList[i].GetComponent<Pushback>().PushEnemy();

			if(enemyList[i].gameObject.GetComponent<AImob>().getHealth() <= damage)
			{
				enemyList[i].gameObject.GetComponent<AImob>().doDamage(damage);
				enemyList.RemoveAt(i);
				nbCol--;
				size--;
				i--;
				if(i < 0)
				{
					i = 0;
				}
			}
			else
			{
				enemyList[i].gameObject.GetComponent<AImob>().doDamage(damage);
			}
		}
	}
}
