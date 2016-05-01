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

    public int fuel = 100;


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


        if (Input.GetKeyDown(KeyCode.Space))
        {
            print(fuel);
            boost();
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {

            flyUp();
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {

            flyDown();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            print("pader");
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

        transform.Translate(0, pastBottomScreenEdge ? 0 : .2f, 0);
    }


    void flyUp()
        {
        bool pastTopScreenEdge = Camera.main.WorldToScreenPoint(transform.position).y <= 0;
        transform.Translate(0, pastTopScreenEdge ? 0 : -.2f, 0);
    }


    void flyLeft()
        {
        bool pastLeftScreenEdge = Camera.main.WorldToScreenPoint(transform.position).x <= 0;

        transform.Translate(pastLeftScreenEdge ? 0 : -.2f, 0, 0);
        }

    void flyRigth()
        {
        bool pastRightScreenEdge = Camera.main.WorldToScreenPoint(transform.position).x >= Screen.width;

        transform.Translate(pastRightScreenEdge ? 0 : .2F, 0, 0);
        }

    void boost()
        {
            if(fuel > 0)
            {
                GetComponentInParent<Cameracontrol>().AmbientSpeed = 800;
                fuel -= 1;
                print(fuel);
                print("boost");

            }
            else GetComponentInParent<Cameracontrol>().AmbientSpeed = 0;
        }

    }
