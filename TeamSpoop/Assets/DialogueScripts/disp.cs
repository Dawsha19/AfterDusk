using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class disp : MonoBehaviour
{
    GameObject button;
    // Use this for initialization
    void Start()
    {
        button = GameObject.Find("TESTBUTTON");
    }

    // Update is called once per frame
    void Update()
    {

    }
        void ButtonClicked()
        {
            button.SetActive(false);
        }
}