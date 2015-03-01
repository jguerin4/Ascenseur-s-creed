using UnityEngine;
using System.Collections;

public class Grotte : MonoBehaviour {

	MasterObjectifs Obj_Master;
	// Use this for initialization
	void Start () {
		
		Obj_Master = GameObject.Find("MasterObjectif").GetComponent<MasterObjectifs>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			Obj_Master.discovert();
			Destroy(gameObject);
		}
	}
}
