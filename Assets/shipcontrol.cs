using UnityEngine;
using System.Collections;

public class shipcontrol : MonoBehaviour
{

    public Transform Target;
    public float RotationSpeed;

    //values for internal use
    private Quaternion _lookRotation;
    private Vector3 _direction;

    // Use this for initialization
    void Start()
    {

    }


    void UpdateFunction()
    {

    }



    // Update is called once per frame
    void Update()
    {

        //find the vector pointing from our position to the target
        _direction = (Target.position - transform.position).normalized;

        //create the rotation we need to be in to look at the target
        _lookRotation = Quaternion.LookRotation(_direction);

        //rotate us over time according to speed until we are in the required rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);

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

}
