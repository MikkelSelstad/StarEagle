using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public GameObject playerShip;

    public float AmbientSpeed = 100.0f;

    public float RotationSpeed = 200.0f;

    float roll = 0;
    float pitch = 0;
    float yaw = 0;

    void UpdateFunction()
    {


            
       }

    // Update is called once per frame
    void Update () {

        Quaternion AddRot = Quaternion.identity;

        //roll = Input.GetAxis("Roll") * (Time.deltaTime * RotationSpeed);
        //pitch = Input.GetAxis("Pitch") * (Time.deltaTime * RotationSpeed);
        //yaw = Input.GetAxis("Yaw") * (Time.deltaTime * RotationSpeed);
        AddRot.eulerAngles = new Vector3(-pitch, yaw, -roll);
        GetComponent<Rigidbody>().rotation *= AddRot;
        Vector3 AddPos = Vector3.forward;
        AddPos = playerShip.GetComponent<Rigidbody>().rotation * AddPos;
        GetComponent<Rigidbody>().velocity = AddPos * (Time.deltaTime * AmbientSpeed);

        Mathf.Clamp(roll, 2, -2);

        if (Input.GetKeyDown("up"))
        {
            AmbientSpeed = 500;
 
        }

        if (Input.GetKey("left"))
        {
            roll += 1;
            print("left pressed");
        }

        

        if (Input.GetKey("right"))
        {
            roll -= 1;
            print(roll);
        }

    }
}
