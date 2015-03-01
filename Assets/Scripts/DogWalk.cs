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
			transform.FindChild("Body/Leg1").RotateAround(transform.FindChild ("Body/LowBodyDogFront").transform.position,
			                                                    transform.right,
			                                                moveRotationSpeed * Time.deltaTime);
			transform.FindChild("Body/Leg4").transform.RotateAround(transform.FindChild ("Body/LowBodyDogBack").transform.position,
			                                                transform.right,
			                                                moveRotationSpeed * Time.deltaTime);
			transform.FindChild("Body/Leg2").transform.RotateAround(transform.FindChild ("Body/LowBodyDogFront").transform.position,
			                                                transform.right,
			                                                -moveRotationSpeed * Time.deltaTime);
			transform.FindChild("Body/Leg3").transform.RotateAround(transform.FindChild ("Body/LowBodyDogBack").transform.position,
			                                                transform.right,
			                                                -moveRotationSpeed * Time.deltaTime);
		}
		else
		{
			transform.FindChild ("Body/Leg1").transform.RotateAround(transform.FindChild ("Body/LowBodyDogFront").transform.position,
			                                                transform.right,
			                                                -moveRotationSpeed * Time.deltaTime);
			transform.FindChild ("Body/Leg4").transform.RotateAround(transform.FindChild ("Body/LowBodyDogBack").transform.position,
			                                                transform.right,
			                                                -moveRotationSpeed * Time.deltaTime);
			transform.FindChild ("Body/Leg2").transform.RotateAround(transform.FindChild ("Body/LowBodyDogFront").transform.position,
			                                                transform.right,
			                                                moveRotationSpeed * Time.deltaTime);
			transform.FindChild ("Body/Leg3").transform.RotateAround(transform.FindChild ("Body/LowBodyDogBack").transform.position,
			                                                transform.right,
			                                                moveRotationSpeed * Time.deltaTime);
		}
		
		if (transform.FindChild ("Body/Leg1").transform.localRotation.eulerAngles.x <= 300 &&
		    transform.FindChild ("Body/Leg1").transform.localRotation.eulerAngles.x > 270 &&
		    !movementSide)
		{
			movementSide = true;
		}
		else if (transform.FindChild ("Body/Leg1").transform.localRotation.eulerAngles.x >= 60 &&
		         transform.FindChild ("Body/Leg1").transform.localRotation.eulerAngles.x < 90 &&
		         movementSide)
		{
			movementSide = false;
		}
		
	}
}
