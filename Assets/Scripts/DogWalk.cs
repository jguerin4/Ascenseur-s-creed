using UnityEngine;
using System.Collections;

public class DogWalk : MonoBehaviour 
{
	bool movementSide = false;
	float moveRotationSpeed = 400;
	
	void Start() 
	{
		
	}
	
	void Update() 
	{
		if (GetComponent<AImob>().moving)
		{
			Movement();
		}
	}
	
	void Movement()
	{
		if (!movementSide)
		{
			GameObject.Find ("Leg1").transform.RotateAround(GameObject.Find ("LowBodyDogFront").transform.position,
			                                                    transform.right,
			                                                moveRotationSpeed * Time.deltaTime);
			GameObject.Find ("Leg4").transform.RotateAround(GameObject.Find ("LowBodyDogBack").transform.position,
			                                                transform.right,
			                                                moveRotationSpeed * Time.deltaTime);
			GameObject.Find ("Leg2").transform.RotateAround(GameObject.Find ("LowBodyDogFront").transform.position,
			                                                transform.right,
			                                                -moveRotationSpeed * Time.deltaTime);
			GameObject.Find ("Leg3").transform.RotateAround(GameObject.Find ("LowBodyDogBack").transform.position,
			                                                transform.right,
			                                                -moveRotationSpeed * Time.deltaTime);
		}
		else
		{
			GameObject.Find ("Leg1").transform.RotateAround(GameObject.Find ("LowBodyDogFront").transform.position,
			                                                transform.right,
			                                                -moveRotationSpeed * Time.deltaTime);
			GameObject.Find ("Leg4").transform.RotateAround(GameObject.Find ("LowBodyDogBack").transform.position,
			                                                transform.right,
			                                                -moveRotationSpeed * Time.deltaTime);
			GameObject.Find ("Leg2").transform.RotateAround(GameObject.Find ("LowBodyDogFront").transform.position,
			                                                transform.right,
			                                                moveRotationSpeed * Time.deltaTime);
			GameObject.Find ("Leg3").transform.RotateAround(GameObject.Find ("LowBodyDogBack").transform.position,
			                                                transform.right,
			                                                moveRotationSpeed * Time.deltaTime);
		}
		
		if (GameObject.Find ("Leg1").transform.localRotation.eulerAngles.x <= 300 &&
		    GameObject.Find ("Leg1").transform.localRotation.eulerAngles.x > 270 &&
		    !movementSide)
		{
			movementSide = true;
		}
		else if (GameObject.Find ("Leg1").transform.localRotation.eulerAngles.x >= 60 &&
		         GameObject.Find ("Leg1").transform.localRotation.eulerAngles.x < 90 &&
		         movementSide)
		{
			movementSide = false;
		}
		
	}
}
