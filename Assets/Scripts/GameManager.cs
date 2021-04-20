using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;

    private void Awake()
    {
        instance = this;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
