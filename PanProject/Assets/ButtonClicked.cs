using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonClicked : MonoBehaviour
{



    Button thisButton;

    private void Awake()
    {
        thisButton = GetComponent<Button>();
    }


    private void Start()
    {
        thisButton.onClick.AddListener(ClickThis);

    }



    void ClickThis()
    {

        switch (transform.name) {

            case "RestartButton":
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

                break;

        }

    }






















}
