using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {


    public GameObject playerShip;
    public Rigidbody shipbody;
    public float AmbientSpeed = 100.0f;

    public float RotationSpeed = 200.0f;

    public float movementSpeed = 500;

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
            shipbody.MovePosition(transform.position + transform.up * Time.deltaTime * movementSpeed);

        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            shipbody.MovePosition(transform.position - transform.up * Time.deltaTime * movementSpeed);

        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            roll += 0.01f;
            print("left pressed");
            shipbody.MovePosition(transform.position - transform.right * Time.deltaTime * movementSpeed);
        }



        if (Input.GetKey(KeyCode.RightArrow))
        {
            roll -= 0.01f;
            print(roll);
            shipbody.MovePosition(transform.position + transform.right * Time.deltaTime * movementSpeed);
        }

        if (roll < 0)
        {
            roll += 0.1f;
        }

        if (roll > 0)
        {
            roll -= 0.1f;
        }

    }
}
