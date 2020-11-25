using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARTextScript : MonoBehaviour
{

    public Text text;

    public static int score;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "Score :";
        score = ARGameManager.score;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score : " + ARGameManager.score;   
    }
}
