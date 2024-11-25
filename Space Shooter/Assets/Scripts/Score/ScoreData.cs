
/// <summary>
/// Stores the player username and their highscore. Used to save in json file.
/// </summary>
[System.Serializable]
public class ScoreData
{
    public string Username;
    public int HighestScore;

    public ScoreData(string username, int highestScore)
    {
        Username = username;
        HighestScore = highestScore;
    }
}
