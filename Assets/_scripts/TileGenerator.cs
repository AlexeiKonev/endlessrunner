using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float tileLength = 100;
    public float spawnPos = 0;

    private void SpawnTile(int tileIndex)
    {
        Instantiate(tilePrefabs[tileIndex],transform.forward * spawnPos,transform.rotation);
        spawnPos += tileLength;
    }
    void Start()
    {
        SpawnTile(0);
        SpawnTile(1);
        SpawnTile(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
