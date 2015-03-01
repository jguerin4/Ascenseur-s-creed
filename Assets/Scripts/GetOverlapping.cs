using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetOverlapping : MonoBehaviour {
	public List<GameObject> enemyList;
	public int nbCol;

	void Start () 
	{
		enemyList = new List<GameObject>();
		nbCol = 0;
	}

	void Update()
	{
		transform.position = GameObject.Find("Character").transform.position;
		
		if (nbCol == 0)
		{
			GameObject.Find ("ComboCollider").GetComponent<GetOverlapping>().enemyList.Clear ();
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if((col.tag == "Spider" || col.tag == "Dog" || col.tag == "Clown") && col.GetType() == typeof(CapsuleCollider))
		{
			this.enemyList.Add(col.gameObject);
			nbCol++;
		}
	}
	
	void OnTriggerExit(Collider col)
	{
		if((col.tag == "Spider" || col.tag == "Dog" || col.tag == "Clown") && col.GetType() == typeof(CapsuleCollider))
		{
			this.enemyList.Remove(col.gameObject);
			nbCol--;
		}
	}
}
