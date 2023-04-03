using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data
{



    private static Data instance;
    public static Data Instance
    {

        get
        {
            if (instance==null)
            {
                instance = new Data();
            }
            return instance;
        }

    }


    public Data() {

        scoreList = new List<float>();
        scoreList.Add(0);
        scoreList.Add(0);
        scoreList.Add(0);
        scoreList.Add(0);

        showTextList1 = new List<string>();
        showTextList2 = new List<string>();
        showTextList3 = new List<string>();
        showTextList1.Add("And earn $10 a month on Mars."); 
        showTextList1.Add("And earn $10000 a month on Mars.");
        showTextList1.Add("And earn $10000000 a month on Mars.");
        showTextList2.Add("Bulldog. "); 
        showTextList2.Add("Siamese. ");
        showTextList2.Add("Lama. ");
        showTextList2.Add("Raccoon. ");
        showTextList3.Add("You're an enthusiasm ");
        showTextList3.Add("You're a sensitive ");
        showTextList3.Add("You're a confident ");
        showTextList3.Add("You're a competitive ");
        showTextList3.Add("You're a profit-seeking ");


    }



    public List<float> scoreList;



    public string showTextStr1 = "";
    public string showTextStr2 = "";
    public string showTextStr3 = "";
    
    public List<string> showTextList1;
    public List<string> showTextList2;
    public List<string> showTextList3;













}
