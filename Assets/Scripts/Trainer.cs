using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Trainer : MonoBehaviour
{
    public GameObject targetPrefab;
    public static Trainer instance;
    public static bool gameOver;
    public static int targetsHit = 1, targetsMissed = 1, accuracy;
    public Slider accuracySlider;

    public TextMeshProUGUI targetsHitLbl, targetsMissedLbl, accuracyLbl;

    private void Start()
    {
        SpawnTarget();
        gameOver = false;
        instance = this;
    }

    private void Update()
    {
        int sum = targetsHit + targetsMissed;
        accuracySlider.value = targetsHit * 100 / sum;

        targetsHitLbl.text = "Targets Hit:" + targetsHit;
        targetsMissedLbl.text = "Targets Missed: " + targetsMissed;
        accuracyLbl.text = "Accuracy:" + accuracySlider.value + "%";

        if (gameOver == true)
        {
            if(Input.GetKeyDown(KeyCode.R)) 
            {
                SceneManager.LoadScene(0);
                targetsHit = 1;
                targetsMissed = 1;
            }
        }
    }

    public void SpawnTarget()
    {
        Vector3 randomSpawn = new Vector3(Random.Range(-5, 5), 3, Random.Range(-5, 5));
        Instantiate(targetPrefab, randomSpawn, Quaternion.identity);    
    }
}
