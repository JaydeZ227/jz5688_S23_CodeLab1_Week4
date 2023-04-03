using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{





    Text timeText;
    public float timeStart = 10;
    public float timeCount = 10;
    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
        timeText = GameObject.FindGameObjectWithTag("Time").GetComponent<Text>();

    }



    private void Update()
    {

        TimeDown();

    }



    void TimeDown()
    {

        if (timeCount <= 0)
        {
            GameObject[] allUFO = GameObject.FindGameObjectsWithTag("UFO");
            for (int i = 0; i < allUFO.Length; i++)
            {
                Destroy(allUFO[i]);
            }
            timeCount = timeStart;
            timeText.text = "Time:" + timeCount.ToString();
            GameManager.Instance.EnterNextLevel();
        }
        timeCount -= Time.deltaTime;
        int timeCountInt = (int)timeCount;
        timeText.text = "Time:" + timeCountInt.ToString();

    }



    public void ResetTime()
    {
        timeCount = timeStart;
        timeText.text = "Time:" + timeCount.ToString();

    }


    
















}
