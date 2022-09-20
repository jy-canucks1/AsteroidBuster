using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class NoteGenerator : MonoBehaviour
{         
    public static BMSreader bmsinfo;
    public static float delayed=0; 
    public List<string> beatmap1;
    public string firstline;
    public static List<GameObject> a1 = new List<GameObject>();      
    public GameObject note;
    public GameObject explosion;
    public GameObject damage;
    public TextMeshProUGUI grade1;
    private Vector2 screenbounds;
    public FileManager fileManager;
    public int index;
    double targetpoint = -1.66;
    double tp_height = 0.4;
    double note_height = 1.9;

    private void Awake()
    {
        fileManager = new FileManager();
        bmsinfo = new BMSreader(fileManager.GetBms(GameListManager.currentIndex));
        beatmap1 = bmsinfo.BeatInfo1();
        firstline = bmsinfo.Firstline();
    }
    void Start()
    {
        Application.targetFrameRate = 60;        
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        delayed = Convert.ToSingle((Convert.ToDouble(12.03 - targetpoint) / Convert.ToDouble(KeyOne.notespeed)) - Convert.ToDouble(firstline) / 1000);
        index = 0;        
        StartCoroutine(notegen());
        
    }

    void Update()
    {     
        
        if (Input.GetKeyDown("z") && a1.Count != 0)
        {

            if (Mathf.Abs(a1[0].transform.position.y - Convert.ToSingle(targetpoint)) < Convert.ToSingle(tp_height) / 2)
            {
                grade1.text = "Perfect";
                ScoreManager.combos++;
                GameObject ex = Instantiate(explosion);
                ex.transform.position = a1[0].transform.position;
                Destroy(ex, 0.3f);
                ScoreManager.score += 300;
           
            }
            else if (Mathf.Abs(a1[0].transform.position.y - Convert.ToSingle(targetpoint)) < Convert.ToSingle(note_height) / 2)
            {
                grade1.text = "Great";
                ScoreManager.combos++;
                GameObject ex = Instantiate(explosion);
                ex.transform.position = a1[0].transform.position;
                Destroy(ex, 0.3f);
                ScoreManager.score += 150;
                

            }
            else if (Mathf.Abs(a1[0].transform.position.y - Convert.ToSingle(targetpoint)) < Convert.ToSingle(tp_height) / 2 + Convert.ToSingle(note_height) / 2)
            {
                grade1.text = "Good";
                ScoreManager.combos++;
                GameObject ex = Instantiate(explosion);
                ex.transform.position = a1[0].transform.position;
                Destroy(ex, 0.3f);
                ScoreManager.score += 50;         
            }
            else
            {
                grade1.text = "Miss";          
                ScoreManager.health -= 10;
                ScoreManager.combostreak.Add(ScoreManager.combos);
                ScoreManager.combos = 0;
                GameObject da = Instantiate(damage);
                da.transform.position = new Vector3(0.1f, -6.6f, -8.0f);
                Destroy(da, 1f);
            }

            Destroy(a1[0]);
            a1.RemoveAt(0);            

        }       

    }

    IEnumerator notegen()
    {
        yield return new WaitForSeconds(5);        
        while (index < beatmap1.Count-1)
        {          
            string timingstr2 = beatmap1[index + 1];
            string timingstr1 = beatmap1[index];
            float timing = Convert.ToSingle((Convert.ToDouble(timingstr2) - Convert.ToDouble(timingstr1)) / 1000);
            yield return new WaitForSeconds(timing);
            GameObject b = Instantiate(note);
            b.transform.position = new Vector3(-3.509f, screenbounds.y, -2.5f);          
            a1.Add(b);            
            index++;
        }
    }
}
