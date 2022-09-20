using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;
using System.IO;
using UnityEngine.Networking;


public class GameListManager : MonoBehaviour
{
    private string endPoint = "https://asteroid-buster-app.herokuapp.com/game_record";
    public static int currentIndex;
    public int track_num;  
    public static List<BMSreader> info = new List<BMSreader>();
    public AudioSource track = null;
    public TextMeshProUGUI title;
    public TextMeshProUGUI artist;
    public TextMeshProUGUI version;
    public TextMeshProUGUI track_index;
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private TextMeshProUGUI alertText;
    public GameObject[] arrow = new GameObject[4];
    public GameObject album;
    private Sprite albumpic;      
    public float timer;
    FileManager fileManager = new FileManager();
    public GameObject nowShowing;
       
    private void Awake()
    {       
        track_num = fileManager.folderList().Count;     
        currentIndex = 0;
    }

    void Start()
    {                             
        track_index.text = "";
        title.text = "";
        artist.text = "";
        version.text = "";
        for (int i = 0; i < track_num; i++)
        {
            string path = fileManager.GetBms(i);
            Debug.Log(path);
            BMSreader b = new BMSreader(path);      
            info.Add(b);
        }
        arrow[0].SetActive(true);
        arrow[1].SetActive(true);
        arrow[2].SetActive(false);
        arrow[3].SetActive(false);   
        albumpic = LoadSprite(fileManager.GetImg(currentIndex));
        album.GetComponent<SpriteRenderer>().sprite = albumpic;
        LoadMusic(currentIndex);
        nowShowing = Instantiate(album);
          
    }

    
    // Update is called once per frame
    void Update()
    {
        usernameInputField.interactable = true;
        track_index.text = Convert.ToString(currentIndex + 1);
        title.text = info[currentIndex].BasicInfo()[0];
        artist.text = info[currentIndex].BasicInfo()[1];
        version.text = info[currentIndex].BasicInfo()[2];       
        arrow[0].SetActive(true);
        arrow[1].SetActive(true);
        arrow[2].SetActive(false);
        arrow[3].SetActive(false);
        albumpic = LoadSprite(fileManager.GetImg(currentIndex));
        album.GetComponent<SpriteRenderer>().sprite = albumpic;
        

        if (!GameObject.Find("album(Clone)"))
        {
            nowShowing = Instantiate(album);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {                       
            Destroy(nowShowing);
            arrow[1].SetActive(false);
            arrow[3].SetActive(true);
            track.Stop();            
            if (currentIndex == 0) currentIndex = track_num-1;
            else currentIndex--;
            LoadMusic(currentIndex);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {           
            Destroy(nowShowing);
            arrow[0].SetActive(false);
            arrow[2].SetActive(true);
            track.Stop();
            
            if (currentIndex == track_num-1) currentIndex = 0;
            else currentIndex++;
            LoadMusic(currentIndex);

        }
        if (Input.GetKeyDown(KeyCode.Return))
        {           
            track.Stop();
            StartCoroutine(OnRegisterEnter());            
        }        
        
    }


    private Sprite LoadSprite(string path)
    {
        if (string.IsNullOrEmpty(path)) return null;
        if (File.Exists(path))
        {
            byte[] bytes = File.ReadAllBytes(path);
            Texture2D texture = new Texture2D(1, 1);
            
            texture.LoadImage(bytes);
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, 100, 100), new Vector2(0.5f, 0.5f));
            
            return sprite;
        }
        return null;
    }

    public IEnumerator OnRegisterEnter()
    {
        alertText.text = "Creating new account....";
        GameAccount newAccount = new GameAccount(usernameInputField.text, currentIndex);
            

        UnityWebRequest request = UnityWebRequest.Get($"{endPoint}?songnum={newAccount.songindex}&username={newAccount.username}&score={newAccount.score}&rank={newAccount.rank}&call={0}");
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

            if (request.downloadHandler.text != "Invalid credentials" && request.downloadHandler.text != "Already created.")
            {
                alertText.text = "Welcome! " + newAccount.username;                
                newAccount.SaveGameAccount();               
                while (true)
                {
                    startTime1 += Time.deltaTime;

                    if (startTime1 > 2.0f)
                    {
                        break;
                    }
                    yield return null;
                }
                SceneManager.LoadScene(2);
                yield break;
            }
            else if (request.downloadHandler.text == "Already created.")
            {
                alertText.text = "The user already exists.";          
            }
            else
            {             
                alertText.text = "fill in the blank";
            }

        }
        else
        {
            alertText.text = "Error connecting to the server...";           
        }

        yield break;
    }

    public void LoadMusic(int index)
    {
        track = this.GetComponent<AudioSource>();
        track.volume = Settings.volume1;
        string fullpath2 = "file:///" + fileManager.GetAudio(index);
        WWW url = new WWW(fullpath2);        
        track.clip = url.GetAudioClip(false, true);
        track.Play();
    }
}
