using UnityEngine;
using System.Collections;

public class AImob : MonoBehaviour {

	public float speed;
	public Vector3 mainCamPosition;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other)
	{

		mainCamPosition = Camera.main.gameObject.transform.position;

		float step = speed * Time.deltaTime;
		if(other.name == "Bob")
		{
			float xCamera = mainCamPosition.x;
			float yCamera = mainCamPosition.y;
			float zCamera = mainCamPosition.z;

			Vector3 mobDirection = new Vector3(xCamera,yCamera,zCamera);

			transform.position = Vector3.MoveTowards(transform.position,mobDirection,step);

		}
	}


}
