using UnityEngine;
using System.Collections;

public class CloudCollector : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name.Contains("cloud"))
        {
            CloudSpawner.cloudsSpawn.Remove(collider.gameObject);
            Destroy(collider.gameObject);
        }

        if (collider.name.Contains("Coin") || collider.name.Contains("Life"))
        {
            //CloudSpawner.collectablesSpawn.Remove(collider.gameObject);
            Destroy(collider.gameObject);
        }
    }
}
