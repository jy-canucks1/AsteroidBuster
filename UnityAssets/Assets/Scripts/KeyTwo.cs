using UnityEngine;

public class KeyTwo : MonoBehaviour
{      
    [SerializeField] GameObject damage;  
    double p = -4.97f; //turret.transform.position.y;
    

    void Start()
    {
        Application.targetFrameRate = 60;     
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -KeyOne.changed * Time.deltaTime, 0);      
        if (transform.position.y < p && NoteGenerator2.a2[0] != null)
        {
            ScoreManager.combos = 0;         
            GameObject da = Instantiate(damage);
            da.transform.position = new Vector3(0.1f, -6.6f, -8.0f);
            Destroy(da, 1f);
            ScoreManager.health -= 10;
            Debug.Log(ScoreManager.health);
            Destroy(NoteGenerator2.a2[0]);
            NoteGenerator2.a2.RemoveAt(0);

        }

    }
   
}
