using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodModeController : MonoBehaviour
{
    private SpriteRenderer _sprite;
    private Color _normalVikingColor;
    private Color _higlitedVikingColor = new Color (1, 0, 1, 1);

    void Start()
    {
        LoadComponents();
        _normalVikingColor = GetCurrentVikingColoer();
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.GetRemainingGodModeTime() > 0)
        {
            if (_sprite.color == _normalVikingColor)
            {
                _sprite.color = _higlitedVikingColor;
            }
            else
            {
                _sprite.color = _normalVikingColor;
            }
        }
        else
        {
            _sprite.color = _normalVikingColor;
        }
    }

    private void LoadComponents()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    private Color GetCurrentVikingColoer()
    {
        return _sprite.color;
    }
}
