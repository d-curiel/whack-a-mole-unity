using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneUIManager : MonoBehaviour
{
    [SerializeField]
    Text timeRemainingText;
    [SerializeField]
    Text scoreText;
    
    public static MainSceneUIManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
    public void setScore(string score){
        scoreText.text = score;
    }

    public void setTimeRemaining(string timeRemaining){
        timeRemainingText.text = timeRemaining;
    }
}
