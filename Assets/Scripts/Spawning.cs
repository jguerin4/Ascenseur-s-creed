using UnityEngine;
using System.Collections;
using System.Timers;
using System;

public class Spawning : MonoBehaviour {

	public GameObject clown;
	public GameObject spider;
	public GameObject dog;

	public GameObject SpawningReferenceGO;

	static public Vector3 SpawnRef;

	static public System.Random m_random;

	static public int m_numberOfMobs = 0;

	private Terrain terr;

	void Start() {
	}
	
	// Update is called once per frame
	void Update () {
		if(m_numberOfMobs <= 30)
		{
			spawnNewMob(40,100,40,100);
			Debug.Log("Spawning");
		}

	}


	void spawnNewMob(int xMin, int xMax, int zMin, int zMax)
	{
		terr = Terrain.FindObjectOfType<Terrain>();
		Terrain.activeTerrain.heightmapMaximumLOD = 0;
		SpawnRef = SpawningReferenceGO.transform.position;

		m_random = new System.Random(Environment.TickCount);
		int x = m_random.Next(xMin, xMax);
		m_random = new System.Random(Environment.TickCount);
		int z = m_random.Next(zMin, zMax);
		
		int inverseX = m_random.Next(0,2);
		m_random = new System.Random(Environment.TickCount);
		int inverseZ = m_random.Next(0,2);
		m_random = new System.Random(Environment.TickCount);
		int getEnnemyType = m_random.Next(1,4);

		if(inverseX == 1)	//Une chance sur deux d'inverser, pour faire un cercle
		{
			x *= -1;
		}
		if(inverseZ == 1)
		{
			z *= -1;
		}
		float xSpawnPosition = x + SpawnRef.x;	//Position relative au personnages (selon main caméra)
		float ySpawnPosition= 2.5f;
		float zSpawnPosition = SpawnRef.z + z;

		float currentHeight = terr.SampleHeight(new Vector3(xSpawnPosition,ySpawnPosition,zSpawnPosition));
		//Debug.Log("Hauteur relative: " + currentHeight.ToString());
		
		float testCollisionRadius = 0.8f;
		Vector3 centerTestCollision = new Vector3(xSpawnPosition,ySpawnPosition+1,zSpawnPosition);
		
		Collider [] hitCollider = Physics.OverlapSphere(centerTestCollision, testCollisionRadius);
		
		
		if(currentHeight > 0 || hitCollider.GetLength(0) > 0 || xSpawnPosition > 2000 || zSpawnPosition > 2000 || xSpawnPosition < 0 || zSpawnPosition < 0)
		{
			getEnnemyType = 999;	//Ne spawn pas
			//Debug.Log("Hauteur: " + currentHeight + " Number of hit Collider: " + hitCollider.GetLength(0) + " Position : " + centerTestCollision.x + " " + centerTestCollision.z);
		}                     
		
		
		switch(getEnnemyType)	//Chance égale de spawner chaque mobs
		{
		case 1:
			
			Instantiate(dog, new Vector3(xSpawnPosition, ySpawnPosition, zSpawnPosition), dog.transform.rotation);
			m_numberOfMobs++;
			//Debug.Log("NumberOfMob = " + m_numberOfMobs);
			
			break;
			
		case 2:
			
			Instantiate(clown, new Vector3(xSpawnPosition, ySpawnPosition, zSpawnPosition), clown.transform.rotation);
			m_numberOfMobs++;
			//Debug.Log("NumberOfMob = " + m_numberOfMobs);
			break;
			
		case 3:
			
			Instantiate(spider, new Vector3(xSpawnPosition, ySpawnPosition - 2.6f, zSpawnPosition), dog.transform.rotation);
			m_numberOfMobs++;
			//Debug.Log("NumberOfMob = " + m_numberOfMobs);
			break;
			
		default:
			//Debug.Log("Respawning object, too high or on unavailable spot.);
			break;
		}
		
		
		
	}

}
