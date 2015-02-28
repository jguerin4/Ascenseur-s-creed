using UnityEngine;
using System.Collections;

public class MobAttack : MonoBehaviour 
{
	float timer = 0.0f;
	internal bool attacking = false;
	float speed = 5f;
	
	void Start() 
	{
	}
	
	void Update() 
	{
		if (attacking)
		{
			timer += Time.deltaTime * speed;
			
			Vector3 newPosTemp = this.transform.position;
			newPosTemp.y = 0.5f * Mathf.Sin(Mathf.PI * timer);
			
			this.transform.position = newPosTemp;
			
			if (timer >= 1f)
			{
				attacking = false;
			}
		}
	}
	
	internal void EnemyAttackAnim()
	{
		timer = 0.0f;
		attacking = true;
	}
}
