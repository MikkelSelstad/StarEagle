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

            flyUp();
        }

        print(pitch);
        if (Input.GetKey(KeyCode.DownArrow))
        {

            flyDown();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            flyLeft();
        }



        if (Input.GetKey(KeyCode.RightArrow))
        {

            flyRigth();
        }



        






    }



    // Ship flight controll

    void flyDown()
    {

        bool pastBottomScreenEdge = Camera.main.WorldToScreenPoint(transform.position).y > Screen.height;

        transform.Translate(0, pastBottomScreenEdge ? 0 : .5f, 0);
    }


    void flyUp()
        {
        bool pastTopScreenEdge = Camera.main.WorldToScreenPoint(transform.position).y <= 0;
        transform.Translate(0, pastTopScreenEdge ? 0 : -.5f, 0);
    }


    void flyLeft()
        {
        bool pastLeftScreenEdge = Camera.main.WorldToScreenPoint(transform.position).x <= 0;

        transform.Translate(pastLeftScreenEdge ? 0 : -.5f, 0, 0);
        }

    void flyRigth()
        {
        bool pastRightScreenEdge = Camera.main.WorldToScreenPoint(transform.position).x >= Screen.width;

        transform.Translate(pastRightScreenEdge ? 0 : .5F, 0, 0);
        }



}
