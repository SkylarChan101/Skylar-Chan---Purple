using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject rockPrefab;
    // Start is called before the first frame updates
    void Start()
    {
        InvokeRepeating("Spawnrocks", 0f, 10f);
    } 

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawnrocks()
    {
        for (int i = 0; i < 4; i++)
        {
            Vector3 randomPosition = spawnPoints[Random.Range(0, 3)].position;
            Instantiate(rockPrefab, randomPosition, Quaternion.identity);
        }
    }
}
