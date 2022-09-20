using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyOne : MonoBehaviour
{  
    public int j =0;  
    [SerializeField] GameObject damage;   
    public static float notespeed=6f;
    public static float changed;
    public List<List<string>> timingpoint;
    double p = -4.97f; //turret.transform.position.y;

    
    void Start()
    {
        changed = notespeed;
        timingpoint = NoteGenerator.bmsinfo.TimingInfo();
        Application.targetFrameRate = 60;
        StartCoroutine(speedchanger());

    }

    void Update()
    {

        transform.Translate(0, -notespeed * Time.deltaTime, 0);
        if (transform.position.y < p && NoteGenerator.a1[0] != null)
        {
            ScoreManager.combos = 0;
            
            GameObject da = Instantiate(damage);
            da.transform.position = new Vector3(0.1f, -6.6f, -8.0f);
            Destroy(da, 1f);
            ScoreManager.health-=10;
            Debug.Log(ScoreManager.health);
            Destroy(NoteGenerator.a1[0]);
            NoteGenerator.a1.RemoveAt(0);
        }       

    }
    IEnumerator speedchanger()
    {
        while (j < timingpoint.Count-1)
        {
            string tpstr2 = timingpoint[j+1][0];
            string tpstr1 = timingpoint[j][0];
            float tp = (Convert.ToSingle(tpstr2) - Convert.ToSingle(tpstr1)) / 1000;            
            yield return new WaitForSeconds(tp);            
            
            if (timingpoint[j + 1][1][0] == '-')
            {   
                changed = Convert.ToSingle(notespeed * 100 / Convert.ToDouble(timingpoint[j+1][1].Substring(1)));
   
            }            
            j++;           
        }
        yield break;
    }
}
  
