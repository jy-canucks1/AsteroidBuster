using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banner : MonoBehaviour
{
    private int OnBanner;
    public int i;
    // Start is called before the first frame update
    void Start()
    {
        OnBanner = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameMenu.banner_num == i)
        {
            if (OnBanner == 0) transform.position = transform.position + new Vector3(2, 0, 0); OnBanner = 1;

        }
        else
        {
            if(OnBanner == 1) transform.position = transform.position - new Vector3(2, 0, 0); OnBanner = 0;
        }
    }
}
