using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public Text scoreText;

    private void Awake() 
    {
        instance = this;
    }

    public void ScoreChange(string str)
    {
        if(str != null)
            scoreText.text = str;
    }
}
