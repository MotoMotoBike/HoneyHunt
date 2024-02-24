using UnityEngine;


public static class SaveData
{
    public static int GetScoreByLevelID(int levelId)
    {
        return PlayerPrefs.GetInt($"Level{levelId}Score", 0);
    }
    public static void SetScoreByLevelID(int levelId,int score)
    {
         PlayerPrefs.SetInt($"Level{levelId}Score", score);
    }
}
