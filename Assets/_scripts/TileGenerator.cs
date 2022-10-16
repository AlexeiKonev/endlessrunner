using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject[] tilePrefabs;
   [SerializeField] private List<GameObject> tileList;
   [SerializeField] private Transform player;
    public float tileLength = 100;
    public float spawnPos = 0;
    private int startTile = 6;
    private void SpawnTile(int tileIndex)
    {
     GameObject tempTile = Instantiate(tilePrefabs[tileIndex],transform.forward * spawnPos,transform.rotation);
       
        spawnPos += tileLength;
        tileList.Add(tempTile);
    }
    private void DeleteTile()
    {
        Destroy(tileList[0]);
        tileList.RemoveAt(0);
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
        if(player.position.z - 60 > spawnPos - (startTile * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }
}
