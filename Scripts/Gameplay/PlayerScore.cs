using UnityEngine;
using System.Collections;



public class PlayerScore : MonoBehaviour {
    [SerializeField]
    private AudioClip coinClip, lifeClip;
    private IGTLCamera cameraScript;
    private Vector3 previousPosition;
    private bool countScore;

    public static int scoreCount;
    public static int lifeScore;
    public static int coinScore;
    void Awake()
    {
        cameraScript = Camera.main.GetComponent<IGTLCamera>();
    }
	// Use this for initialization
	void Start () {
        previousPosition = transform.position;
        countScore = true;
        IGTLGameplayController.instance.SetCoinScore(coinScore);
        IGTLGameplayController.instance.SetScore(scoreCount);
        IGTLGameplayController.instance.SetLifeCount(lifeScore);

	}
	
	// Update is called once per frame
	void Update () {
        if (countScore)
        {
            if (transform.position.y < previousPosition.y)
            {
                scoreCount++;
                IGTLGameplayController.instance.SetScore(scoreCount);
            }
            previousPosition = transform.position;
        }

	}

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.name.Contains("Coin"))
        {
            coinScore++;
            scoreCount += 200;
            IGTLGameplayController.instance.SetCoinScore(coinScore);
            IGTLGameplayController.instance.SetScore(scoreCount);
            AudioSource.PlayClipAtPoint(coinClip, transform.position, 3f);
            target.gameObject.SetActive(false);
        }

        if (target.name.Contains("Life"))
        {
            if (lifeScore < 2) 
            { 
                lifeScore++;
            }
            scoreCount += 300;
            IGTLGameplayController.instance.SetLifeCount(lifeScore);
            IGTLGameplayController.instance.SetScore(scoreCount);
            AudioSource.PlayClipAtPoint(lifeClip, transform.position, 1f);
            target.gameObject.SetActive(false);
        }

        if (target.name.Contains("Killzone") || target.name.Contains("death")) 
        {
            Debug.Log("Killed by " + target.name);
            cameraScript.moveCamera = false;
            countScore = false;

            transform.position = new Vector3(-500, -500, 0);
            lifeScore--;
            IGTLGameManager.instance.CheckGameStatus(scoreCount, coinScore, lifeScore);
        }

    }


}
