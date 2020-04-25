using UnityEngine;
using System.Collections.Generic;

public class ScoreScript : MonoBehaviour
{
    GameManager GameManager;
    SpriteRenderer Score_0;
    SpriteRenderer Score_1;
    SpriteRenderer Score_2;
    SpriteRenderer Score_3;
    SpriteRenderer Score_4;
    SpriteRenderer Score_5;
    Dictionary<char, Sprite> Numbers;

    // Use this for initialization
    void Start()
    {
        GameManager = FindObjectOfType<GameManager>();
        Numbers = new Dictionary<char, Sprite>();
        Score_0 = GameObject.Find("Score_0").GetComponent<SpriteRenderer>();
        Score_1 = GameObject.Find("Score_1").GetComponent<SpriteRenderer>();
        Score_2 = GameObject.Find("Score_2").GetComponent<SpriteRenderer>();
        Score_3 = GameObject.Find("Score_3").GetComponent<SpriteRenderer>();
        Score_4 = GameObject.Find("Score_4").GetComponent<SpriteRenderer>();
        Score_5 = GameObject.Find("Score_5").GetComponent<SpriteRenderer>();

        Sprite[] numbers = Resources.LoadAll<Sprite>("numbers");
        Numbers.Add('0', numbers[0]);
        Numbers.Add('1', numbers[1]);
        Numbers.Add('2', numbers[2]);
        Numbers.Add('3', numbers[3]);
        Numbers.Add('4', numbers[4]);
        Numbers.Add('5', numbers[5]);
        Numbers.Add('6', numbers[6]);
        Numbers.Add('7', numbers[7]);
        Numbers.Add('8', numbers[8]);
        Numbers.Add('9', numbers[9]);
    }

    // Update is called once per frame
    void Update()
    {
        string scoreString = GameManager.Score.ToString().PadLeft(6, '0');
        Score_0.sprite = Numbers[scoreString[0]];
        Score_1.sprite = Numbers[scoreString[1]];
        Score_2.sprite = Numbers[scoreString[2]];
        Score_3.sprite = Numbers[scoreString[3]];
        Score_4.sprite = Numbers[scoreString[4]];
        Score_5.sprite = Numbers[scoreString[5]];
    }
}
