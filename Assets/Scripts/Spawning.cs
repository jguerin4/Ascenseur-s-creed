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
	}
	
	// Update is called once per frame
	void Update () {
	
		if(m_numberOfMobs <= 10)
		{
			m_random = new System.Random();
			spawnNewMob();
		}

	}

	void spawnNewMob()
	{
		terr = Terrain.FindObjectOfType<Terrain>();
		float heightmapWidth = terr.terrainData.heightmapWidth;
		float heightmapHeight = terr.terrainData.heightmapHeight;
		Terrain.activeTerrain.heightmapMaximumLOD = 0;


		m_random = new System.Random();

		SpawnRef = SpawningReferenceGO.transform.position;

		int x = m_random.Next(20, 50);
		int z = m_random.Next(20, 50);

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

		float xSpawnPosition = x + SpawnRef.x;	//Position relative au personnages (selon main caméra)
		float ySpawnPosition;
		float zSpawnPosition = SpawnRef.z + z;

		//float[,] heights = terr.terrainData.GetHeights((int)(xSpawnPosition),(int)(zSpawnPosition),1,1);

		//Debug.Log(heights.ToString());
		ySpawnPosition = 2f;


		float currentHeight;


		currentHeight = terr.SampleHeight(new Vector3(xSpawnPosition,ySpawnPosition,zSpawnPosition));
		//Debug.Log("Hauteur relative: " + currentHeight.ToString());

		if(currentHeight != 0)
		{
			getEnnemyType = 999;
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
			//Debug.Log("Respawning object, too high);
			break;
		}



	}

}
