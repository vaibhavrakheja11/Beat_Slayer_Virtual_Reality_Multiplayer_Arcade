using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnner : MonoBehaviour
{
	public GameObject[] spawnLocation;
	public GameObject player;
    private Vector3 respawnLoaction;
	public int enemyCount = 5;
	public int level = 1;
	public List<int> randomList = new List<int>();
    private int minE = 33;

    
	// Start is called before the first frame update
	void Start()
    {

       
        SpawnCharatcter(level,0);
    }

    void Awake()
	{

        spawnLocation = GameObject.FindGameObjectsWithTag("EnemySpawnPoint");

        Debug.Log("Spawn Loactions -----------------> " + spawnLocation.Length);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void SpawnCharatcter(int level, int minLoc)
	{
        spawnLocation = GameObject.FindGameObjectsWithTag("EnemySpawnPoint");
        player = (GameObject)Resources.Load("xbot", typeof(GameObject));
        respawnLoaction = player.transform.position;
        Debug.Log(spawnLocation.Length + "<---------------- Length spae loactaions");
        int i = 0;
		for (i = 0; i < enemyCount + (level *3); i++)
		{
            
			int spawn = Random.Range(minLoc, spawnLocation.Length-1);
            
            if (!randomList.Contains(spawn))
			{
				GameObject.Instantiate(player, spawnLocation[spawn].transform.position, Quaternion.identity);
				
				randomList.Add(spawn);
			}
		}
	}

    
}
