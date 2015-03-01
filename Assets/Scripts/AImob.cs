using UnityEngine;
using System.Collections;

public class AImob : MonoBehaviour {

	public float speed;
	private float attackTimer;
	private float timer;

	private bool canAtack;

	private int health;
	
	void Start () 
	{
		health = 3;
		attackTimer = 1.0f;
		timer = 0.0f;

		canAtack = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log(canAtack);
		if(!canAtack)
		{
			canAtack = false;
			timer += Time.deltaTime;
			if(timer >= attackTimer)
			{
				canAtack = true;
				timer = 0.0f;
			}
		}

		if(getHealth() <= 0)
		{
			die ();
		}

		if(canAtack)
		{
			Ray ray = new Ray(transform.position + transform.forward  + new Vector3(0f, 1f, -0.75f), transform.forward);
			RaycastHit hit = new RaycastHit();
			Debug.DrawRay(ray.origin, ray.direction, Color.red);
			if (Physics.Raycast(ray, out hit, 1f))
			{
				if(hit.collider.GetType() == typeof(CapsuleCollider) && hit.collider.gameObject.name == "Character")
				{
					hit.collider.gameObject.GetComponent<Pushback>().PushEnemy();
					hit.collider.gameObject.GetComponent<PlayerGetDamaged>().PlayerDamaged();

					this.GetComponent<MobAttack>().EnemyAttackAnim();

					canAtack = false;
				}
			}
		}
	}

	void OnTriggerStay(Collider other)
	{
		float step = speed * Time.deltaTime;
		if(other.name == "Character")
		{
			if(!GetComponent<Pushback>().pushBacking)
			{
				float x = other.transform.position.x;
				float y = other.transform.position.y;
				float z = other.transform.position.z;

				float rotationSpeed = 100f;

				Vector3 direction = new Vector3(x,y,z);
				Quaternion rotation = Quaternion.LookRotation(direction - transform.position);

				if((direction - transform.position).magnitude >= 0.5f)
				{
					transform.position = Vector3.MoveTowards(transform.position, direction, step);

					if(this.gameObject.name == "Clown(Clone)" || this.gameObject.name == "Dog(Clone)")
					{
						//Y est a vérifier
						Vector3 directionSameY = new Vector3(direction.x,transform.position.y, direction.z);
						rotation = Quaternion.LookRotation(transform.position - directionSameY);
						
						transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
					}
					else
					{
						transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
					}
				}

				//transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);


			}
		}
	}

	public void setHalth(int value)
	{
		health = value;
	}

	public void doDamage(int value)
	{
		health -= value;
	}

	public int getHealth()
	{
		return health;
	}

	private void die()
	{
		Destroy(this.gameObject);
		Destroy(this);
	}
}
