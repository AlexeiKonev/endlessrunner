using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject[] tilePrefabs;
   [SerializeField] private Transform player;
    public float tileLength = 100;
    public float spawnPos = 0;
    private int startTile = 6;
    private void SpawnTile(int tileIndex)
    {
        Instantiate(tilePrefabs[tileIndex],transform.forward * spawnPos,transform.rotation);
        spawnPos += tileLength;
    }
    void Start()
    {
      for(int i= 0; i < startTile; i++)
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.z > spawnPos - (startTile * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
        }
    }
}
