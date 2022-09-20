using UnityEngine;
using UnityEngine.SceneManagement;
public class GameMenu : MonoBehaviour
{
    public static int banner_num;         
    public GameObject settings;
    public GameObject selector;
    public int check = 0;
    void Start()
    {
        banner_num = 1;                
        settings.SetActive(false);        
    }
       
    void Update()
    {
        if (check==0 && Input.GetKeyDown(KeyCode.DownArrow))
        {
            
            if (banner_num == 3) banner_num = 1;
            else banner_num++;

        }
        if (check==0 && Input.GetKeyDown(KeyCode.UpArrow))
        {
          
            if (banner_num == 1) banner_num = 3;
            else banner_num--;
        }

        if (banner_num == 1 && Input.GetKeyDown(KeyCode.Return))
        {
            
            SceneManager.LoadScene(1);
        }
        if (check == 0 && banner_num == 2 && Input.GetKey(KeyCode.Return))
        {
            
            selector.SetActive(false);
            settings.SetActive(true);    
            check = 1;
        }
        else if (check == 1 && banner_num == 2 && Input.GetKey(KeyCode.Space))
        {
            settings.SetActive(false);
            selector.SetActive(true);           
            check = 0;
        }
        if (banner_num == 3 && Input.GetKeyDown(KeyCode.Return))
        {
            Application.Quit();
        }

    }
   
}