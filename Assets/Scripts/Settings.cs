using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    // Start is called before the first frame update
    public static float volume1 =0.64f;
    public static float volume2 =0.64f;
    public Slider MV;
    public Slider SEV;
   
    void Awake()
    {
        MV.maxValue = 1f;
        MV.value = volume1;
        SEV.maxValue = 1f;
        SEV.value = volume2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            volume1 -= 0.14f;
            MV.value = volume1;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            volume1 += 0.14f;
            MV.value = volume1;
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            volume2 -= 0.14f;
            SEV.value = volume2;
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            volume2 += 0.14f;
            SEV.value = volume2;
        }
    }
}
