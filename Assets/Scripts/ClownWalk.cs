using UnityEngine;
using System.Collections;

public class ClownWalk : MonoBehaviour
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
			transform.FindChild ("Body/Rightleg").transform.RotateAround(transform.FindChild ("Body/LowBodyClown").transform.position,
			                                                    transform.right,
			                                                    moveRotationSpeed * Time.deltaTime);
			transform.FindChild ("Body/Leftleg").transform.RotateAround(transform.FindChild ("Body/LowBodyClown").transform.position,
			                                                   transform.right,
			                                                   -moveRotationSpeed * Time.deltaTime);
		}
		else
		{
			transform.FindChild ("Body/Rightleg").transform.RotateAround(transform.FindChild ("Body/LowBodyClown").transform.position,
			                                                    transform.right,
			                                                    -moveRotationSpeed * Time.deltaTime);
			transform.FindChild ("Body/Leftleg").transform.RotateAround(transform.FindChild ("Body/LowBodyClown").transform.position,
			                                                   transform.right,
			                                                   moveRotationSpeed * Time.deltaTime);
		}
		
		if (transform.FindChild ("Body/Rightleg").transform.localRotation.eulerAngles.x <= 300 &&
		    transform.FindChild ("Body/Rightleg").transform.localRotation.eulerAngles.x > 270 &&
		    !movementSide)
		{
			movementSide = true;
		}
		else if (transform.FindChild ("Body/Rightleg").transform.localRotation.eulerAngles.x >= 60 &&
		         transform.FindChild ("Body/Rightleg").transform.localRotation.eulerAngles.x < 90 &&
		         movementSide)
		{
			movementSide = false;
		}
		
	}
}
