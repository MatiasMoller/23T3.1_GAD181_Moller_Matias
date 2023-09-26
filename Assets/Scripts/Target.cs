using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DestroyTarget());
    }
    IEnumerator DestroyTarget()
    {
        yield return new WaitForSeconds(2);
        Trainer.targetsMissed = Trainer.targetsMissed + 1; 
        if (Trainer.gameOver == false)
        {
            Trainer.instance.SpawnTarget();

        }
        Destroy(gameObject);
    }
    private void OnMouseDown()
    {
        Trainer.targetsHit = Trainer.targetsHit + 1; 
        Destroy(gameObject);
        if (Trainer.gameOver == false)
        {
            Trainer.instance.SpawnTarget();
        }
    }
    

}
