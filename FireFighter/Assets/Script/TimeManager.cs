using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class TimeManager : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField] private float levelTime;
    [SerializeField] private TextMeshProUGUI levelText;

    [SerializeField] private Image timerImage;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float currentTime;
    [SerializeField] private float duration;



    private void Start()
    {
        duration = levelTime;
        currentTime = levelTime;
        timerText.text = currentTime.ToString();
        Time.timeScale = 1;
        StartCoroutine(UpdateTime());
    }

    public void Update()
    {
        if (levelTime > 0)
        {
            levelTime -= Time.deltaTime;
        }
        else if (levelTime <= 0 && gameManager.fireFinished == false)
        {
            Debug.Log("YANDIN AY AMAN AY AMAN AY AMAN");
            Time.timeScale = 0;
        }
        

        int levelTimeInt = Convert.ToInt32(levelTime);
        levelText.text = "TIME : " + levelTimeInt.ToString();
        
    }

    private IEnumerator UpdateTime()
    {
        while (currentTime >= 0)
        {
            timerImage.fillAmount = Mathf.InverseLerp(0, duration, currentTime);
            timerText.text = currentTime.ToString();
            yield return new WaitForSeconds(1f);
            currentTime--;
        }

        yield return null;
    }

    
}
