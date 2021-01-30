using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosingDoor : MonoBehaviour
{
    public GameObject[] valkyrieDoors;
    public GameObject arrow;

    private int _doorActive = 1;
    void Start()
    {
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (_doorActive == 1)
            {
                _doorActive = 3;
            }
            else
            {
                _doorActive -= 1;
            }
            
            SetArrowOnDoor(_doorActive);
        }
        
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (_doorActive == 3)
            {
                _doorActive = 1;
            }
            else
            {
                _doorActive += 1;
            }

            SetArrowOnDoor(_doorActive);
        }
    }

    private void SetArrowOnDoor(int doorNumber)
    {
        arrow.transform.position = new Vector3(valkyrieDoors[doorNumber - 1].transform.position.x, arrow.transform.position.y, arrow.transform.position.z);
    }
}
