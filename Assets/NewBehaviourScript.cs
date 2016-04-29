using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public GameObject playerShip;

    public float AmbientSpeed = 100.0f;

    public float RotationSpeed = 200.0f;

    

    void UpdateFunction()
    {


            
       }

    // Update is called once per frame
    void Update () {

        Quaternion AddRot = Quaternion.identity;
        float roll = 0;
        float pitch = 0;
        float yaw = 0;
// roll = Input.GetAxis("Roll") * (Time.deltaTime * RotationSpeed);
// pitch = Input.GetAxis("Pitch") * (Time.deltaTime * RotationSpeed);
        //yaw = Input.GetAxis("Yaw") * (Time.deltaTime * RotationSpeed);
        AddRot.eulerAngles = new Vector3(-pitch, yaw, -roll);
        GetComponent<Rigidbody>().rotation *= AddRot;
        Vector3 AddPos = Vector3.forward;
        AddPos = playerShip.GetComponent<Rigidbody>().rotation * AddPos;
        GetComponent<Rigidbody>().velocity = AddPos * (Time.deltaTime * AmbientSpeed);


        if (Input.GetKey("up"))
        {
            AmbientSpeed = 500;
        }
    }
}
