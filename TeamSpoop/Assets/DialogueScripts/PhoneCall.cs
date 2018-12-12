using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneCall : MonoBehaviour {
   public GameObject phoneButton;
   public DialogueTrigger other;
    private float buttonPress = 0.5f;
    private float nextButtonPress = 0.0f;
    // Use this for initialization


    void ButtonClicked()
    {
        OVRInput.Update();
        if (OVRInput.Get(OVRInput.Button.One) && Time.time > nextButtonPress) {
            //    if (Input.GetKeyDown(KeyCode.Space))
            //   {
            nextButtonPress = Time.time + buttonPress;
            other.TriggerDialogue();
            phoneButton.SetActive(false);
        }
    }
	// Update is called once per frame
	void Update () {
        ButtonClicked();
    }
}
