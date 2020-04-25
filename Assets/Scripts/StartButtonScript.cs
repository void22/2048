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
        var score = GameObject.Find("Score").GetComponent<Text>();
        score.text = _gameManager.Score.ToString();
    }

    void Click()
    {
        _gameManager.StartGame();
    }
}
