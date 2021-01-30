using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEndPoint : MonoBehaviour
{
    private bool _isActivated = false;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && !_isActivated)
        {
            _isActivated = true;
            StageManager.Instance.GoToNextLevel();
        }
    }
}
