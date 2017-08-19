using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class IGTLMainMenuController : MonoBehaviour {
    [SerializeField]
    private Toggle musicButton;

	// Use this for initialization
	void Start () {
        if (IGTLGamePreferences.GetMusicState() == 1)
        {
            musicButton.isOn = true;
        }
        else
        {
            musicButton.isOn = false;
        }
        MusicToggle();
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.Escape))
            QuitGame();
	}

    public void StartGame()
    {
        SceneFader.instance.LoadLevel("IGTL Gameplay");
        IGTLGameManager.instance.gameStartedFromMainMenu = true;
    }
    public void HighScoreMenu()
    {
        SceneFader.instance.LoadLevel("IGTL High Score Screen");
    }
    public void OptionsMenu()
    {
        SceneFader.instance.LoadLevel("IGTL Options Screen");

    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void MusicToggle()
    {
        MusicController.instance.PlayMusic(musicButton.isOn);
    }
}
