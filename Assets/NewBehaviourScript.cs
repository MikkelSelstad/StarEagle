using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {


    public GameObject playerShip;
    public Rigidbody shipbody;
    public float AmbientSpeed = 100.0f;

    public float RotationSpeed = 200.0f;

    public float movementSpeed = 0;

    float roll = 0;
    float pitch = 0;
    float yaw = 0;

    // Use this for initialization
    void Start () {

        shipbody = playerShip.GetComponent<Rigidbody>();
    }


    void UpdateFunction()
    {
            
       }

    // Update is called once per frame
    void Update () {

        Quaternion AddRot = Quaternion.identity;


        AddRot.eulerAngles = new Vector3(-pitch, yaw, -roll);
        GetComponent<Rigidbody>().rotation *= AddRot;
        Vector3 AddPos = Vector3.forward;
        AddPos = playerShip.GetComponent<Rigidbody>().rotation * AddPos;
        GetComponent<Rigidbody>().velocity = AddPos * (Time.deltaTime * AmbientSpeed);


        //Mathf.Clamp(roll, 2, -2);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (pitch < 0.3f)
            {
                pitch += 0.05f;
            }
            shipbody.MovePosition(transform.position + transform.up * Time.deltaTime * movementSpeed);


        }

        print(pitch);
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if(pitch > -0.3f)
            {
                pitch -= 0.05f;
            }
            shipbody.MovePosition(transform.position - transform.up * Time.deltaTime * movementSpeed);

        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (roll < 1.0f)
            {
                roll += 0.05f;
            }

            print("left pressed");
            shipbody.MovePosition(transform.position - transform.right * Time.deltaTime * movementSpeed);
        }



        if (Input.GetKey(KeyCode.RightArrow))
        {
            if(roll > -1.0f)
                {
                roll -= 0.05f;
                }
            shipbody.MovePosition(transform.position + transform.right * Time.deltaTime * movementSpeed);
        }


    }
}
