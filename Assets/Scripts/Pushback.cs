using UnityEngine;
using System.Collections;

public class Pushback : MonoBehaviour 
{
	float timer = 0.0f;
	internal bool pushBacking = false;
	float speed = 5f;

	void Start() 
	{
	}
	
	void Update() 
	{
		if (pushBacking)
		{
			if (timer >= 1f)
			{
				pushBacking = false;
				transform.position += -transform.forward * Time.deltaTime * 50;
			}
			
			timer += Time.deltaTime * speed;
			
			Vector3 newPosTemp = this.transform.position;
			newPosTemp -= transform.forward * (timer * 0.2f);
			newPosTemp.y = 1 * Mathf.Sin(Mathf.PI * timer);
			
			this.transform.position = newPosTemp;
		}
	}
	
	internal void PushEnemy()
	{
		timer = 0.0f;
		pushBacking = true;
	}
}
