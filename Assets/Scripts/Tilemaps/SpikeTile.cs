using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTile : MonoBehaviour
{
    private SpikeTileManager _spikeTileManager;
    void Start()
    {
        LoadComponents();
    }

    void Update()
    {
        
    }

    private void LoadComponents()
    {
        _spikeTileManager = GameObject.Find("SpikesManager").GetComponent<SpikeTileManager>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector3 hitPosition = Vector3.zero;
            foreach (ContactPoint2D hit in collision.contacts)
            {
                hitPosition.x = hit.point.x;
                hitPosition.y = hit.point.y + 0.05f;
                
                if (CheckIfTileHasSpike(hitPosition))
                {
                    if (collision.gameObject)
                    {
                        Destroy(collision.gameObject);
                    }
                    


                }
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
                hitPosition.x = hit.point.x;
                hitPosition.y = hit.point.y + 0.05f;
                
                if (CheckIfTileHasSpike(hitPosition))
                {
                    
                    if (collision.gameObject)
                    {
                        Destroy(collision.gameObject);
                    }
                        
                }               
            }  
        }
    }

    private bool CheckIfTileHasSpike(Vector3 pos)
    {
        Grid grid = transform.parent.GetComponentInParent<Grid>();
        Vector3Int cellPosition = grid.WorldToCell(pos);
        bool value = true;

        if (_spikeTileManager.GetSpikeTiles().TryGetValue(cellPosition, out value))
        {
            if (_spikeTileManager.GetSpikeTiles()[cellPosition])
            {
                return true;
            }
            
        }

        return false;
    }
}
