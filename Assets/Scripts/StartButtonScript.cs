using UnityEngine;
using UnityEngine.UI;

public class StartButtonScript : MonoBehaviour
{
    GameManager _gameManager;
    Button _button;
    Text _elapsedTimeText;
    
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
        var elapsed = GameObject.Find("ElapsedTime").GetComponent<Text>();
        elapsed.text = _gameManager.ElapsedTime.ToString();

        var score = GameObject.Find("Score").GetComponent<Text>();
        score.text = _gameManager.Score.ToString();
    }

    void Click()
    {
        if (_gameManager.State == GameManager.GameState.Stopped)
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
