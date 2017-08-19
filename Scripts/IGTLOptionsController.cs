using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class IGTLOptionsController : MonoBehaviour {

    [SerializeField]
    private Toggle easyButton, normalButton, hardButton;

	// Use this for initialization
	void Start () {
	    if(IGTLGamePreferences.GetEasyDifficulty() == 1)
        {
            easyButton.isOn = true;
        }
        else if(IGTLGamePreferences.GetNormalDifficulty() == 1)
        {
            normalButton.isOn = true;
        }
        else if(IGTLGamePreferences.GetHardDifficulty() == 1)
        {
            hardButton.isOn = true;
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetInitialDifficulty(string difficulty)
    {
        switch (difficulty)
        {
            case "easy":
                IGTLGamePreferences.SetEasyDifficulty(1);
                IGTLGamePreferences.SetNormalDifficulty(0);
                IGTLGamePreferences.SetHardDifficulty(0);
                break;
            case "normal":
                IGTLGamePreferences.SetEasyDifficulty(0);
                IGTLGamePreferences.SetNormalDifficulty(1);
                IGTLGamePreferences.SetHardDifficulty(0);
                break;
            case "hard":
                IGTLGamePreferences.SetEasyDifficulty(0);
                IGTLGamePreferences.SetNormalDifficulty(0);
                IGTLGamePreferences.SetHardDifficulty(1);
                break;
            default:
                break;
        }
    }

    public void TitleScreen()
    {
        SceneFader.instance.LoadLevel("IGTL Title Screen");

    }

}
