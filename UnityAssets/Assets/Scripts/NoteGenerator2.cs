using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Diagnostics;
using System;
using System.IO;
using static Unity.VisualScripting.Member;
using TMPro;

public class NoteGenerator2 : MonoBehaviour
{
    public int index;
    public List<string> beatmap2;
    public static List<GameObject> a2 = new List<GameObject>(); 
    [SerializeField] public GameObject note;
    [SerializeField] public GameObject explosion;
    [SerializeField] public GameObject damage;
    public TextMeshProUGUI grade2;
    private Vector2 screenbounds;
    double targetpoint = -1.66;
    double tp_height = 0.4;
    double note_height = 1.9;
  
    void Start()
    {
        Application.targetFrameRate = 60;
        beatmap2 = NoteGenerator.bmsinfo.BeatInfo2();
        index = 0;
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        
        StartCoroutine(notegen2());

    }

  
    void Update()
    {      
        
        if (Input.GetKeyDown("x") && a2.Count != 0)
        {

            if (Mathf.Abs(a2[0].transform.position.y - Convert.ToSingle(targetpoint)) < Convert.ToSingle(tp_height) / 2)
            {
                grade2.text = "Perfect";
                ScoreManager.combos++;
                GameObject ex = Instantiate(explosion);
                ex.transform.position = a2[0].transform.position;
                Destroy(ex, 0.3f);
                ScoreManager.score += 300;         
          
            }
            else if (Mathf.Abs(a2[0].transform.position.y - Convert.ToSingle(targetpoint)) < Convert.ToSingle(note_height) / 2)
            {
                grade2.text = "Great";
                ScoreManager.combos++;
                GameObject ex = Instantiate(explosion);
                ex.transform.position = a2[0].transform.position;
                Destroy(ex, 0.3f);
                ScoreManager.score += 150;       
          

            }
            else if (Mathf.Abs(a2[0].transform.position.y - Convert.ToSingle(targetpoint)) < Convert.ToSingle(tp_height) / 2 + Convert.ToSingle(note_height) / 2)
            {
                grade2.text = "Good";
                ScoreManager.combos++;
                GameObject ex = Instantiate(explosion);
                ex.transform.position = a2[0].transform.position;
                Destroy(ex, 0.3f);
                ScoreManager.score += 50;     
    
            }
            else
            {
                grade2.text = "Miss";                
                ScoreManager.health -= 10;
                ScoreManager.combostreak.Add(ScoreManager.combos);
                ScoreManager.combos = 0;
                GameObject da = Instantiate(damage);
                da.transform.position = new Vector3(0.1f, -6.6f, -8.0f);
                Destroy(da, 1f);
            }

            Destroy(a2[0]);
            a2.RemoveAt(0);

        }
        
    }

    IEnumerator notegen2()
    {
        yield return new WaitForSeconds(5);
        while (index < beatmap2.Count-1)
        {           
            string timingstr2 = beatmap2[index + 1];
            string timingstr1 = beatmap2[index];
            float timing = Convert.ToSingle((Convert.ToDouble(timingstr2) - Convert.ToDouble(timingstr1)) / 1000);
            yield return new WaitForSeconds(timing);
            GameObject c = Instantiate(note);
            c.transform.position = new Vector3(-1.04f, screenbounds.y, -2.5f);
            a2.Add(c);            
            index++;

        }
    }
}
