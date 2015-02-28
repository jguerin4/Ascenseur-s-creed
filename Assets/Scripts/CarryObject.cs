using UnityEngine;
using System.Collections;

public class CarryObject : MonoBehaviour {

	MasterObjectif Obj_Master;
	// Use this for initialization
	void Start () {
	
		Obj_Master = GameObject.Find("MasterObjectif").GetComponent<MasterObjectif>();
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("collision");
		if (other.gameObject.tag == "Player") {
			Obj_Master.carry();
			Destroy(gameObject);
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
