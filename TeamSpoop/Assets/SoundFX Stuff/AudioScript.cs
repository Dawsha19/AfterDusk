using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {
    public AudioClip spoopyClip;
    private int triggerEnter = 0;
    bool soundIsPlaying = false;

    private void OnTriggerEnter(Collider collider)
    {
        AudioTrigger spoopy = GetComponentInParent<Collider>().gameObject.GetComponent<AudioTrigger>();

        if (spoopy == null || soundIsPlaying) {
            return;
        }

        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = spoopyClip;
        audio.Play();

        triggerEnter++;
        soundIsPlaying = true;
    }

    private void OnTriggerExit(Collider collider)
    {
        AudioTrigger spoopy = GetComponentInParent<Collider>().gameObject.GetComponent<AudioTrigger>();

        if (spoopy != null)
        {
            triggerEnter--;
            if (triggerEnter <= 0)
            {
                soundIsPlaying = false;
                AudioSource audio = GetComponent<AudioSource>();
                audio.Stop();
            }
        }
    }
}
