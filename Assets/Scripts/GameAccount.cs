public class GameAccount
{
    public string username;  
    public int score;
    public int songindex;
    public string rank;
    public int combos;

    public GameAccount(string un, int index)
    {
        username = un;      
        score = 0;
        songindex = index;
        rank = "";
        combos = 0;
    }
    public void Set_score(int result)
    {
        score = result;

    }
    public void Set_songindex(int index)
    {
        songindex = index;

    }
 
    public void Set_rank(string rk)
    {
        rank = rk;

    }
    public void Set_combos(int com)
    {
        combos = com;

    }

    public void SaveGameAccount()
    {
        SaveManager.SaveAccount(this);
    }
    public void LoadGameAccount()
    {
        UserData data = SaveManager.LoadAccount();

        username = data.username;        
      //  Mvolume = data.Mvolume;
        score = data.score;
        songindex = data.songindex;
        rank = data.rank;
        combos = data.combos;
    }

}
