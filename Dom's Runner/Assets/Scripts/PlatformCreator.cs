using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCreator : MonoBehaviour
{

    public Transform[] SpawnPoints;
    public float SpawnTime = 1.5f;
    public GameObject OBSTACLE1;
    //public float speedModifier;
    public float speed;
    private Rigidbody movement;
    public GameObject Obstacles;

    // Use this for initialization
    void Start()
    {
        movement = GetComponent<Rigidbody>();
        InvokeRepeating("SpawnObj", SpawnTime, SpawnTime);

    }

    void Update()
    {
        //        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 4);
        movement.velocity = new Vector3(movement.velocity.x, movement.velocity.y, speed);
        //speedModifier += speed * Time.deltaTime;
    }

    void SpawnObj()
    {
        int spawnIndex = Random.Range(0, SpawnPoints.Length);
        Instantiate(Obstacles, SpawnPoints[spawnIndex].position, SpawnPoints[spawnIndex].rotation);

    }
}
