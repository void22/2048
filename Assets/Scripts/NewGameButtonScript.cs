using UnityEngine;
using System.Collections;

public class NewGameButtonScript : MonoBehaviour
{
    GameManager _gameManager;
    SpriteRenderer _spriteRenderer;
    Sprite _newgame;
    Sprite _newgamehot;

    // Use this for initialization
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _newgame = Resources.Load<Sprite>("newgame");
        _newgamehot = Resources.Load<Sprite>("newgamehot");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseEnter()
    {
        _spriteRenderer.sprite = _newgamehot;
    }

    void OnMouseExit()
    {
        _spriteRenderer.sprite = _newgame;
    }

    void OnMouseUp()
    {
        _gameManager.StartGame();
    }
}
