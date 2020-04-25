using UnityEngine;

public class Tile
{
    private GameObject _tile;
    private Animator _animator;
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
        _animator = _tile.GetComponent<Animator>();
        Value = 0;
        Merged = false;
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

    public void PlayAnimation(string anim)
    {
        _animator.SetTrigger(anim);
    }
}

