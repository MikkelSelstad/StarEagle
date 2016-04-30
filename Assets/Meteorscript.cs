using UnityEngine;
using System.Collections;

public class Meteorscript : MonoBehaviour {

    public float rotateX = 0;
    public float rotateZ = 0;
    public float rotateY = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(rotateX, rotateY, rotateZ);


    }
}
