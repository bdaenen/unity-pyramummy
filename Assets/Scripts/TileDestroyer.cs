using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class TileDestroyer : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile[] tiles;
    public int selectedTile = 0;

    public Transform tileGridUI;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(tilemap.WorldToCell(position));
            tilemap.SetTile(tilemap.WorldToCell(position), null);
        }
    }
}
