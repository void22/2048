using System;
using UnityEngine;
using UnityEngine.UI;

public class StartButtonScript : MonoBehaviour
{
    private Text _score;
    private Text _elapsedTime;

    // Use this for initialization
    void Start()
    {
        var button = GetComponent<Button>();
        button.onClick.AddListener(Click);

        _score = GameObject.Find("Score").GetComponent<Text>();
        _elapsedTime = GameObject.Find("ElapsedTime").GetComponent<Text>();
    }
    
    // Update is called once per frame
	void Update()
    {
        GameManager.Instance.Update();

        if (GameManager.Instance.State == Assets.Scripts.GameState.Idle)
        {
            _elapsedTime.text = GameManager.Instance.ElapsedTime.ToString();

            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                _score.text = "Up key";
                GameManager.Instance.HandleUpKey();
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                _score.text = "Down key";
                GameManager.Instance.HandleDownKey();
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                _score.text = "Left key";
                GameManager.Instance.HandleLeftKey();
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                _score.text = "Right key";
                GameManager.Instance.HandleRightKey();
            }
        }
        else
        {
            _elapsedTime.text = "0:0:0";
        }
    }

    void Click()
    {
        if (GameManager.Instance.State == Assets.Scripts.GameState.Stopped)
        {
            GameManager.Instance.StartGame();
        }
        else
        {
            GameManager.Instance.StopGame();
        }
    }
}
