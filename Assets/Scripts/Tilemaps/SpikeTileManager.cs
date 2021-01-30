using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class SpikeTileManager : MonoBehaviour
{

    [SerializeField] 
    private Tilemap spikeMap;

    [SerializeField] 
    private float testField;

    public Tile noTile;
    public Tile phase1Spike;
    public Tile phase2Spike;
    public Tile phase3Spike;

    private Dictionary<Vector3Int, bool> spikeTiles = new Dictionary<Vector3Int, bool>();

    private bool _readyForNextSpikePhase = true;
    private int _currentSpikePhase = 0;
    
    void Start()
    {
        

    }
    
    

    void Update()
    {
        if (_readyForNextSpikePhase)
        {
            ChangeSpikePhase();
            
            if (_currentSpikePhase == 6)
            {
                _currentSpikePhase = 0;
            }
            else
            {
                _currentSpikePhase += 1;
            }
            LockSpikePhase();
            if (_currentSpikePhase == 0)
            {
                Invoke("UnlockSpikePhase", 2f);

            }
            else
            {
                Invoke("UnlockSpikePhase", 0.15f);

            }
        }
    }

    public Dictionary<Vector3Int, bool> GetSpikeTiles()
    {
        return spikeTiles;
    }

    private void ChangeSpikePhase()
    {
        if (spikeMap)
        {
              for(int x = spikeMap.cellBounds.min.x; x< spikeMap.cellBounds.max.x;x++){
                for(int y = spikeMap.cellBounds.min.y; y< spikeMap.cellBounds.max.y;y++){
                    for(int z= spikeMap.cellBounds.min.z; z< spikeMap.cellBounds.max.z;z++){

                        if (spikeMap.GetTile(new Vector3Int(x, y, z)) && spikeMap.GetTile(new Vector3Int(x, y, z)).name == "ground_for_spikes")
                        {
                            Vector3Int newSpikePosition = new Vector3Int(x, y + 1, z);
                            if (_currentSpikePhase == 0)
                            {
                                spikeMap.SetTile(newSpikePosition, null);
                                AddSpikeTiles(newSpikePosition, false);
                            } else if (_currentSpikePhase == 1)
                            {
                                spikeMap.SetTile(newSpikePosition, phase1Spike);
                                AddSpikeTiles(newSpikePosition, true);
                            } else if (_currentSpikePhase == 2)
                            {
                                spikeMap.SetTile(newSpikePosition, phase2Spike);
                                AddSpikeTiles(newSpikePosition, true);
                            } else if (_currentSpikePhase == 3)
                            {
                                spikeMap.SetTile(newSpikePosition, phase3Spike);
                                AddSpikeTiles(newSpikePosition, true);
                            } else if (_currentSpikePhase == 4)
                            {
                                spikeMap.SetTile(newSpikePosition, phase2Spike);
                                AddSpikeTiles(newSpikePosition, true);

                            } else if (_currentSpikePhase == 5)
                            {
                                spikeMap.SetTile(newSpikePosition, phase1Spike);
                                AddSpikeTiles(newSpikePosition, true);
                            } else if (_currentSpikePhase == 6)
                            {
                                spikeMap.SetTile(newSpikePosition, null);
                                AddSpikeTiles(newSpikePosition, false);
                            }
                        }
                    }
                }
              }
        }
    }

    private void AddSpikeTiles(Vector3Int position, bool hasSpikes)
    {
        bool val;
        if (spikeTiles.TryGetValue(position, out val))
        {
            spikeTiles[position] = hasSpikes;
        }
        else
        {
            spikeTiles.Add(position, false);
        }
        

    }

    private void LockSpikePhase()
    {
        _readyForNextSpikePhase = false;
    }
    
    private void UnlockSpikePhase()
    {
        _readyForNextSpikePhase = true;
    }
}
