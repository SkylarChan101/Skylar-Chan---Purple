using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] tetrominoes;
    public void SpawnTetromino()
    {
        int randNum = Random.Range(0, tetrominoes.Length);
        GameObject randomTetromino = tetrominoes[randNum];
        Instantiate(randomTetromino, transform.position, Quaternion.identity);
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnTetromino();
    }

    

}
