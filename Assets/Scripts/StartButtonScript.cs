using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class StartButtonScript : MonoBehaviour
{
    GameManager _gameManager;

    // Use this for initialization
    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();

        GetComponent<Button>().onClick.AddListener(Click);
    }
    
    // Update is called once per frame
	void Update()
    {

    }

    void Awake()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Click()
    {
        if (_gameManager.State == GameState.Stopped)
        {
            _gameManager.StartGame();
        }
        else
        {
            _gameManager.StopGame();
        }
    }
}
