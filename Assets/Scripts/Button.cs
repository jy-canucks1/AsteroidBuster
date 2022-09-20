using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Button : MonoBehaviour
{
    public KeyCode key;
    public AudioSource firesound;
    int check = 0;   
    void Start()
    {        
        firesound.volume = Settings.volume2;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(key) && check == 0)
        {
            transform.position -= new Vector3(0, 1, 0);
            firesound.Play();
            check = 1;

        }
        if (Input.GetKeyUp(key) && check==1)
        {
            transform.position += new Vector3(0, 1, 0);
            check = 0;
        }
    }
}
