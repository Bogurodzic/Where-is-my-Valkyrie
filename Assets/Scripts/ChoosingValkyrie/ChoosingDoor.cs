using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosingDoor : MonoBehaviour
{
    public GameObject[] valkyrieDoors;
    public GameObject arrow;

    private int _doorActive = 1;
    private bool _choosingAvailable = false;
    private bool _isChoosed = false;
    void Start()
    {
       Invoke("UnlockChoosing", 2.35f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !_isChoosed && _choosingAvailable)
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
        
        
        if (Input.GetKeyDown(KeyCode.RightArrow)  && !_isChoosed && _choosingAvailable)
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

        if (Input.GetKeyDown(KeyCode.Space) && !_isChoosed && _choosingAvailable)
        {
            ChooseCurrentDoor();
        }
    }

    private void UnlockChoosing()
    {
        _choosingAvailable = true;
        arrow.GetComponent<Animator>().SetBool("isActive", true);
    }

    private void ChooseCurrentDoor()
    {
        _isChoosed = true;
        valkyrieDoors[_doorActive - 1].GetComponent<Animator>().SetBool("isChoosed", true);
        Invoke("EndStage", 7.5f);
    }

    private void EndStage()
    {
        StageManager.Instance.HandleEndingGame();
    }

    private void SetArrowOnDoor(int doorNumber)
    {
        arrow.transform.position = new Vector3(valkyrieDoors[doorNumber - 1].transform.position.x, arrow.transform.position.y, arrow.transform.position.z);
    }
}
