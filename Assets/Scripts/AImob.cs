using UnityEngine;
using System.Collections;

public class AImob : MonoBehaviour {

	public float speed;
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other)
	{
		float step = speed * Time.deltaTime;
		if(other.name == "Character")
		{
			//Debug.Log("lol");
			float x = other.transform.position.x;
			float y = other.transform.position.y;
			float z = other.transform.position.z;

			Vector3 mobDirection = new Vector3(x,y,z);

			if((mobDirection - transform.parent.transform.position).magnitude >= 3f)
			{
				transform.parent.position = Vector3.MoveTowards(transform.parent.position, mobDirection, step);
			}
		}
	}


}
