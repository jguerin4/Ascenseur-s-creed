using UnityEngine;
using System.Collections;
using System.Timers;
using System;

public class Spawning : MonoBehaviour {

	public Transform clown;
	public Transform spider;
	public Transform dog;

	static public Vector3 mainCameraPosition;

	static public System.Random m_random;

	static public int m_numberOfMobs = 0;

	void Start() {
	}
	
	// Update is called once per frame
	void Update () {
	
		if(m_numberOfMobs <= 15)
		{
			m_random = new System.Random();
			spawnNewMob();
		}

	}

	void spawnNewMob()
	{
		mainCameraPosition = Camera.main.gameObject.transform.position;

		int x = m_random.Next(10, 25);
		int z = m_random.Next(10, 25);

		int inverseX = m_random.Next(0,2);
		int inverseZ = m_random.Next(0,2);
		int getEnnemyType = m_random.Next(1,4);




		if(inverseX == 1)	//Une chance sur deux d'inverser, pour faire un cercle
		{
			x *= -1;
		}
		if(inverseZ == 1)
		{
			z *= -1;
		}

		float xSpawnPosition = x + mainCameraPosition.x;	//Position relative au personnages (selon main caméra)
		float ySpawnPosition = 2f;
		float zSpawnPosition = mainCameraPosition.z + z;

		switch(getEnnemyType)	//Chance égale de spawner chaque mobs
		{
		case 1:
			GameObject newDog = Instantiate(dog, new Vector3(xSpawnPosition, ySpawnPosition, zSpawnPosition), Quaternion.identity) as GameObject;
			break;
			
		case 2:
			GameObject newClown = Instantiate(clown, new Vector3(xSpawnPosition, ySpawnPosition, zSpawnPosition), Quaternion.identity) as GameObject;
			break;
			
		case 3:
			GameObject newSpider = Instantiate(spider, new Vector3(xSpawnPosition, ySpawnPosition, zSpawnPosition), Quaternion.identity) as GameObject;
			break;
		}

		m_numberOfMobs++;
		//Debug.Log("NumberOfMob = " + m_numberOfMobs);

	}

}
