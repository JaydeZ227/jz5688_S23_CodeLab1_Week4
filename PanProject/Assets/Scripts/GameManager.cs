using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{




    public static GameManager Instance;
    public GameObject gameOver;
    public Text[] scoreTextArray;
    public Text showText;

    public Text roundText;
    public Text trialText;
    public Text scoreText;

    public int curLevelCount = 1;
    //public int trialCount = 2;
    public int curLevelTargetScore = 3;
    public int curLevelScore = 0;
    



    public void AddScore()
    {
        curLevelScore++;
        ShowScoreText();
    }

    
    public void ShowRoundText()
    {
        roundText.text = "Round:" + curLevelCount.ToString();
    }
    public void ShowTrialText()
    {

        trialText.text = "Trial:" + curLevelTargetScore.ToString();
    }

    public void ShowScoreText()
    {

        scoreText.text ="Score:" + curLevelScore.ToString();

    }
    private void Awake()
    {
        
        Instance = this;
    }

    private void Start()
    {
        IniteDate();
    }

    void IniteDate()
    {
        curLevelCount = 1;
        curLevelTargetScore = 3;
        curLevelScore = 0;
        ShowAllText();
    }


    public void EnterNextLevel()
    {
        print("������һ��");
        switch (curLevelCount) {

            case 1:
                curLevelCount = 2;
                curLevelTargetScore = 4;
                //���µ���UFO���ɺ���
                Launcher.Instance.FireUFO(1);
                ShowAllText();
                break;
            case 2:
                curLevelCount = 3;
                curLevelTargetScore = 5;
                //���µ���UFO���ɺ���
                Launcher.Instance.FireUFO(2);
                ShowAllText();
                break;
            case 3:
                curLevelCount++;
                GameOver();

                break;


        }


    }


    public void GameOver()
    {

        //��Ϸ����
        gameOver.SetActive(true);
        //��ʾ����
        showText.text = Data.Instance.showTextStr3 +
            Data.Instance.showTextStr2 + Data.Instance.showTextStr1;
        //��¼����
        Data.Instance.scoreList.Add(curLevelScore);
        //����
        for (int i = 0; i < Data.Instance.scoreList.Count; i++)
        {
            for (int j = i+1; j < Data.Instance.scoreList.Count; j++)
            {
                if (Data.Instance.scoreList[j]>Data.Instance.scoreList[i])
                {
                    float tempScore = Data.Instance.scoreList[i];
                    Data.Instance.scoreList[i] = Data.Instance.scoreList[j];
                    Data.Instance.scoreList[j] = tempScore;

                }
            }
        }
        for (int i = 0; i < scoreTextArray.Length; i++)
        {
            scoreTextArray[i].text = Data.Instance.scoreList[i].ToString();
        }
        Time.timeScale = 0;
        Destroy(GameObject.FindGameObjectWithTag("Launcher"));
        GameObject.FindGameObjectWithTag("Time").GetComponent<Text>().text = "Time:" + 0;

    }

    /*

    public void JudgeWinOrLose()
    {

        switch (curLevelCount) {

            case 1:
                
                //ʧ��
                if (curLevelScore < curLevelTargetScore)
                {
                    //���¿�ʼ
                    //��ʼ������
                    curLevelCount = 1;
                    //trialCount = 2;
                    curLevelTargetScore = 3;
                    curLevelScore = 0;
                    //���µ���UFO���ɺ���
                    Launcher.Instance.FireUFO(0);
                    ShowAllText();

                }
                //ʤ��
                else
                {
                    curLevelCount = 2;
                    //trialCount = 3;
                    curLevelTargetScore = 4;
                    curLevelScore = 0;
                    //����UFO���ɺ���
                    Launcher.Instance.FireUFO(1);
                    ShowAllText();

                }
                break;
            case 2:
                //ʧ��
                if (curLevelScore < curLevelTargetScore)
                {
                    //���¿�ʼ
                    //��ʼ������
                    curLevelCount = 2;
                    //trialCount = 3;
                    curLevelTargetScore = 4;
                    curLevelScore = 0;
                    //���µ���UFO���ɺ���
                    Launcher.Instance.FireUFO(1);
                    ShowAllText();
                }
                //ʤ��
                else
                {
                    curLevelCount = 3;
                    //trialCount = 4;
                    curLevelTargetScore = 5;
                    curLevelScore = 0;
                    //����UFO���ɺ���
                    Launcher.Instance.FireUFO(2);
                    ShowAllText();
                }
                break;
            case 3:
                //ʧ��
                if (curLevelScore < curLevelTargetScore)
                {
                    //���¿�ʼ
                    //��ʼ������
                    curLevelCount = 3;
                    //trialCount = 4;
                    curLevelTargetScore = 5;
                    curLevelScore = 0;
                    //����UFO���ɺ���
                    Launcher.Instance.FireUFO(2);
                    ShowAllText();
                }
                //ʤ��
                else
                {
                    //����1��ѭ��
                    curLevelCount = 1;
                    //trialCount = 2;
                    curLevelTargetScore = 3;
                    curLevelScore = 0;
                    //���µ���UFO���ɺ���
                    Launcher.Instance.FireUFO(0);
                    ShowAllText();
                }
                break;
                

        }


    }

    */




    public void ShowAllText()
    {

        ShowRoundText();
        ShowTrialText();
        ShowScoreText();
        UIManager.Instance.ResetTime();

    }







}
