using UnityEngine;
using System.Collections;

public class ShipRotation : MonoBehaviour {


    // Use this for initialization
    void Start () {

    }

    
    void UpdateFunction()
    {
            
       }



    // Update is called once per frame
    void Update () {


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
