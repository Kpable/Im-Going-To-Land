using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class IGTLHighScoreController : MonoBehaviour {
    [SerializeField]
    private Text easyHighScoreText, easyHighCoinScoreText,
                normalHighScoreText, normalHighCoinScoreText,
                hardHighScoreText, hardHighCoinScoreText;
	// Use this for initialization
	void Start () {
        easyHighScoreText.text = IGTLGamePreferences.GetEasyDifficultyScore().ToString();
        easyHighCoinScoreText.text = IGTLGamePreferences.GetEasyDifficultyCoinScore().ToString();
        normalHighScoreText.text = IGTLGamePreferences.GetNormalDifficultyScore().ToString();
        normalHighCoinScoreText.text = IGTLGamePreferences.GetNormalDifficultyCoinScore().ToString();
        hardHighScoreText.text = IGTLGamePreferences.GetHardDifficultyScore().ToString();
        hardHighCoinScoreText.text = IGTLGamePreferences.GetHardDifficultyCoinScore().ToString();
	}
	
    public void TitleScreen()
    {
        SceneFader.instance.LoadLevel("IGTL Title Screen");
    }

}
