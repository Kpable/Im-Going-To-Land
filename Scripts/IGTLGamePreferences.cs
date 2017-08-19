using UnityEngine;
using System.Collections;

public static class IGTLGamePreferences {

    public static string EasyDifficulty = "EasyDifficulty";
    public static string NormalDifficulty = "NormalDifficulty";
    public static string HardDifficulty = "HardDifficulty";

    public static string EasyDifficultyHighScore = "EasyDifficultyScore";
    public static string NormalDifficultyHighScore = "NormalDifficultyScore";
    public static string HardDifficultyHighScore = "HardDifficultyScore";

    public static string EasyDifficultyCoinHighScore = "EasyDifficultyCoinScore";
    public static string NormalDifficultyCoinHighScore = "NormalDifficultyCoinScore";
    public static string HardDifficultyCoinHighScore = "HardDifficultyCoinScore";

    public static string IsMusicOn = "IsMusicOn";

    //NOTE INTS ARE BOOLS 
    //0=FALSE 1=TRUE

    //Difficulties
    public static void SetEasyDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt(IGTLGamePreferences.EasyDifficulty, difficulty);
    }

    public static int GetEasyDifficulty()
    {
        return PlayerPrefs.GetInt(IGTLGamePreferences.EasyDifficulty);
    }

    public static void SetNormalDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt(IGTLGamePreferences.NormalDifficulty, difficulty);
    }

    public static int GetNormalDifficulty()
    {
        return PlayerPrefs.GetInt(IGTLGamePreferences.NormalDifficulty);
    }

    public static void SetHardDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt(IGTLGamePreferences.HardDifficulty, difficulty);
    }

    public static int GetHardDifficulty()
    {
        return PlayerPrefs.GetInt(IGTLGamePreferences.HardDifficulty);
    }
    //End Difficulties

    //Scores
    public static void SetEasyDifficultyScore(int easyScore)
    {
        PlayerPrefs.SetInt(IGTLGamePreferences.EasyDifficultyHighScore, easyScore);
    }

    public static int GetEasyDifficultyScore()
    {
        return PlayerPrefs.GetInt(IGTLGamePreferences.EasyDifficultyHighScore);
    }

    public static void SetNormalDifficultyScore(int normalScore)
    {
        PlayerPrefs.SetInt(IGTLGamePreferences.NormalDifficultyHighScore, normalScore);
    }

    public static int GetNormalDifficultyScore()
    {
        return PlayerPrefs.GetInt(IGTLGamePreferences.NormalDifficultyHighScore);
    }

    public static void SetHardDifficultyScore(int hardScore)
    {
        PlayerPrefs.SetInt(IGTLGamePreferences.HardDifficultyHighScore, hardScore);
    }

    public static int GetHardDifficultyScore()
    {
        return PlayerPrefs.GetInt(IGTLGamePreferences.HardDifficultyHighScore);
    }

    //End Scores

    //Coin Scores
    public static void SetEasyDifficultyCoinScore(int easyCoinScore)
    {
        PlayerPrefs.SetInt(IGTLGamePreferences.EasyDifficultyCoinHighScore, easyCoinScore);
    }

    public static int GetEasyDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(IGTLGamePreferences.EasyDifficultyCoinHighScore);
    }

    public static void SetNormalDifficultyCoinScore(int normalCoinScore)
    {
        PlayerPrefs.SetInt(IGTLGamePreferences.NormalDifficultyCoinHighScore, normalCoinScore);
    }

    public static int GetNormalDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(IGTLGamePreferences.NormalDifficultyCoinHighScore);
    }

    public static void SetHardDifficultyCoinScore(int hardCoinScore)
    {
        PlayerPrefs.SetInt(IGTLGamePreferences.HardDifficultyCoinHighScore, hardCoinScore);
    }

    public static int GetHardDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(IGTLGamePreferences.HardDifficultyCoinHighScore);
    }
    //End Coin Scores

    public static void SetMusicState(int state)
    {
        PlayerPrefs.SetInt(IGTLGamePreferences.IsMusicOn, state);
    }

    public static int GetMusicState()
    {
        return PlayerPrefs.GetInt(IGTLGamePreferences.IsMusicOn);
    }
}
