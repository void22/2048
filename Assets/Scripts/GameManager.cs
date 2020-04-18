using Assets.Scripts;
using System;

public class GameManager
{
    private DateTime _start;

    public GameState State { get; private set; }
    public TimeSpan ElapsedTime { get; private set; }

    public void StartGame()
    {
        State = GameState.Idle;
        _start = DateTime.Now;
    }

    public void StopGame()
    {
        State = GameState.Stopped;
    }

    public void Update()
    {
        ElapsedTime = DateTime.Now - _start;
    }

    public void HandleLeftKey()
    {

    }

    public void HandleRightKey()
    {

    }

    public void HandleUpKey()
    {

    }

    public void HandleDownKey()
    {

    }

    #region Singleton pattern
    private static GameManager _instance = null;
    private static readonly object _lock = new object();

    GameManager()
    {
    }

    public static GameManager Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                    _instance = new GameManager();

                return _instance;
            }
        }
    }
    #endregion
}
