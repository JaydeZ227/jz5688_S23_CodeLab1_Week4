using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{




    public GameObject ufo;
    public GameObject bomb;
    public float fireTime = 2;
    Transform fireTrans;
    public float fireSpeed = 200;
    Transform ground;
    public static Launcher Instance;
    

    private void Awake()
    {
        Instance = this;
        ground = GameObject.FindGameObjectWithTag("Ground").transform;
        fireTrans = transform.GetChild(0);

        
    }

    private void Start()
    {
        
        FireUFO(0);
    }


    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray thisRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(thisRay,out hitInfo))
            {
                if (hitInfo.transform.tag=="UFO")
                {

                    if (hitInfo.transform.name == "Bomb")
                    {
                        //游戏重新开始
                        hitInfo.transform.GetComponent<UFO>().BombDeath();


                    }
                    else
                    {
                        hitInfo.transform.GetComponent<UFO>().Death();
                    }
                }

            }
        }

    }

    public void FireUFO(int bombCount)
    {

        StartCoroutine(FireUFOI(bombCount));

    }

    IEnumerator FireUFOI(int bombCount)
    {

        yield return new WaitForSeconds(2);
        //print(GameManager.Instance.curLevelTargetScore);
        for (int i = 0; i < GameManager.Instance.curLevelTargetScore; i++)
        {
            int addFireSpeed = Random.Range(0,100);
            int fireIndex = Random.Range(0, fireTrans.childCount);
            GameObject g = Instantiate(ufo, fireTrans.position,
                Quaternion.Euler(-90,0,0)) as GameObject;
            //给UFO初始化显示的名字
            switch (GameManager.Instance.curLevelCount) {
                case 1:
                    g.transform.name = "UFO1";
                    break;
                case 2:
                    g.transform.name = "UFO2";
                    break;
                case 3:
                    g.transform.name = "UFO3";
                    break;
            }
            //GameObject g = Instantiate(ufo, fireTrans.position,
            //    Quaternion.identity) as GameObject;
            //加入Ground
            g.transform.SetParent(ground);
            if (ground.Find("Empty"))
            {
                Destroy(ground.Find("Empty").gameObject);
            }
            //g.GetComponent<Rigidbody>().AddForce(
            //    fireTrans.GetChild(fireIndex).up
            //    *(fireSpeed+addFireSpeed));
            Vector2 fireDir = new Vector2(Random.Range(-360,360), Random.Range(-360, 360));
            g.GetComponent<Rigidbody>().AddForce(fireDir.normalized*(fireSpeed + addFireSpeed));
            yield return new WaitForSeconds(0.3f);
        }
        for (int i = 0; i < bombCount; i++)
        {
            int addFireSpeed = Random.Range(0, 100);
            int fireIndex = Random.Range(0, fireTrans.childCount);
            GameObject g = Instantiate(bomb, fireTrans.position,
                Quaternion.Euler(-90, 0, 0)) as GameObject;
            //GameObject g = Instantiate(ufo, fireTrans.position,
            //    Quaternion.identity) as GameObject;
            //加入Ground
            g.transform.SetParent(ground);
            if (ground.Find("Empty"))
            {
                Destroy(ground.Find("Empty").gameObject);
            }
            //g.GetComponent<Rigidbody>().AddForce(
            //    fireTrans.GetChild(fireIndex).up
            //    *(fireSpeed+addFireSpeed));
            Vector2 fireDir = new Vector2(Random.Range(-360, 360), Random.Range(-360, 360));
            g.GetComponent<Rigidbody>().AddForce(fireDir.normalized * (fireSpeed + addFireSpeed));
            yield return new WaitForSeconds(0.3f);
        }
        ground.GetComponent<Ground>().isCanJudge = true;


    }



























}
