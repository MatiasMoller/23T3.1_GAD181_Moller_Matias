using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerLbl;
    public float timer = 10f;

    private void Update()
    {
        if (timer >0)
        {
            timer -= Time.deltaTime;    
            DisplayTime(timer);
        }
        else
        {
            Trainer.gameOver = true;
            timerLbl.text = "Game Over";
            
        }
    }


    private void DisplayTime(float displayTime)
    {
        float minutes = Mathf.FloorToInt(timer / 60);
        float seconds = Mathf.FloorToInt(timer % 60);
        timerLbl.text = $"{minutes}:{seconds}";
    }
}
