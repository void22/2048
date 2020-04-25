using Assets.Scripts;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private DateTime _start;
    private Game _game;

    public enum GameState
    {
        Stopped,
        Running
    }

    public enum Direction
    {
        None,
        Left,
        Right,
        Up,
        Down
    };

    public GameState State { get; set; }
    public TimeSpan ElapsedTime { get; private set; }

    public int Score
    {
        get { return _game.Score; }
    }

    // Use this for initialization
    void Start()
    {
        _game = new Game(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (State == GameState.Running)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _game.Update(Direction.Left);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _game.Update(Direction.Right);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _game.Update(Direction.Up);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _game.Update(Direction.Down);
            }

            ElapsedTime = DateTime.Now - _start;
        }
    }

    public void StartGame()
    {
        _game.Create();
        State = GameState.Running;
        _start = DateTime.Now;
    }

    public void StopGame()
    {
        State = GameState.Stopped;
    }
}
