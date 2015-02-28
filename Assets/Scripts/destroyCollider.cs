using UnityEngine;
using System.Collections;

public class destroyCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.name == "Bob")
		{
			Spawning.m_numberOfMobs--;
			Debug.Log(other.name);
			Destroy(transform.parent.gameObject);
			Destroy(this);
		}
	}
}
