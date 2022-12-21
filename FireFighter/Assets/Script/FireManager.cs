using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireManager : MonoBehaviour
{
    public FirePoint[] firePoints;
    public GameManager gameManager;

    private void Update()
    {
        if (gameManager.firePointCount == 0)
        {
            gameManager.NextLevel();
        }
    }

    public void DestroyFire(int number)
    {
        for (int i = 0; i < firePoints.Length; i++)
        {
            if (i == number)
            {
                if (firePoints[i].fireTime > 0)
                {
                    firePoints[i].fireTime -= Time.deltaTime ;
                    Debug.Log(firePoints[i].fireTime);
                }
                else if(firePoints[i].fireTime <= 0)
                {
                    Destroy(firePoints[i].gameObject);
                    firePoints[i].fireParticle.Stop();
                    gameManager.firePointCount--;
                    Debug.Log("söndü");
                    gameManager.CheckFirePoints();
                }
                
            }
        }
    }
}
