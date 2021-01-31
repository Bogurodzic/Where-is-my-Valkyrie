using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IceTile : MonoBehaviour
{

    private TilemapCollider2D _tileCollider;
    private Tilemap _tilemap;
    private LinkedList<Vector3Int> _alreadyDestroyedTilemaps = new LinkedList<Vector3Int>();

    public float iceRespawnTime = 5f;
    public Tile ice1;
    public Tile ice2;
    public Tile ice3;
    public Tile ice4;

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
        if (collision.gameObject.tag == "Player")
        {
            Vector3 hitPosition = Vector3.zero;
            foreach (ContactPoint2D hit in collision.contacts)
            {
                hitPosition.x = hit.point.x - 0.1f;
                hitPosition.y = hit.point.y - 0.1f;
                MakeEmptyTile(hitPosition);
            }  
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector3 hitPosition = Vector3.zero;
            foreach (ContactPoint2D hit in collision.contacts)
            {
                hitPosition.x = hit.point.x - 0.1f;
                hitPosition.y = hit.point.y - 0.1f;
                MakeEmptyTile(hitPosition);
            }  
        }
    }

    private void MakeEmptyTile(Vector3 pos)
    {
        Grid grid = transform.parent.GetComponentInParent<Grid>();
        Vector3Int cellPosition = grid.WorldToCell(pos);
        if (_tilemap.GetTile(cellPosition))
        {
            bool canPlatformBeDestroyed = true;

            LinkedList<Vector3Int>.Enumerator alreadyDestroyedTilemapsEnumerator = _alreadyDestroyedTilemaps.GetEnumerator();
            while (alreadyDestroyedTilemapsEnumerator.MoveNext())
            {
                Vector3Int destroyedObstacleCellPosition = alreadyDestroyedTilemapsEnumerator.Current;
                if (destroyedObstacleCellPosition == cellPosition)
                {
                    canPlatformBeDestroyed = false;
                }
            } 

            if (canPlatformBeDestroyed)
            {
                _alreadyDestroyedTilemaps.AddLast(cellPosition);
                StartCoroutine(DestroyTileMap(cellPosition));
            }
        }


    }
    
    IEnumerator DestroyTileMap(Vector3Int cellPosition){
        yield return new WaitForSeconds(0.15f);
        _tilemap.SetTile(cellPosition, ice2);
        yield return new WaitForSeconds(0.15f);
        _tilemap.SetTile(cellPosition, ice3);
        yield return new WaitForSeconds(0.15f);
        _tilemap.SetTile(cellPosition, ice4);
        yield return new WaitForSeconds(0.15f);
        _tilemap.SetTile(cellPosition, null);
        yield return new WaitForSeconds(iceRespawnTime);
        _tilemap.SetTile(cellPosition, ice1);
    }

    private void LoadComponents()
    {
        _tileCollider = GetComponent<TilemapCollider2D>();
        _tilemap = GetComponent<Tilemap>();
    }
}
