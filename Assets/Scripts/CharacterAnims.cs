using UnityEngine;
using System.Collections;

public class CharacterAnims : MonoBehaviour 
{
	float movementSpeed = 10f;
	float movementSpeedKeyboard = 0.2f;

	float rotationSpeed = 800;
	float moveRotationSpeed = 400;
	bool currentlyActing = false;
	int currentAction = 0;
	
	float spearSpeed = 5;
	float comboRotationSpeed = 800;
	
	Vector3 startPosLeftArm;
	Vector3 startPosRightArm;
	Vector3 startPosWeapon;
	Vector3 startPosRightLeg;
	Vector3 startPosLeftLeg;
	Vector3 startPosHead;
	Vector3 startPosTopBody;
	
	Quaternion startRotLeftArm;
	Quaternion startRotRightArm;
	Quaternion startRotWeapon;
	Quaternion startRotRightLeg;
	Quaternion startRotLeftLeg;
	Quaternion startRotHead;
	Quaternion startRotTopBody;
	
	bool movementSide = false;
	
	bool currentlyJumping = false;
	
	public AnimationCurve jumpCurve;
	float jumpTimer = 0.0f;
	float jumpSpeed = 2f;
	bool jumpDir = false;

	void Start() 
	{
		startPosLeftArm = GameObject.Find ("LeftArm").transform.localPosition;
		startPosRightArm = GameObject.Find ("RightArm").transform.localPosition;
		startPosWeapon = GameObject.Find ("Weapon").transform.localPosition;
		startPosRightLeg = GameObject.Find ("RightLeg").transform.localPosition;
		startPosLeftLeg = GameObject.Find ("LeftLeg").transform.localPosition;
		startPosHead = GameObject.Find ("Head").transform.localPosition;
		startPosTopBody = GameObject.Find ("TopBody").transform.localPosition;
		
		startRotLeftArm = GameObject.Find ("LeftArm").transform.localRotation;
		startRotRightArm = GameObject.Find ("RightArm").transform.localRotation;
		startRotWeapon = GameObject.Find ("Weapon").transform.localRotation;
		startRotRightLeg = GameObject.Find ("RightLeg").transform.localRotation;
		startRotLeftLeg = GameObject.Find ("LeftLeg").transform.localRotation;
		startRotHead = GameObject.Find ("Head").transform.localRotation;
		startRotTopBody = GameObject.Find ("TopBody").transform.localRotation;
	}

