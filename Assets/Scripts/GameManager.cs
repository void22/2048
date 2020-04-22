using Assets.Scripts;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    DateTime _start;
    Table _table;

    public enum Direction
    {
        None,
        Left,
        Right,
        Up,
        Down
    };

    public GameState State { get; private set; }
    public TimeSpan ElapsedTime { get; private set; }

    // Use this for initialization
    void Start()
    {
        _table = new Table();
    }

    // Update is called once per frame
    void Update()
    {
        if (State == GameState.Running)
        {
            Direction direction = Direction.None;

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                direction = Direction.Left;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                direction = Direction.Right;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                direction = Direction.Up;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                direction = Direction.Down;
            }

            if (direction != Direction.None)
            {
                _table.Move(direction);
                _table.UpdateTiles();
            }
            
            ElapsedTime = DateTime.Now - _start;
        }
    }

    public void StartGame()
    {
        _table.Init();

        State = GameState.Running;
        _start = DateTime.Now;
    }

    public void StopGame()
    {
        State = GameState.Stopped;
    }
}
