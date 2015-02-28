using UnityEngine;
using System.Collections;

public class PlayerGetDamaged : MonoBehaviour
{
	float timer = 0.0f;
	internal bool damaged = false;
	float speed = 1f;
	
	Color defaultTopBody;
	Color defaultRightLeg;
	Color defaultLeftLeg;
	Color defaultLowBody;
	Color defaultRightArm;
	Color defaultLeftArm;
	Color defaultWeapon;
	Color defaultHead;
	
	void Start() 
	{
		defaultTopBody = GameObject.Find("TopBody").renderer.material.color;
		defaultRightLeg = GameObject.Find("RightLeg").renderer.material.color;
		defaultLeftLeg = GameObject.Find("LeftLeg").renderer.material.color;
		defaultLowBody = GameObject.Find("LowBody").renderer.material.color;
		defaultRightArm = GameObject.Find("RightArm").renderer.material.color;
		defaultLeftArm = GameObject.Find("LeftArm").renderer.material.color;
		defaultWeapon = GameObject.Find("Weapon").renderer.material.color;
		defaultHead = GameObject.Find("Head").renderer.material.color;
	}
	
	void Update() 
	{
		if (damaged)
		{
			timer += Time.deltaTime * speed;
			
			SetPlayerColor(LerpPlayerColor(defaultTopBody), "TopBody");
			SetPlayerColor(LerpPlayerColor(defaultRightLeg), "RightLeg");
			SetPlayerColor(LerpPlayerColor(defaultLeftLeg), "LeftLeg");
			SetPlayerColor(LerpPlayerColor(defaultLowBody), "LowBody");
			SetPlayerColor(LerpPlayerColor(defaultRightArm), "RightArm");
			SetPlayerColor(LerpPlayerColor(defaultLeftArm), "LeftArm");
			SetPlayerColor(LerpPlayerColor(defaultWeapon), "Weapon");
			SetPlayerColor(LerpPlayerColor(defaultHead), "Head");
			
			if (timer >= 1f)
			{
				damaged = false;
				
				SetPlayerColor(defaultTopBody, "TopBody");
				SetPlayerColor(defaultRightLeg, "RightLeg");
				SetPlayerColor(defaultLeftLeg, "LeftLeg");
				SetPlayerColor(defaultLowBody, "LowBody");
				SetPlayerColor(defaultRightArm, "RightArm");
				SetPlayerColor(defaultLeftArm, "LeftArm");
				SetPlayerColor(defaultWeapon, "Weapon");
				SetPlayerColor(defaultHead, "Head");
			}
		}
	}
	
	Color LerpPlayerColor(Color defaultColor)
	{
		return Color.Lerp(Color.red, defaultColor, timer);
	}
	
	void SetPlayerColor(Color p, string obj)
	{
		GameObject.Find(obj).renderer.material.color = p;
	}
	
	internal void PlayerDamaged()
	{
		timer = 0.0f;
		damaged = true;
	}
}
