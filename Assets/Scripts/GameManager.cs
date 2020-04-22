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
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _table.Move(Direction.Left);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _table.Move(Direction.Right);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _table.Move(Direction.Up);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _table.Move(Direction.Down);
            }                

            _table.UpdateTiles();
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
