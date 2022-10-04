using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Tooltip("A reference to the tile we want to spawn")]
    public Transform tile;

    [Tooltip("Where the first tile should be placed at")]
    public Vector3 startPoint = new Vector3(0, 0, -5);

    [Tooltip("How many tiles should we create in advance")]
    [Range(1, 15)]
    public int initSpawnNum = 10;

    [Header("Obstacles Variables")]
    public int freeTiles;
    public GameObject obstacle;
    /// <summary> 
    /// Where the next tile should be spawned at. 
    /// </summary> 
    private Vector3 nextTileLocation;
    /// <summary> 
    /// How should the next tile be rotated? 
    /// </summary> 
    private Quaternion nextTileRotation;
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    private int tilesPassedCounter = 0;
    
    private void Start()
    {
        // Set our starting point 
	    // Manage Rotation and Orientation
        nextTileLocation = startPoint;
        nextTileRotation = Quaternion.identity;
        for (int i = 0; i < initSpawnNum; ++i)
        {
            SpawnNextTile();
            tilesPassedCounter++;
        }
    }

    public void SpawnNextTile(bool spawnObstacles = true)
    {
        var newTile = Instantiate(tile, nextTileLocation, nextTileRotation);
        var nextTile = newTile.Find("Next Spawn Point");
    }

    /// <summary> 
    /// Will spawn a tile at a certain location and setup the next
    /// position 
    /// </summary> 
    public void SpawnNextTile()
    {
        var newTile = Instantiate(tile, nextTileLocation,
        nextTileRotation);

        if (tilesPassedCounter >= freeTiles)
        {
            int randomPosition = Random.Range(1, 4);

            if(randomPosition == 1)
            {
                var newObstacle = Instantiate(obstacle, newTile.GetChild(5).position, Quaternion.identity);
                newObstacle.transform.parent = newTile.GetChild(5).transform;
            }
            if(randomPosition == 2)
            {
                var newObstacle = Instantiate(obstacle, newTile.GetChild(6).position, Quaternion.identity);
                newObstacle.transform.parent = newTile.GetChild(6).transform;
            }
            else
            {
                var newObstacle = Instantiate(obstacle, newTile.GetChild(7).position, Quaternion.identity);
                newObstacle.transform.parent = newTile.GetChild(7).transform;
            }
        }

        // Figure out where and at what rotation we should spawn
        // the next item 
        var nextTile = newTile.Find("Next Spawn Point");
        nextTileLocation = nextTile.position;
        nextTileRotation = nextTile.rotation;
    }
}