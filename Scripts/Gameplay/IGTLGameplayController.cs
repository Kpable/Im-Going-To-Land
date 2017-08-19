using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IGTLGameplayController : MonoBehaviour {
    [SerializeField]
    private Text scoreText, lifeText, coinText, gameOverScoreText, gameOverCoinText;

    [SerializeField]
    private GameObject pausePanel, gameOverPanel, beige, green, yellow;

    [SerializeField]
    private GameObject readyButton;

    private GameObject lifeUI;

    public static Sprite lifeSprite;

    [SerializeField]
    Sprite alienBeigeBadge, alienGreenBadge, alienYellowBadge;

    public static IGTLGameplayController instance;
	// Use this for initialization
	void Awake () {
        MakeInstance();

        lifeUI = GameObject.Find("Life UI");
        SelectPlayer();
	}

    private void SelectPlayer()
    {
        if (IGTLGamePreferences.GetEasyDifficulty() == 1)
        {
            beige.SetActive(true);
            green.SetActive(false);
            yellow.SetActive(false);

            lifeSprite = alienBeigeBadge;
            lifeUI.GetComponent<Image>().sprite = alienBeigeBadge;

        }
        else if (IGTLGamePreferences.GetNormalDifficulty() == 1)
        {
            beige.SetActive(false);
            green.SetActive(true);
            yellow.SetActive(false);

            lifeSprite = alienGreenBadge;
            lifeUI.GetComponent<Image>().sprite = alienGreenBadge;
        }
        else if (IGTLGamePreferences.GetHardDifficulty() == 1)
        {
            beige.SetActive(false);
            green.SetActive(false);
            yellow.SetActive(true);
            lifeSprite = alienYellowBadge;
            lifeUI.GetComponent<Image>().sprite = alienYellowBadge;
        }
    }
    void Start()
    {
        Time.timeScale = 0f;
    }
    private void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void StartTheGame()
    {
        Time.timeScale = 1f;
        readyButton.SetActive(false);
    }
    public void GameOverShowPanel(int finalScore, int finalCoinScore)
    {
        gameOverPanel.SetActive(true);
        gameOverScoreText.text = finalScore.ToString();
        gameOverCoinText.text = finalCoinScore.ToString();
        StartCoroutine(GameOverLoadMainMenu());
    }

    IEnumerator GameOverLoadMainMenu()
    {
        yield return new WaitForSeconds(3f);
        SceneFader.instance.LoadLevel("IGTL Title Screen");

    }

    public void PlayerDiedRestartTheGame()
    {
        StartCoroutine(PlayerDiedRestart());
    }
    IEnumerator PlayerDiedRestart()
    {
        yield return new WaitForSeconds(1f);
        SceneFader.instance.LoadLevel("IGTL Gameplay");

    }
    public void SetLifeCount(int lives)
    {
        lifeText.text = "x" + lives.ToString();
    }

    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void SetCoinScore(int coins)
    {
        coinText.text = "x" + coins.ToString();
    }

    public void PauseTheGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void ResumeTheGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void QuitGame()
    {
        SceneFader.instance.LoadLevel("IGTL Title Screen");
        Time.timeScale = 1f;
    }

}
