using UnityEngine;
using System.Collections;

public class CharacterAnims : MonoBehaviour 
{
	float movementSpeed = 0.2f;

	float rotationSpeed = 400;
	float moveRotationSpeed = 400;
	bool currentlyActing = false;
	int currentAction = 0;
	
	Vector3 startPosLeftArm;
	Vector3 startPosRightArm;
	Vector3 startPosWeaponArm;
	Vector3 startPosRightLeg;
	Vector3 startPosLeftLeg;
	
	Quaternion startRotLeftArm;
	Quaternion startRotRightArm;
	Quaternion startRotWeaponArm;
	Quaternion startRotRightLeg;
	Quaternion startRotLeftLeg;
	
	bool movementSide = false;
	
	//public AnimationCurve temtemtemte;

	void Start() 
	{
		startPosLeftArm = GameObject.Find ("LeftArm").transform.localPosition;
		startPosRightArm = GameObject.Find ("RightArm").transform.localPosition;
		startPosWeaponArm = GameObject.Find ("Weapon").transform.localPosition;
		startPosRightLeg = GameObject.Find ("RightLeg").transform.localPosition;
		startPosLeftLeg = GameObject.Find ("LeftLeg").transform.localPosition;
		
		startRotLeftArm = GameObject.Find ("LeftArm").transform.localRotation;
		startRotRightArm = GameObject.Find ("RightArm").transform.localRotation;
		startRotWeaponArm = GameObject.Find ("Weapon").transform.localRotation;
		startRotRightLeg = GameObject.Find ("RightLeg").transform.localRotation;
		startRotLeftLeg = GameObject.Find ("LeftLeg").transform.localRotation;
	}

	void Update() 
	{
		if (!currentlyActing)
		{
			if (Input.GetKeyDown (KeyCode.Mouse0))
			{
				currentlyActing = true;
				currentAction = 1;
			}
			else if (Input.GetKeyDown (KeyCode.Mouse1))
			{
				currentlyActing = true;
				currentAction = 3;
			}
		}
		
		bool tempMoving = false;
		
		if (Input.GetKey(KeyCode.W))
		{
			Vector3 tempMove = Vector3.forward;
			tempMove *= movementSpeed;
			tempMoving = true;
			transform.Translate(tempMove);
		}
		
		if (Input.GetKey(KeyCode.S))
		{
			Vector3 tempMove = Vector3.forward;
			tempMove *= movementSpeed;
			tempMoving = true;
			transform.Translate(-tempMove);
		}
		
		if (Input.GetKey(KeyCode.A))
		{
			tempMoving = true;
			transform.RotateAround(transform.position,
			                       new Vector3 (0, 1, 0),
			                       -rotationSpeed * Time.deltaTime);
		}
		
		if (Input.GetKey(KeyCode.D))
		{
			tempMoving = true;
			transform.RotateAround(transform.position,
			                       new Vector3 (0, 1, 0),
			                       rotationSpeed * Time.deltaTime);
		}
		
		if (tempMoving)
		{
			Movement();
		}
		else 
		{
			ResetPosAndRotMovement();
			movementSide = false;
		}
		
		if (currentAction != 0)
		{
			switch (currentAction)
			{
				case (1):
					Attack1();
					break;
				case (2):
					Comeback1();
					break;
				case (3):
					SetAttack2();
					break;
				case (4):
					Attack2();
					break;
				case (5):
					Comeback2();
					break;
			}
		}
	}
	
	void Movement()
	{
		if (!movementSide)
		{
			GameObject.Find ("RightLeg").transform.RotateAround(GameObject.Find ("LowBody").transform.position,
			                                                    transform.right,
			                                                    moveRotationSpeed * Time.deltaTime);
			GameObject.Find ("LeftLeg").transform.RotateAround(GameObject.Find ("LowBody").transform.position,
			                                                   transform.right,
			                                                   -moveRotationSpeed * Time.deltaTime);
		}
		else
		{
			GameObject.Find ("RightLeg").transform.RotateAround(GameObject.Find ("LowBody").transform.position,
			                                                    transform.right,
			                                                    -moveRotationSpeed * Time.deltaTime);
			GameObject.Find ("LeftLeg").transform.RotateAround(GameObject.Find ("LowBody").transform.position,
			                                                   transform.right,
			                                                   moveRotationSpeed * Time.deltaTime);
		}
		
		if (GameObject.Find ("RightLeg").transform.localRotation.eulerAngles.x >= 60 &&
		    GameObject.Find ("RightLeg").transform.localRotation.eulerAngles.x < 90 &&
		  !movementSide)
		{
			GameObject.Find ("RightLeg").transform.localRotation.eulerAngles.Set(90,
			                                                                     GameObject.Find ("RightLeg").transform.localRotation.eulerAngles.y,
			                                                                     GameObject.Find ("RightLeg").transform.localRotation.eulerAngles.z);
			GameObject.Find ("LeftLeg").transform.localRotation.eulerAngles.Set(270,
			                                                                    GameObject.Find ("LeftLeg").transform.localRotation.eulerAngles.y,
			                                                                    GameObject.Find ("LeftLeg").transform.localRotation.eulerAngles.z);
			movementSide = true;
		}
		else if (GameObject.Find ("RightLeg").transform.localRotation.eulerAngles.x <= 300 &&
		         GameObject.Find ("RightLeg").transform.localRotation.eulerAngles.x > 270 &&
		  movementSide)
		{
			GameObject.Find ("RightLeg").transform.localRotation.eulerAngles.Set(270,
			                                                                     GameObject.Find ("RightLeg").transform.localRotation.eulerAngles.y,
			                                                                     GameObject.Find ("RightLeg").transform.localRotation.eulerAngles.z);
			GameObject.Find ("LeftLeg").transform.localRotation.eulerAngles.Set(90,
			                                                                    GameObject.Find ("LeftLeg").transform.localRotation.eulerAngles.y,
			                                                                    GameObject.Find ("LeftLeg").transform.localRotation.eulerAngles.z);
			movementSide = false;
		}
		
	}
	
