using UnityEngine;

public class KeyThree : MonoBehaviour
{   
    [SerializeField] GameObject damage;
    double p = -4.97f; //turret.transform.position.y;
    
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;      

    }

    // Update is called once per frame
    void Update()
    {
       
        transform.Translate(0, -KeyOne.changed * Time.deltaTime, 0);   
        if (transform.position.y < p && NoteGenerator3.a3[0] != null)
        {
            ScoreManager.combos = 0;
            
            GameObject da = Instantiate(damage);
            da.transform.position = new Vector3(0.1f, -6.6f,-8.0f);
            Destroy(da, 1f);
            ScoreManager.health -= 10;
            Debug.Log(ScoreManager.health);
            Destroy(NoteGenerator3.a3[0]);
            NoteGenerator3.a3.RemoveAt(0);

        }

    }
    
}

