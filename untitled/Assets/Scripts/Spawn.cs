using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject prefab; //reference to a premade gameobejct

    public float spawnTime = 2f; //this will be the time between creating new gameobejcts
    public float minSpawnTime = 0.01f; //this is the min amount we want between new spawns

    float startSpawn; //this will hold what we reset out spawn time to

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawner", spawnTime); //invoke runs a function after a delay
        startSpawn = spawnTime; //set the variable that tracks what we want to reset the spawn timer to
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawner()
    {
        if (enabled)
        {
            GameObject newCyl = Instantiate(prefab); //create a new object, temp store it as newCyl
            newCyl.transform.position = new Vector3( //set the position of the new object
                                            Random.Range(460.5f, 440.5f), //x axis value range
                                            241.66f,//y axis value
                                            Random.Range(10f, -10f) //z axis value
                                        );
            spawnTime -= 0.1f; //decrease spawntime
            if (spawnTime < minSpawnTime) //if spawntime has hit the min amount we want to wait b/t spawns
            {
                spawnTime = startSpawn; //reset it to whatever it was at start
            }
            Invoke("Spawner", spawnTime); //restart the invoke

        }
       
    }

}
