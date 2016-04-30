using UnityEngine;
using System.Collections;

public class Cameracontrol : MonoBehaviour {

    public GameObject shipCam;

    public float AmbientSpeed = 500.0f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 AddPos = Vector3.forward;
        GetComponent<Rigidbody>().velocity = AddPos * (Time.deltaTime * AmbientSpeed);

    }
}
