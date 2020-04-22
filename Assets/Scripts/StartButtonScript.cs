using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class StartButtonScript : MonoBehaviour
{
    GameManager _gameManager;
    Button _button;

    // Use this for initialization
    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();

        _button = GetComponent<Button>();
        _button.onClick.AddListener(Click);
    }
    
    // Update is called once per frame
	void Update()
    {

    }

    void Click()
    {
        if (_gameManager.State == GameState.Stopped)
        {
            _gameManager.StartGame();
            _button.GetComponentInChildren<Text>().text = "Stop";
        }
        else
        {
            _gameManager.StopGame();
            _button.GetComponentInChildren<Text>().text = "Start";
        }
    }
}
