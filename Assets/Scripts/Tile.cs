using UnityEngine;

public class Tile
{
    private GameObject _tile;
    private int _value;

    public int Value
    {
        get { return _value; }
        set
        {
            if (value != _value)
            {
                _value = value;

                if (value != 0)
                    _tile.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("2048_" + value.ToString());
            }
        }
    }

    public bool Merged { get; set; }

    public Tile(string objectName)
    {
        _tile = GameObject.Find(objectName);
        Value = 2048;
        Merged = false;
        Show();
    }

    public void Show()
    {
        _tile.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void Hide()
    {
        _tile.GetComponent<SpriteRenderer>().enabled = false;
    }
}

