using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    [SerializeField] public GameObject gameOb1;
    [SerializeField] public GameObject gameOb2;
    [SerializeField] public GameObject gameOb3;
    public float rotatespeed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(rotatespeed, 0, 0) * Time.deltaTime);
        if(GameMenu.banner_num == 1)
        {
            transform.position = new Vector3(transform.position.x, gameOb1.transform.position.y, transform.position.z);         
            
        }
        if (GameMenu.banner_num == 2)
        {
            transform.position = new Vector3(transform.position.x, gameOb2.transform.position.y, transform.position.z);

        }
        if (GameMenu.banner_num == 3)
        {
            transform.position = new Vector3(transform.position.x, gameOb3.transform.position.y, transform.position.z);

        }


    }
}
