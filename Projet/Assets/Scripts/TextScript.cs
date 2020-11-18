using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{

    public Text text;

    public static int score;
    public static int lives;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Score :";
        score = GameManager.score;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score : " + GameManager.score;
    }
}