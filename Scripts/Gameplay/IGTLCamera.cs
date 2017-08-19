using UnityEngine;
using System.Collections;

public class IGTLCamera : MonoBehaviour {

    private float speed = 1f;
    private float acceleration = 0.2f;
    private float maxSpeed = 3.2f;

    private float easySpeed = 3.4f;
    private float normalSpeed = 3.8f;
    private float hardSpeed = 4.2f;

    public bool moveCamera;
	// Use this for initialization
	void Start () {

        if (IGTLGamePreferences.GetEasyDifficulty() == 1)
        {
            maxSpeed = easySpeed;
        }
        else if (IGTLGamePreferences.GetNormalDifficulty() == 1)
        {
            maxSpeed = normalSpeed;
        }
        else if (IGTLGamePreferences.GetHardDifficulty() == 1)
        {
            maxSpeed = hardSpeed;
        }

        moveCamera = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (moveCamera)
        {
            MoveCamera();
        }
	}

    void MoveCamera(){
        Vector3 temp = transform.position;

        float oldY = temp.y;

        float newY = temp.y - (speed * Time.deltaTime);

        temp.y = Mathf.Clamp(temp.y, oldY, newY);

        transform.position = temp;
        speed += acceleration * Time.deltaTime;
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
    }
}
