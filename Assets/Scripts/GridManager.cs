using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height;

    [SerializeField] private Tile tilePrefab;

    void GenerateGrid()
    {
        for(int x = 0; x <= width; x++)
        {
            for(int y = 0; y <= height; y++)
            {
                var spawnTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnTile.name = $"Tile {x} {y}";
            }
        }

        for (int x = 0; x <= width; x++)
        {
            for (int y = 15; y <= height + 15; y++)
            {
                var spawnTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnTile.name = $"Tile {x} {y}";
            }
        }

    }
    void Start()
    {
        GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