	void Update() 
	{
		if (!currentlyActing)
		{
			if (Input.GetKeyDown (KeyCode.Mouse0))
			{
				StartAttack1();
			}
			else if (Input.GetKeyDown (KeyCode.Mouse1))
			{
				StartAttack2();
			}
			else if (Input.GetKeyDown (KeyCode.Q))
			{
				StartAttack3();
			}
			else if (Input.GetKeyDown (KeyCode.E))
			{
				StartCombo();
			}
		}
		
		if (Input.GetKeyDown(KeyCode.Space))
		{
			StartJump();
		}
		
		bool tempMoving = false;
		
		if (Input.GetKey(KeyCode.W))
		{
			Vector3 tempMove = Vector3.forward;
			tempMove *= movementSpeedKeyboard;
			tempMoving = true;
			transform.Translate(tempMove);
		}
		
		if (Input.GetKey(KeyCode.S))
		{
			Vector3 tempMove = Vector3.forward;
			tempMove *= movementSpeedKeyboard;
			tempMoving = true;
			transform.Translate(-tempMove);
		}
		
		if (Input.GetKey(KeyCode.A))
		{
			tempMoving = true;
			transform.RotateAround(transform.position,
			                       new Vector3 (0, 1, 0),
			                       -moveRotationSpeed * Time.deltaTime);
		}
		
		if (Input.GetKey(KeyCode.D))
		{
			tempMoving = true;
			transform.RotateAround(transform.position,
			                       new Vector3 (0, 1, 0),
			                       moveRotationSpeed * Time.deltaTime);
		}

		/*   Movements avec game pad   */
		float translation = Input.GetAxis("Vertical") * movementSpeed;
		float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
		translation *= Time.deltaTime;

		if(translation != 0.0f)
		{
			tempMoving = true;
		}
		rotation *= Time.deltaTime;
		transform.Translate(0, 0, translation);
		transform.Rotate(0, rotation, 0);



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
				case (6):
					SetAttack3();
					break;
				case (7):
					Attack3();
					break;
				case (8):
					Comeback3();
					break;
				case (9):
					Combo();
					break;
			}
		}
		
		if (currentlyJumping)
		{
			Jump();
		}
	}

	internal void StartAttack1()
	{
		if (!currentlyActing)
		{
			currentlyActing = true;
			currentAction = 1;
		}
	}
	
	internal void StartAttack2()
	{
		if (!currentlyActing)
		{
			currentlyActing = true;
			currentAction = 3;
		}
	}
	
	internal void StartAttack3()
	{
		if (!currentlyActing)
		{
			currentlyActing = true;
			currentAction = 6;
		}
	}
	
	internal void StartCombo()
	{
		currentlyActing = true;
		currentAction = 9;
	}
	
	internal void StartJump()
	{
		currentlyJumping = true;
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
		GameObject.Find ("LeftArm").transform.localPosition = new Vector3(GameObject.Find ("RightArm").transform.localPosition.x,
																			 GameObject.Find ("RightArm").transform.localPosition.y + 0.5f,
		                                                                  GameObject.Find ("RightArm").transform.localPosition.z);
		GameObject.Find ("Weapon").transform.localEulerAngles = new Vector3(0,
		                                                                    0,
		                                                                    0);
		GameObject.Find ("Weapon").transform.localPosition = new Vector3(GameObject.Find ("RightArm").transform.localPosition.x,
		                                                                  GameObject.Find ("RightArm").transform.localPosition.y + 0.5f,
		                                                                  GameObject.Find ("RightArm").transform.localPosition.z + 0.4f);
		                                                   
		currentAction = 4;                                                                   
	}
	
	void Attack2()
	{
		GameObject.Find ("RightArm").transform.RotateAround(GameObject.Find ("TopBody").transform.position,
		                                                    transform.right,
		                                                    rotationSpeed * Time.deltaTime);
		GameObject.Find ("LeftArm").transform.RotateAround(GameObject.Find ("TopBody").transform.position,
		                                                   transform.right,
		                                                   rotationSpeed * Time.deltaTime);
		GameObject.Find ("Weapon").transform.RotateAround(GameObject.Find ("TopBody").transform.position,
		                                                  transform.right,
		                                                  rotationSpeed * Time.deltaTime);
		
		if (GameObject.Find ("RightArm").transform.localRotation.eulerAngles.z >= 180)
		{
			GameObject.Find ("RightArm").transform.localRotation.eulerAngles.Set(GameObject.Find ("RightArm").transform.localRotation.eulerAngles.x,
			                                                                     GameObject.Find ("RightArm").transform.localRotation.eulerAngles.y,
			                                                                     180);
			GameObject.Find ("LeftArm").transform.localRotation.eulerAngles.Set(GameObject.Find ("LeftArm").transform.localRotation.eulerAngles.x,
			                                                                    GameObject.Find ("LeftArm").transform.localRotation.eulerAngles.z,
			                                                                    180);
			GameObject.Find ("Weapon").transform.localRotation.eulerAngles.Set(GameObject.Find ("Weapon").transform.localRotation.eulerAngles.x,
			                                                                   GameObject.Find ("Weapon").transform.localRotation.eulerAngles.z,
			                                                                   90);
			currentAction = 5;
		}
	}
	
	void Comeback2()
	{
		GameObject.Find ("RightArm").transform.RotateAround(GameObject.Find ("TopBody").transform.position,
		                                                    transform.right,
		                                                    -rotationSpeed * Time.deltaTime);
		GameObject.Find ("LeftArm").transform.RotateAround(GameObject.Find ("TopBody").transform.position,
		                                                   transform.right,
		                                                   -rotationSpeed * Time.deltaTime);
		GameObject.Find ("Weapon").transform.RotateAround(GameObject.Find ("TopBody").transform.position,
		                                                  transform.right,
		                                                  -rotationSpeed * Time.deltaTime);
		
		if (GameObject.Find ("RightArm").transform.localRotation.eulerAngles.z <= 90)
		{
			GameObject.Find ("RightArm").transform.localRotation.eulerAngles.Set(GameObject.Find ("RightArm").transform.localRotation.eulerAngles.x,
			                                                                     GameObject.Find ("RightArm").transform.localRotation.eulerAngles.z,
			                                                                     90);
			GameObject.Find ("LeftArm").transform.localRotation.eulerAngles.Set(GameObject.Find ("LeftArm").transform.localRotation.eulerAngles.x,
			                                                                    GameObject.Find ("LeftArm").transform.localRotation.eulerAngles.z,
			                                                                    90);
			GameObject.Find ("Weapon").transform.localRotation.eulerAngles.Set(GameObject.Find ("Weapon").transform.localRotation.eulerAngles.x,
			                                                                   GameObject.Find ("Weapon").transform.localRotation.eulerAngles.z,
			                                                                   0);
			
			ResetPosAndRotAttack();
			
			currentAction = 0;
			currentlyActing = false;
		}
	}
	
	void SetAttack3()
	{
		GameObject.Find ("LeftArm").transform.localPosition = new Vector3(GameObject.Find ("RightArm").transform.localPosition.x,
		                                                                  GameObject.Find ("RightArm").transform.localPosition.y,
		                                                                  GameObject.Find ("RightArm").transform.localPosition.z);
		GameObject.Find ("Weapon").transform.localEulerAngles = new Vector3(GameObject.Find ("Weapon").transform.localRotation.eulerAngles.x,
		                                                                    90,
		                                                                    GameObject.Find ("Weapon").transform.localRotation.eulerAngles.z);
		GameObject.Find ("Weapon").transform.localPosition = new Vector3(GameObject.Find ("RightArm").transform.localPosition.x,
		                                                                 GameObject.Find ("RightArm").transform.localPosition.y,
		                                                                 GameObject.Find ("RightArm").transform.localPosition.z + 1f);
		
		currentAction = 7;                                                                   
	}
	
	void Attack3()
	{
		GameObject.Find ("RightArm").transform.Translate(new Vector3(0, spearSpeed * Time.deltaTime, 0));
		GameObject.Find ("LeftArm").transform.Translate(new Vector3(0, spearSpeed * Time.deltaTime, 0));
		GameObject.Find ("Weapon").transform.Translate(new Vector3(0, spearSpeed * Time.deltaTime, 0));
		
		if (GameObject.Find ("RightArm").transform.localPosition.z >= 1)
		{
			currentAction = 8;
		}
	}
	
	void Comeback3()
	{
		GameObject.Find ("RightArm").transform.Translate(new Vector3(0, -spearSpeed * Time.deltaTime, 0));
		GameObject.Find ("LeftArm").transform.Translate(new Vector3(0, -spearSpeed * Time.deltaTime, 0));
		GameObject.Find ("Weapon").transform.Translate(new Vector3(0, -spearSpeed * Time.deltaTime, 0));
		
		if (GameObject.Find ("RightArm").transform.localPosition.z <= 0)
		{
			ResetPosAndRotAttack();
			
			currentAction = 0;
			currentlyActing = false;
		}
	}
	
	void Combo()
	{
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("combomembers"))
		{
			obj.transform.RotateAround(this.transform.position, new Vector3(0, 1, 0), comboRotationSpeed * Time.deltaTime);
		}
		
		if (GameObject.Find("Weapon").transform.localRotation.eulerAngles.y > 330 && GameObject.Find("Weapon").transform.localRotation.eulerAngles.y < 360)
		{
			ResetPosAndRotAttack();
			ResetPosAndRotBody();
			currentAction = 0;
			currentlyActing = false;
		}
	}
	
	void Jump()
	{
		if (jumpTimer >= 0.5f && !jumpDir)
		{
			jumpDir = true;
		}
		else if (jumpTimer <= 0.2f && jumpDir)
		{
			currentlyJumping = false;
			jumpDir = false;
			jumpTimer = 0.0f;
		}
		
		Vector3 newPosTemp = this.transform.position;
		
		if (!jumpDir)
		{
			jumpTimer += Time.deltaTime * jumpSpeed;
			newPosTemp.y += jumpCurve.Evaluate(jumpTimer);
		}
		else if (jumpDir)
		{
			jumpTimer -= Time.deltaTime * jumpSpeed;
			newPosTemp.y -= jumpCurve.Evaluate(jumpTimer);
		}
		
		this.transform.position = newPosTemp;
	}
	
	void ResetPosAndRotAttack()
	{
		GameObject.Find ("RightArm").transform.localPosition = startPosRightArm;
		GameObject.Find ("LeftArm").transform.localPosition = startPosLeftArm;
		GameObject.Find ("Weapon").transform.localPosition = startPosWeapon;
		GameObject.Find ("RightArm").transform.localRotation = startRotRightArm;
		GameObject.Find ("LeftArm").transform.localRotation = startRotLeftArm;
		GameObject.Find ("Weapon").transform.localRotation = startRotWeapon;
	}
	
	void ResetPosAndRotBody()
	{
		GameObject.Find ("Head").transform.localPosition = startPosHead;
		GameObject.Find ("TopBody").transform.localPosition = startPosTopBody;
		GameObject.Find ("Head").transform.localRotation = startRotHead;
		GameObject.Find ("TopBody").transform.localRotation = startRotTopBody;
	}
	
	void ResetPosAndRotMovement()
	{
		GameObject.Find ("RightLeg").transform.localPosition = startPosRightLeg;
		GameObject.Find ("LeftLeg").transform.localPosition = startPosLeftLeg;
		GameObject.Find ("RightLeg").transform.localRotation = startRotRightLeg;
		GameObject.Find ("LeftLeg").transform.localRotation = startRotLeftLeg;
	}
}