	void Attack1()
	{
		GameObject.Find ("RightArm").transform.RotateAround(transform.position,
		                                                    new Vector3 (0, 1, 0),
		                                                    rotationSpeed * Time.deltaTime);
		GameObject.Find ("LeftArm").transform.RotateAround(transform.position,
		                                                    new Vector3 (0, 1, 0),
		                                                   rotationSpeed * Time.deltaTime);
		GameObject.Find ("Weapon").transform.RotateAround(transform.position,
		                                                   new Vector3 (0, 1, 0),
		                                                   rotationSpeed * Time.deltaTime);
		                                                  
		if (GameObject.Find ("RightArm").transform.localRotation.eulerAngles.y >= 180)
		{
			GameObject.Find ("RightArm").transform.localRotation.eulerAngles.Set(GameObject.Find ("RightArm").transform.localRotation.eulerAngles.x,
			                                                                     180,
			                                                                     GameObject.Find ("RightArm").transform.localRotation.eulerAngles.z);
			GameObject.Find ("LeftArm").transform.localRotation.eulerAngles.Set(GameObject.Find ("LeftArm").transform.localRotation.eulerAngles.x,
			                                                                     180,
			                                                                     GameObject.Find ("LeftArm").transform.localRotation.eulerAngles.z);
			GameObject.Find ("Weapon").transform.localRotation.eulerAngles.Set(GameObject.Find ("Weapon").transform.localRotation.eulerAngles.x,
			                                                                     90,
			                                                                   GameObject.Find ("Weapon").transform.localRotation.eulerAngles.z);
			currentAction = 2;
		}
	}
	
	void Comeback1()
	{
		GameObject.Find ("RightArm").transform.RotateAround(transform.position,
		                                                    new Vector3 (0, 1, 0),
		                                                    -rotationSpeed * Time.deltaTime);
		GameObject.Find ("LeftArm").transform.RotateAround(transform.position,
		                                                    new Vector3 (0, 1, 0),
		                                                   -rotationSpeed * Time.deltaTime);
		GameObject.Find ("Weapon").transform.RotateAround(transform.position,
		                                                   new Vector3 (0, 1, 0),
		                                                   -rotationSpeed * Time.deltaTime);
		                                                    
		if (GameObject.Find ("RightArm").transform.localRotation.eulerAngles.y <= 90)
		{
			GameObject.Find ("RightArm").transform.localRotation.eulerAngles.Set(GameObject.Find ("RightArm").transform.localRotation.eulerAngles.x,
			                                                                     90,
			                                                                     GameObject.Find ("RightArm").transform.localRotation.eulerAngles.z);
			GameObject.Find ("LeftArm").transform.localRotation.eulerAngles.Set(GameObject.Find ("LeftArm").transform.localRotation.eulerAngles.x,
			                                                                    90,
			                                                                    GameObject.Find ("LeftArm").transform.localRotation.eulerAngles.z);
			GameObject.Find ("Weapon").transform.localRotation.eulerAngles.Set(GameObject.Find ("Weapon").transform.localRotation.eulerAngles.x,
			                                                                   0,
			                                                                   GameObject.Find ("Weapon").transform.localRotation.eulerAngles.z);
				
			ResetPosAndRotAttack();
			
			currentAction = 0;
			currentlyActing = false;
		}
	}
	
