using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : MonoBehaviour {

    public GameObject contBot;
    // Use this for initialization


   public void ContButtonClicked()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            contBot.GetComponent<DialogueManager>().DisplayNextSentence();
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        ContButtonClicked();
    }
}
