using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Prefabs.PushBullet
{
    public class BreakAndPushBlock : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        /*private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("TilemapTerrain")) return;
            var tilemap = other.gameObject.GetComponent<Tilemap>();

            
            Debug.Log("BOUNDS::::");
            
            var myTransform = GetComponent<Transform>();
            //Vector2 position = Camera.main.ScreenToWorldPoint(myTransform.position);
            Debug.Log( tilemap.WorldToCell(tilemap.transform.position));
            Debug.Log(tilemap.name);
            tilemap.SetTile(tilemap.WorldToCell(myTransform.position), null);
        }*/

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag("TilemapTerrain")) return;
            var tilemap = other.gameObject.GetComponent<Tilemap>();

            
            Debug.Log("BOUNDS::::");
            
            var myTransform = GetComponent<Transform>();
            //Vector2 position = Camera.main.ScreenToWorldPoint(myTransform.position);
            Debug.Log( tilemap.WorldToCell(tilemap.transform.position));
            Debug.Log(tilemap.name);
            
            // TODO: check if there's any tiles on this cell, if not, add something to this.update to check if we find a tile in our current position right now.
            tilemap.SetTile(tilemap.WorldToCell(myTransform.position), null);
        }
    }
}
