using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class ScoreManager : MonoBehaviour
{   
    public static int health;
    public static string rank;
    public static int combos;
    public static List<int> combostreak = new List<int>();
    public static int score;
    [SerializeField] public TextMeshProUGUI Gameover;
    [SerializeField] private TextMeshProUGUI eval;
    [SerializeField] public TextMeshProUGUI combo;
    [SerializeField] private TextMeshProUGUI scoreboard;
    [SerializeField] private TextMeshProUGUI countdown;
    public Slider healthbar;
    public GameAccount player;
    public float timer;
    void Start()
    {
        combos = 0;
        health = 300;
        score = 0;
        healthbar.maxValue = 300;
        healthbar.value = health;
        timer = 0;
        player = new GameAccount("", 0);
        player.LoadGameAccount();
        StartCoroutine(Waiting());
        Gameover.text = "";
    }
      
    void Update()
    {
        Gameover.text = "";
        timer += Time.deltaTime;
        healthbar.value = health;
        if(health < 0)
        {
            health = 0;
        }
        if (health == 0)
        {

            Gameover.text = "Game Over! \nThe city is doomed! \nPress Space";
            Time.timeScale = 0;
            if (Input.GetKeyDown("space"))
            {

                player.combos = MaxCombos(combostreak);
                player.rank = rank;
                player.score = score;
                player.SaveGameAccount();
                SceneManager.LoadScene(3);

            }
        }
        else if (SoundManagerScript.stop == 1 && !Input.GetKeyDown(KeyCode.Return))            
        {
            combostreak.Add(combos);
            Gameover.text = "The city is saved!\nPress Enter";
            Time.timeScale = 0;
        }
        if (SoundManagerScript.stop == 1 && Input.GetKeyDown(KeyCode.Return))
        {
            Gameover.text = "";
            player.combos = MaxCombos(combostreak);
            player.rank = rank;
            player.score = score;
            player.SaveGameAccount();
            SceneManager.LoadScene(3);
        }

        combo.text = combos.ToString();
        scoreboard.text = score.ToString();

        if (health == 0)
        {
            rank = "F";
        }
        else if (health < 50)
        {

            rank = "D";
        }
        else if (health < 100)
        {

            rank = "C";
        }
        else if (health < 180)
        {

            rank = "B";
        }
        else if (health < 250)
        {
            rank = "A";
        }
        else if (health <= 300)
        {
            rank = "S";
        }

    }

   
    int MaxCombos(List<int> combos_)
    {
        if(combos_.Count == 1)
        {
            return combos;
        }
        int max = 0;
        foreach (int combo in combos_)
        {
            if (max < combo)
            {
                max = combo;
            }

        }
        return max;
    }
   
   public IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1);
        for (int i = 3; i >= 1; i--)
        { 
            countdown.text = Convert.ToString(i);
            yield return new WaitForSeconds(1);
        }
        
        countdown.text = "GO!";
        yield return new WaitForSeconds(1);
        countdown.text = "";
    }
    
}
