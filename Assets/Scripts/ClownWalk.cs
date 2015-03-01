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
			GameObject.Find ("Rightleg").transform.RotateAround(GameObject.Find ("LowBodyClown").transform.position,
			                                                    transform.right,
			                                                    moveRotationSpeed * Time.deltaTime);
			GameObject.Find ("Leftleg").transform.RotateAround(GameObject.Find ("LowBodyClown").transform.position,
			                                                   transform.right,
			                                                   -moveRotationSpeed * Time.deltaTime);
		}
		else
		{
			GameObject.Find ("Rightleg").transform.RotateAround(GameObject.Find ("LowBodyClown").transform.position,
			                                                    transform.right,
			                                                    -moveRotationSpeed * Time.deltaTime);
			GameObject.Find ("Leftleg").transform.RotateAround(GameObject.Find ("LowBodyClown").transform.position,
			                                                   transform.right,
			                                                   moveRotationSpeed * Time.deltaTime);
		}
		
		if (GameObject.Find ("Rightleg").transform.localRotation.eulerAngles.x <= 300 &&
		    GameObject.Find ("Rightleg").transform.localRotation.eulerAngles.x > 270 &&
		    !movementSide)
		{
			movementSide = true;
		}
		else if (GameObject.Find ("Rightleg").transform.localRotation.eulerAngles.x >= 60 &&
		         GameObject.Find ("Rightleg").transform.localRotation.eulerAngles.x < 90 &&
		         movementSide)
		{
			movementSide = false;
		}
		
	}
}
