using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class IGTLGameManager : MonoBehaviour {

    public static IGTLGameManager instance;

    [HideInInspector]
    public bool gameStartedFromMainMenu, gameRestartedAfterPlayerDied;

    [HideInInspector]
    public int score, coinScore, lifeScore;
	// Use this for initialization
	void Awake () {
        MakeSingleton();
        Screen.orientation = ScreenOrientation.Portrait;
	}
    void Start()
    {
        InitPrefs();
    }

    void InitPrefs()
    {
        if (!PlayerPrefs.HasKey("IGTL Game Initialized"))
        {
            IGTLGamePreferences.SetEasyDifficulty(0);
            IGTLGamePreferences.SetNormalDifficulty(1);
            IGTLGamePreferences.SetHardDifficulty(0);

            IGTLGamePreferences.SetEasyDifficultyScore(0);
            IGTLGamePreferences.SetNormalDifficultyScore(0);
            IGTLGamePreferences.SetHardDifficultyScore(0);

            IGTLGamePreferences.SetEasyDifficultyCoinScore(0);
            IGTLGamePreferences.SetNormalDifficultyCoinScore(0);
            IGTLGamePreferences.SetHardDifficultyCoinScore(0);

            IGTLGamePreferences.SetMusicState(1);

            PlayerPrefs.SetInt("IGTL Game Initialized", 1);
        }
    }
    void OnLevelWasLoaded()
    {
        if (SceneManager.GetActiveScene().name == "IGTL Gameplay")
        {
            if (gameRestartedAfterPlayerDied)
            {
                IGTLGameplayController.instance.SetScore(score);
                IGTLGameplayController.instance.SetCoinScore(coinScore);
                IGTLGameplayController.instance.SetLifeCount(lifeScore);

                PlayerScore.scoreCount = score;
                PlayerScore.coinScore = coinScore;
                PlayerScore.lifeScore = lifeScore;
            }
            else if (gameStartedFromMainMenu)
            {
                PlayerScore.scoreCount = 0;
                PlayerScore.coinScore = 0;
                PlayerScore.lifeScore = 2;

                IGTLGameplayController.instance.SetScore(0);
                IGTLGameplayController.instance.SetCoinScore(0);
                IGTLGameplayController.instance.SetLifeCount(2);
            }
        }
    }
    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void CheckGameStatus(int score, int coinScore, int lifeScore)
    {
        if (lifeScore < 0)
        {

            if (IGTLGamePreferences.GetEasyDifficulty() == 1)
            {
                if(IGTLGamePreferences.GetEasyDifficultyScore() < score)
                    IGTLGamePreferences.SetEasyDifficultyScore(score);
                if (IGTLGamePreferences.GetEasyDifficultyCoinScore() < coinScore)
                    IGTLGamePreferences.SetEasyDifficultyCoinScore(coinScore);
            }
            else if (IGTLGamePreferences.GetNormalDifficulty() == 1)
            {
                if (IGTLGamePreferences.GetNormalDifficultyScore() < score)
                    IGTLGamePreferences.SetNormalDifficultyScore(score);
                if (IGTLGamePreferences.GetNormalDifficultyCoinScore() < coinScore)
                    IGTLGamePreferences.SetNormalDifficultyCoinScore(coinScore);
            }
            else if (IGTLGamePreferences.GetHardDifficulty() == 1)
            {
                if (IGTLGamePreferences.GetHardDifficultyScore() < score)
                    IGTLGamePreferences.SetHardDifficultyScore(score);
                if (IGTLGamePreferences.GetHardDifficultyCoinScore() < coinScore)
                    IGTLGamePreferences.SetHardDifficultyCoinScore(coinScore);
            }

            gameStartedFromMainMenu = true;
            gameRestartedAfterPlayerDied = false;
            //gameplay controller reload
            IGTLGameplayController.instance.GameOverShowPanel(score, coinScore);
        }
        else
        {
            this.score = score;
            this.lifeScore = lifeScore;
            this.coinScore = coinScore;

            gameRestartedAfterPlayerDied = true;
            gameStartedFromMainMenu = false;

            IGTLGameplayController.instance.PlayerDiedRestartTheGame();
        }
    }
}
