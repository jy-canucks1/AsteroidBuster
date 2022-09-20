using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class NoteGenerator4 : MonoBehaviour
{    
    public int index; 
    public List<string> beatmap4;
    public static List<GameObject> a4 = new List<GameObject>();   
    [SerializeField] public GameObject target;
    [SerializeField] public GameObject note;
    [SerializeField] public GameObject explosion;
    [SerializeField] public GameObject damage;
    public TextMeshProUGUI grade4;
    private Vector2 screenbounds;
    double targetpoint = -1.66;
    double tp_height = 0.4;
    double note_height = 1.9;   
    void Start()    {

        Application.targetFrameRate = 60;
        beatmap4 = NoteGenerator.bmsinfo.BeatInfo4();
        index = 0;
        screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));        
        StartCoroutine(notegen4());

    }

    void Update()
    { 
        
        if (Input.GetKeyDown("v") && a4.Count != 0)
        {

            if (Mathf.Abs(a4[0].transform.position.y - Convert.ToSingle(targetpoint)) < Convert.ToSingle(tp_height) / 2)
            {
                grade4.text = "Perfect";
                ScoreManager.combos++;
                GameObject ex = Instantiate(explosion);
                ex.transform.position = a4[0].transform.position;
                Destroy(ex, 0.3f);
                ScoreManager.score += 300;
           
            }
            else if (Mathf.Abs(a4[0].transform.position.y - Convert.ToSingle(targetpoint)) < Convert.ToSingle(note_height) / 2)
            {
                grade4.text = "Great";
                ScoreManager.combos++;
                GameObject ex = Instantiate(explosion);
                ex.transform.position = a4[0].transform.position;
                Destroy(ex, 0.3f);
                ScoreManager.score += 150;
           

            }
            else if (Mathf.Abs(a4[0].transform.position.y - Convert.ToSingle(targetpoint)) < Convert.ToSingle(tp_height) / 2 + Convert.ToSingle(note_height) / 2)
            {
                grade4.text = "Good";
                ScoreManager.combos++;
                GameObject ex = Instantiate(explosion);
                ex.transform.position = a4[0].transform.position;
                Destroy(ex, 0.3f);
                ScoreManager.score += 50;           
            }
            else
            {
                grade4.text = "Miss";          
                ScoreManager.health -= 10;
                ScoreManager.combostreak.Add(ScoreManager.combos);
                ScoreManager.combos = 0;
                GameObject da = Instantiate(damage);
                da.transform.position = new Vector3(0.1f, -6.6f, -8.0f);
                Destroy(da, 1f);
            }

            Destroy(a4[0]);
            a4.RemoveAt(0);

        }
       
    }

    IEnumerator notegen4()
    {
        yield return new WaitForSeconds(5);
        while (index < beatmap4.Count-1)
        {           
            string timingstr2 = beatmap4[index + 1];
            string timingstr1 = beatmap4[index];
            float timing = Convert.ToSingle((Convert.ToDouble(timingstr2) - Convert.ToDouble(timingstr1)) / 1000);
            yield return new WaitForSeconds(timing);
            GameObject e = Instantiate(note);
            e.transform.position = new Vector3(4.11f, screenbounds.y, -2.5f);
            a4.Add(e);            
            index++;
        }
    }
}
