using UnityEngine;
using System.Collections;

public class Tile
{
    private GameObject _tile;
    private int _currentValue;

    public Tile(string objectName)
    {
        _tile = GameObject.Find(objectName);
        _currentValue = 0;
        Hide();
    }

    public void Show()
    {
        _tile.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void Hide()
    {
        _tile.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void ChangeTexture(int value)
    {
        if (_currentValue != value)
        {
            Debug.Log("Value changed: " + _currentValue.ToString() + ", " + value.ToString());
            _currentValue = value;
            _tile.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("2048_" + value.ToString());
        }
    }
}