	void SetAttack2()
	{
		GameObject.Find ("RightArm").transform.localRotation.eulerAngles.Set(GameObject.Find ("RightArm").transform.localRotation.eulerAngles.x,
		                                                                     GameObject.Find ("RightArm").transform.localRotation.eulerAngles.y,
		                                                                     0);
		GameObject.Find ("LeftArm").transform.localRotation.eulerAngles.Set(GameObject.Find ("LeftArm").transform.localRotation.eulerAngles.x,
		                                                                    GameObject.Find ("LeftArm").transform.localRotation.eulerAngles.y,
		                                                                    0);
		GameObject.Find ("Weapon").transform.localRotation.eulerAngles.Set(GameObject.Find ("Weapon").transform.localRotation.eulerAngles.x,
		                                                                   GameObject.Find ("Weapon").transform.localRotation.eulerAngles.y,
		                                                                   0);
		
		currentlyActing = false;                                                          
		//currentAction = 4;                                                                   
	}
	
	void Attack2()
	{
		GameObject.Find ("RightArm").transform.RotateAround(transform.position,
		                                                    new Vector3 (0, 0, 1),
		                                                    rotationSpeed * Time.deltaTime);
		GameObject.Find ("LeftArm").transform.RotateAround(transform.position,
		                                                   new Vector3 (0, 0, 1),
		                                                   rotationSpeed * Time.deltaTime);
		GameObject.Find ("Weapon").transform.RotateAround(transform.position,
		                                                  new Vector3 (0, 0, 1),
		                                                  rotationSpeed * Time.deltaTime);
		
		/*if (GameObject.Find ("RightArm").transform.localRotation.eulerAngles.y >= 180)
		{
			GameObject.Find ("RightArm").transform.localRotation.eulerAngles.Set(GameObject.Find ("RightArm").transform.localRotation.eulerAngles.x,
			                                                                     180,
			                                                                     GameObject.Find ("RightArm").transform.localRotation.eulerAngles.z);
			GameObject.Find ("LeftArm").transform.localRotation.eulerAngles.Set(GameObject.Find ("LeftArm").transform.localRotation.eulerAngles.x,
			                                                                    180,
			                                                                    GameObject.Find ("LeftArm").transform.localRotation.eulerAngles.z);
			GameObject.Find ("Weapon").transform.localRotation.eulerAngles.Set(GameObject.Find ("Weapon").transform.localRotation.eulerAngles.x,
			                                                                   90,
			                                                                   GameObject.Find ("Weapon").transform.localRotation.eulerAngles.z);
			currentAction = 5;
		}*/
	}
	
	void Comeback2()
	{
		GameObject.Find ("RightArm").transform.RotateAround(transform.position,
		                                                    new Vector3 (0, 1, 0),
		                                                    -rotationSpeed * Time.deltaTime);
		GameObject.Find ("LeftArm").transform.RotateAround(transform.position,
		                                                   new Vector3 (0, 1, 0),
		                                                   -rotationSpeed * Time.deltaTime);
		GameObject.Find ("Weapon").transform.RotateAround(transform.position,
		                                                  new Vector3 (0, 1, 0),
		                                                  -rotationSpeed * Time.deltaTime);
		
		if (GameObject.Find ("RightArm").transform.localRotation.eulerAngles.y <= 90)
		{
			GameObject.Find ("RightArm").transform.localRotation.eulerAngles.Set(GameObject.Find ("RightArm").transform.localRotation.eulerAngles.x,
			                                                                     90,
			                                                                     GameObject.Find ("RightArm").transform.localRotation.eulerAngles.z);
			GameObject.Find ("LeftArm").transform.localRotation.eulerAngles.Set(GameObject.Find ("LeftArm").transform.localRotation.eulerAngles.x,
			                                                                    90,
			                                                                    GameObject.Find ("LeftArm").transform.localRotation.eulerAngles.z);
			GameObject.Find ("Weapon").transform.localRotation.eulerAngles.Set(GameObject.Find ("Weapon").transform.localRotation.eulerAngles.x,
			                                                                   0,
			                                                                   GameObject.Find ("Weapon").transform.localRotation.eulerAngles.z);
			
			ResetPosAndRotAttack();
			
			currentAction = 0;
			currentlyActing = false;
		}
	}
	
	void ResetPosAndRotAttack()
	{
		GameObject.Find ("RightArm").transform.localPosition = startPosRightArm;
		GameObject.Find ("LeftArm").transform.localPosition = startPosLeftArm;
		GameObject.Find ("Weapon").transform.localPosition = startPosWeaponArm;
		GameObject.Find ("RightArm").transform.localRotation = startRotRightArm;
		GameObject.Find ("LeftArm").transform.localRotation = startRotLeftArm;
		GameObject.Find ("Weapon").transform.localRotation = startRotWeaponArm;
	}
	
	void ResetPosAndRotMovement()
	{
		GameObject.Find ("RightLeg").transform.localPosition = startPosRightLeg;
		GameObject.Find ("LeftLeg").transform.localPosition = startPosLeftLeg;
		GameObject.Find ("RightLeg").transform.localRotation = startRotRightLeg;
		GameObject.Find ("LeftLeg").transform.localRotation = startRotLeftLeg;
	}
}
