using UnityEngine;
using System.Collections;

public class AImob : MonoBehaviour {

	public float speed;

	private bool canAtack;
	private BoxCollider collide;

	private int health;
	
	void Start () 
	{
		health = 3;

		collide = gameObject.GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(getHealth() <= 0)
		{
			die ();
		}

		Ray ray = new Ray(transform.position + transform.forward * 1.2f, transform.forward);
		RaycastHit hit;

		Debug.DrawRay(ray.origin, ray.direction, Color.red);
		if (Physics.Raycast(ray, out hit))
		{
			if(hit.collider.GetType() == typeof(CapsuleCollider))
			{
				//hit.collider.gameObject.GetComponent<Pushback>().PushEnemy();
				canAtack = true;
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

				if((direction - transform.position).magnitude >= 2f)
				{
					transform.position = Vector3.MoveTowards(transform.position, direction, step);
				}

				//transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);

				if(this.gameObject.name == "Clown(Clone)" || this.gameObject.name == "Dog(Clone)")
				{/*
					Quaternion source = transform.rotation;
					Quaternion source2 = transform.rotation;
					source.SetFromToRotation(new Vector3(source.x,source.y,source.z),new Vector3(0,180,0));
					transform.rotation = Quaternion.Slerp(source, rotation, Time.deltaTime * rotationSpeed);*/
					Vector3 direction180y = new Vector3(direction.x,direction.y, direction.z);
					rotation = Quaternion.LookRotation(direction180y - transform.position);
					transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
				}
				else
				{
					transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
				}
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
