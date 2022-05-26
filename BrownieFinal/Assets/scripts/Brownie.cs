using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Brownie : MonoBehaviour
{

    private int score;
    public TextMeshProUGUI Score;
    void Start()
    {
        score = 0;
        UpdateScore(0);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        UpdateScore(1);
        Destroy(gameObject);
        



    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        Score.text = "Score:" + score + "/8";
    }
}