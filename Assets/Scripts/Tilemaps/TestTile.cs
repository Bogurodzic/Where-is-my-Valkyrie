using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TestTile : MonoBehaviour
{

    private TilemapCollider2D _tileCollider;
    private Tilemap _tilemap;
    void Start()
    {
        LoadComponents();
        //_tilemap.SetTile(new Vector3Int(-1, 0, 0), null);

    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(gameObject);
        if (collision.gameObject.tag == "Player")
        {
            Vector3 hitPosition = Vector3.zero;
            foreach (ContactPoint2D hit in collision.contacts)
            {
                hitPosition.x = hit.point.x - 0.05f;
                hitPosition.y = hit.point.y - 0.05f;
                MakeEmptyTile(hitPosition);
                Debug.Log("H:" + hitPosition);
                Debug.Log("Con:" + hit.point);
                Debug.Log("Coollision  " + _tilemap.WorldToCell(hitPosition));
            
            }  
        }

    }

    private void MakeEmptyTile(Vector3 pos)
    {
        Grid grid = transform.parent.GetComponentInParent<Grid>();
        Vector3Int cellPosition = grid.WorldToCell(pos);
        StartCoroutine(DestroyTileMap(cellPosition));

    }
    
    IEnumerator DestroyTileMap(Vector3Int cellPosition){
        yield return new WaitForSeconds(1);
        _tilemap.SetTile(cellPosition, null);
    }

    private void LoadComponents()
    {
        _tileCollider = GetComponent<TilemapCollider2D>();
        _tilemap = GetComponent<Tilemap>();
    }
}
