using UnityEngine;

public class SEcontrol : MonoBehaviour
{
    public KeyCode key1;
    public KeyCode key2;
    public AudioSource ef; 

    void Start()
    {
        ef.volume = Settings.volume2;
    }
  
    void Update()
    {

        if (Input.GetKeyDown(key1) || Input.GetKeyUp(key2))
        {
            ef.Play();           
        }
        
    }
}
