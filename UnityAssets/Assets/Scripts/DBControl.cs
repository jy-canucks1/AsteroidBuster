using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System;

public class DBControl : MonoBehaviour
{   // backend app server URL
    private string endPoint = "https://asteroid-buster-app.herokuapp.com/game_record";                                                    

    [SerializeField] private TextMeshProUGUI alertText;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI combos;
    [SerializeField] private TextMeshProUGUI healthP;
    [SerializeField] private TextMeshProUGUI totalscore;
    [SerializeField] private TextMeshProUGUI rank;
    [SerializeField] private TextMeshProUGUI info;
    [SerializeField] private TextMeshProUGUI []text = new TextMeshProUGUI[32];
    public AudioClip ef1;
    public AudioClip ef2;
    public AudioClip ef3;
    public AudioSource speaker;
    GameAccount account = new GameAccount("", 0);    
    public int count;
    public int end;
    private void Start()
    {
        speaker = GetComponent<AudioSource>();
        
        speaker.volume = Settings.volume2;
        count = 0;
        account.LoadGameAccount();
        end = 0;
    }

    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.Return))
        {
            count++;
            if (count == 1) OnUpdateScore();
            else if (count == 2) OnUpdateCombo();
            else if (count == 3) OnUpdateHealth();
            else if (count == 4) OnUpdateTotalScore();
            else if (count == 5) OnUpdateRank();
            else StartCoroutine(OnUpdateEnter());


        }
        if (Input.GetKeyDown(KeyCode.Return) && count == 7)
        {
            SceneManager.LoadScene(0);
        }

    }
    public void OnUpdateScore()
    {
        speaker.PlayOneShot(ef1);
        score.text = Convert.ToString(account.score);
    }
    public void OnUpdateCombo()
    {
        speaker.PlayOneShot(ef1);
        combos.text = Convert.ToString(account.combos);
    }
    public void OnUpdateHealth()
    {
        speaker.PlayOneShot(ef1);
        healthP.text = Convert.ToString(Convert.ToSingle(ScoreManager.health / 3)) + "%";
    }
    public void OnUpdateTotalScore()
    {
        speaker.PlayOneShot(ef1);
        totalscore.text = Convert.ToString(account.score + account.combos * 0.7);
    }
    public void OnUpdateRank()
    {
        speaker.PlayOneShot(ef2);
        rank.text = account.rank;
    }
    // Updates User info of Database -> moves to the next stage
    public IEnumerator OnUpdateEnter()
    {
        speaker.PlayOneShot(ef3);
        int input_score = Convert.ToInt32(account.score + account.combos * 0.7);
        string input_rank = account.rank;
        int input_combos = account.combos;
        // loads the data from saved file "account.info"
        GameAccount newAccount = new GameAccount("", 0);
        newAccount.LoadGameAccount();
        newAccount.Set_rank(input_rank);
        newAccount.Set_score(input_score);
        newAccount.Set_combos(input_combos);
        UnityWebRequest request = UnityWebRequest.Get($"{endPoint}?songnum={newAccount.songindex}&username={newAccount.username}&score={newAccount.score}&rank={newAccount.rank}&call={1}");
        var handler = request.SendWebRequest();    
        float startTime = 0.0f;
        float startTime1 = 0.0f;
        while (!handler.isDone)
        {
            startTime += Time.deltaTime;

            if (startTime > 10.0f)
            {
                break;
            }
            yield return null;
        }

        if (request.result == UnityWebRequest.Result.Success)
        {
            string line = request.downloadHandler.text;           
            List<string> userlist = new List<string>();
            for (int i = 0; i < 24; i++) { 
                userlist.Add(" ");             
                
            }
            readline(line, userlist);
            
            int pos = 0;
            int index = 0;
            for(int i = 0; i < 32; i++)
            {
                if (i % 4 == 0)
                {
                    pos++;
                    text[i].text = Convert.ToString(pos);
                }
                else { 
                    text[i].text = userlist[index];
                    index++;
                }
            }
            while (true)
            {
                startTime1 += Time.deltaTime;

                if (startTime1 > 5.0f)
                {
                    break;
                }
                yield return null;
            }
            alertText.text = "Game Over.. \nReturning to the Start";
            count++;
            
            SceneManager.LoadScene(0);
            yield break;

        }
        else
        {
            while (true)
            {
                startTime1 += Time.deltaTime;

                if (startTime1 > 5.0f)
                {
                    break;
                }
                yield return null;
            }
            alertText.text = "Error connecting to the server...";
            count++;
            
            SceneManager.LoadScene(0);
            yield break;
        }     
        
        
    }
 
    public void readline(string longline, List<string> list)
    {
        int tmp = 0;
        int idx = 0;
        for (int i = 0; i < longline.Length; i++)
        {            
            if (longline[i] == ',' )
            {

                Debug.Log(longline.Substring(tmp, i - tmp) +"   "+ i);
                list[idx] = longline.Substring(tmp, i - tmp);
                idx++;
                tmp = i + 1;
            }
        }
    }
}