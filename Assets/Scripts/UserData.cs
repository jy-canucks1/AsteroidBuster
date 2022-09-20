[System.Serializable]
public class UserData
{
    public string username;
    public int score;
    public int songindex;
    public string rank;
    public int combos;

    public UserData(GameAccount account)
    {
        username = account.username;      
        score = account.score;
        songindex = account.songindex;
        rank = account.rank;
        combos = account.combos;
    }

}