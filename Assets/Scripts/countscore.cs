using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class counter2 : MonoBehaviour
{
    public Text time;
    public Text highscore;
    private float timeCounter = 0f;
    private float highScoreCounter = 0f;
    private bool gameOn = true;

    void Start()
    {
        // PlayerPrefs.DeleteAll();
        if (PlayerPrefs.HasKey("Highscore2"))
        {
            highScoreCounter = PlayerPrefs.GetFloat("Highscore2");
            highscore.text = ((int)highScoreCounter).ToString();
        }
    }


    void Update()
    {
        if (gameOn)
        {
            timeCounter += Time.deltaTime;
            time.text = (int)timeCounter + "";
        }
        else
        {
            Time.timeScale = 0f;
        }

        if (timeCounter > highScoreCounter)
        {
            highScoreCounter = timeCounter;
            highscore.text = (int)highScoreCounter + "";

            PlayerPrefs.SetFloat("Highscore2", highScoreCounter);
            PlayerPrefs.Save();
        }
    }
}
