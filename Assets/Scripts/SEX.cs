using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEX : MonoBehaviour
{
    public AudioSource ef; 

    void Start()
    {
        ef.volume = Settings.volume2;
    }

    void Update()
    {

        if (Input.anyKeyDown)
        {
            ef.volume = Settings.volume2;
            ef.Play();
        }

    }
}
