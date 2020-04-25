using Assets.Scripts;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Game _game = null;

    public enum GameState
    {
        WaitingForInput,
        MovingTiles,
        GameOver
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

    public int Score
    {
        get { return _game.Score; }
    }

    // Use this for initialization
    void Start()
    {
        if (_game == null)
            _game = new Game(this);

        _game.Init();
        State = GameState.WaitingForInput;
    }

    // Update is called once per frame
    void Update()
    {
        if (State == GameState.WaitingForInput)
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
        }
    }

    public void StartGame()
    {
        _game.Init();
        State = GameState.WaitingForInput;
    }
}
