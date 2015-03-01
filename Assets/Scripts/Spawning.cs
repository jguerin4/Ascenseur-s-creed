using UnityEngine;
using System.Collections;
using System.Timers;
using System;

public class Spawning : MonoBehaviour {

	public Transform clown;
	public Transform spider;
	public Transform dog;

	public GameObject SpawningReferenceGO;

	static public Vector3 SpawnRef;

	static public System.Random m_random;

	static public int m_numberOfMobs = 0;

	private Terrain terr;

	void Start() {
		while(m_numberOfMobs <= 2)
		{
			spawnNewMob(30,60,30,60);
			Debug.Log("Nombre de mob: " + m_numberOfMobs);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(m_numberOfMobs <= 20)
		{
			spawnNewMob(40,100,40,100);
		}

	}


	void spawnNewMob(int xMin, int xMax, int zMin, int zMax)
	{
		terr = Terrain.FindObjectOfType<Terrain>();
		float heightmapWidth = terr.terrainData.heightmapWidth;
		float heightmapHeight = terr.terrainData.heightmapHeight;
		Terrain.activeTerrain.heightmapMaximumLOD = 0;
		
		m_random = new System.Random(Environment.TickCount);
		
		SpawnRef = SpawningReferenceGO.transform.position;
		
		int x = m_random.Next(xMin, xMax);
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
		float ySpawnPosition;
		float zSpawnPosition = SpawnRef.z + z;
		
		//float[,] heights = terr.terrainData.GetHeights((int)(xSpawnPosition),(int)(zSpawnPosition),1,1);
		
		//Debug.Log(heights.ToString());
		ySpawnPosition = 2f;
		
		
		float currentHeight;
		
		
		currentHeight = terr.SampleHeight(new Vector3(xSpawnPosition,ySpawnPosition,zSpawnPosition));
		//Debug.Log("Hauteur relative: " + currentHeight.ToString());
		
		float testCollisionRadius = 0.5f;
		Vector3 centerTestCollision = new Vector3(xSpawnPosition,ySpawnPosition+1,zSpawnPosition);
		
		Collider [] hitCollider = Physics.OverlapSphere(centerTestCollision, testCollisionRadius);
		
		
		if(currentHeight > 0 || hitCollider.GetLength(0) > 1)
		{
			getEnnemyType = 999;	//Ne spawn pas
			Debug.Log("Hauteur: " + currentHeight + " Number of hit Collider: " + hitCollider.GetLength(0));
		}                     
		
		
		switch(getEnnemyType)	//Chance égale de spawner chaque mobs
		{
		case 1:
			
			Instantiate(dog, new Vector3(xSpawnPosition, ySpawnPosition, zSpawnPosition), Quaternion.identity);
			m_numberOfMobs++;
			//Debug.Log("NumberOfMob = " + m_numberOfMobs);
			
			break;
			
		case 2:
			
			Instantiate(clown, new Vector3(xSpawnPosition, ySpawnPosition, zSpawnPosition), Quaternion.identity);
			m_numberOfMobs++;
			//Debug.Log("NumberOfMob = " + m_numberOfMobs);
			break;
			
		case 3:
			
			Instantiate(spider, new Vector3(xSpawnPosition, ySpawnPosition - 2.6f, zSpawnPosition), Quaternion.identity);
			m_numberOfMobs++;
			//Debug.Log("NumberOfMob = " + m_numberOfMobs);
			break;
			
		default:
			//Debug.Log("Respawning object, too high or on unavailable spot.);
			break;
		}
		
		
		
	}

}
