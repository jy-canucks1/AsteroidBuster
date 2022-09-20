using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using TMPro;

public class NoteGenerator3 : MonoBehaviour
{
    public int index;
    public List<string> beatmap3;
    public static List<GameObject> a3 = new List<GameObject>();  
    [SerializeField] public GameObject note;
    [SerializeField] public GameObject explosion;
    [SerializeField] public GameObject damage;
    public TextMeshProUGUI grade3;
    private Vector2 screenbounds;
    double targetpoint = -1.66;
    double tp_height = 0.4;
    double note_height = 1.9;
  
    void Start()
    {
        Application.targetFrameRate = 60;
        beatmap3 = NoteGenerator.bmsinfo.BeatInfo3();
        index = 0;
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));    
        StartCoroutine(notegen3());

    }

    void Update()
    {
            
        if (Input.GetKeyDown("c") && a3.Count!=0)
        {
            if (Mathf.Abs(a3[0].transform.position.y - Convert.ToSingle(targetpoint)) < Convert.ToSingle(tp_height) / 2)
            {
                grade3.text = "Perfect";
                ScoreManager.combos++;
                GameObject ex = Instantiate(explosion);
                ex.transform.position = a3[0].transform.position;
                Destroy(ex, 0.3f);
                ScoreManager.score += 300;              
            
            }
            else if (Mathf.Abs(a3[0].transform.position.y - Convert.ToSingle(targetpoint)) < Convert.ToSingle(note_height) / 2)
            {
                grade3.text = "Great";
                ScoreManager.combos++;
                GameObject ex = Instantiate(explosion);
                ex.transform.position = a3[0].transform.position;
                Destroy(ex, 0.3f);
                ScoreManager.score += 150;        
            }
            else if (Mathf.Abs(a3[0].transform.position.y - Convert.ToSingle(targetpoint)) < Convert.ToSingle(tp_height) / 2 + Convert.ToSingle(note_height) / 2)
            {
                grade3.text = "Good";
                ScoreManager.combos++;
                GameObject ex = Instantiate(explosion);
                ex.transform.position = a3[0].transform.position;
                Destroy(ex, 0.3f);
                ScoreManager.score += 50;        
                               
            }
            else
            {
                grade3.text = "Miss";      
                ScoreManager.health -= 10;
                ScoreManager.combostreak.Add(ScoreManager.combos);
                ScoreManager.combos = 0;
                GameObject da = Instantiate(damage);
                da.transform.position = new Vector3(0.1f, -6.6f, -8.0f);
                Destroy(da, 1f);
               
            }

            Destroy(a3[0]);
            a3.RemoveAt(0);

        }
        
    }

    IEnumerator notegen3()
    {
        yield return new WaitForSeconds(5);
        while (index < beatmap3.Count-1)
        {
            string timingstr2 = beatmap3[index + 1];
            string timingstr1 = beatmap3[index];
            float timing = Convert.ToSingle((Convert.ToDouble(timingstr2) - Convert.ToDouble(timingstr1)) / 1000);
            yield return new WaitForSeconds(timing);
            GameObject d = Instantiate(note);
            d.transform.position = new Vector3(1.59f, screenbounds.y, -2.5f);           
            a3.Add(d);            
            index++;

        }
    }
}
