using System.Collections;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class SoundManagerScript : MonoBehaviour
{
    public AudioSource source =null;
    FileManager fileManager = new FileManager();
    float time = NoteGenerator.delayed;
    public int played = 0;
    public static int stop = 0;
    
    void Start()
    {        
        source = this.GetComponent<AudioSource>();
        source.volume = Settings.volume1;
        StartCoroutine(LoadAudio());
        
    }

    private void Update()
    {
        if (ScoreManager.health == 0 && source.isPlaying == true)
        {
            source.Stop();
        }

        if(played == 1 && !source.isPlaying == true)
        {
            stop = 1;
        }
    }
    IEnumerator LoadAudio()
    {
        yield return new WaitForSeconds(time+7.3f);        
        string fullpath2 = "file:///" + fileManager.GetAudio(GameListManager.currentIndex);
        WWW url = new WWW(fullpath2);
        yield return url;

        source.clip = url.GetAudioClip(false, true);
        source.Play();
        played = 1;
    }

    
}
