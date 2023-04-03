using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetName : MonoBehaviour
{


    public string thisName = "";


    private void Awake()
    {
        transform.name = thisName;
    }







}
