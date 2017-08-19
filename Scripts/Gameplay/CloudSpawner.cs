using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CloudSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] clouds;

    [SerializeField]
    private GameObject deathCloud, coin, life;

    private float distanceBetweenClouds = 3f;
    private int maxSpawn = 8;

    private float minX, maxX;

    private float lastCloudPositionY;

    public static List<GameObject> cloudsSpawn = new List<GameObject>();
    

    
    private float controlX;


    private GameObject player;

    void Awake()
    {
        cloudsSpawn.Clear();
        controlX = 0;
        SetMinAndMaxX();
        CreateClouds();
        player = GameObject.FindGameObjectWithTag("Player");

    }
	void Start () {

        PositionThePlayer();
	}
	
    void SetMinAndMaxX()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5f;

    }

    void CreateClouds()
    {
        float posY = 0f;

        for (int i = 0; i < maxSpawn; i++)
        {
            Vector3 temp = Vector3.zero;
            temp.y = posY;
            temp.x = Random.Range(minX, maxX);
            temp = Control(temp);
            lastCloudPositionY = posY;
            GameObject tempCloud = null;
            if (Random.value < 0.2f)
            {
                tempCloud = Instantiate(deathCloud, temp, Quaternion.identity) as GameObject;
            }
            else
            {
                tempCloud = Instantiate(clouds[Random.Range(0, clouds.Length)], temp, Quaternion.identity) as GameObject;
            }
            cloudsSpawn.Add(tempCloud);
            posY -= distanceBetweenClouds;
        }

    }

    private Vector3 Control(Vector3 temp)
    {
        if (controlX == 0)
        {
            temp.x = Random.Range(0f, maxX);
            controlX = 1;
        }
        else if (controlX == 1)
        {
            temp.x = Random.Range(0f, minX);
            controlX = 2;
        }
        else if (controlX == 2)
        {
            temp.x = Random.Range(1.0f, maxX);
            controlX = 3;
        }
        else if (controlX == 3)
        {
            temp.x = Random.Range(-1.0f, minX);
            controlX = 0;
        }
        return temp;
    }

    void PositionThePlayer()
    {

        if (cloudsSpawn[0].name.Contains("death"))
        {
            for (int i = 1; i < cloudsSpawn.Count; i++)
            {
                if (!cloudsSpawn[i].name.Contains("death"))
                {
                    Vector3 t = cloudsSpawn[i].transform.position;
                    cloudsSpawn[i].transform.position = new Vector3(cloudsSpawn[0].transform.position.x,
                                                                   cloudsSpawn[0].transform.position.y,
                                                                   cloudsSpawn[0].transform.position.z);

                    cloudsSpawn[0].transform.position = t;
                }
            }
        }

        Vector3 temp = cloudsSpawn[0].transform.position;
        for (int i = 1; i < cloudsSpawn.Count; i++)
        {
            if (temp.y < cloudsSpawn[i].transform.position.y)
            {
                temp = cloudsSpawn[i].transform.position;
            }
        }
        temp.y += 0.8f;
        player.transform.position = temp;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name.Contains("cloud"))
        {
            if (collider.transform.position.y == lastCloudPositionY)
            {                
                Vector3 temp = collider.transform.position;

                for (int i = 0; i < clouds.Length; i++)
                {
                    
                    temp = Control(temp);
                    temp.y -= distanceBetweenClouds;

                    lastCloudPositionY = temp.y;

                    GameObject tempCloud = null;
                    if (Random.Range(0f, 1f) < 0.2f)
                    {
                        tempCloud = Instantiate(deathCloud, temp, Quaternion.identity) as GameObject;
                    }
                    else
                    {
                        tempCloud = Instantiate(clouds[Random.Range(0, clouds.Length)], temp, Quaternion.identity) as GameObject;
                    }
                    cloudsSpawn.Add(tempCloud);

                    if (!tempCloud.name.Contains("death"))
                    {

                        Vector3 temp2 = temp;
                        temp2.y += 0.7f;
                        GameObject collectable = null;

                        if (PlayerScore.lifeScore < 2 && Random.value < 0.1f)
                        {
                            collectable = Instantiate(life, temp2, Quaternion.identity) as GameObject;
                            collectable.GetComponent<SpriteRenderer>().sprite = IGTLGameplayController.lifeSprite;
                        }
                        else
                        {
                            collectable = Instantiate(coin, temp2, Quaternion.identity) as GameObject;
                        }
                    }
                    
                }

            }

        }
    }
}
