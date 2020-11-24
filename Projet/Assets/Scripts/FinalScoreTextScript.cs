using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreTextScript : MonoBehaviour
{

    int finalScore;

    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        finalScore = PlayerPrefs.GetInt("Score");
        text.text = "Final score : "+finalScore;
    }

}
