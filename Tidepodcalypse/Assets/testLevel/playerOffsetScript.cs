using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerOffsetScript : MonoBehaviour {

    Vector3 offset;

	void Start ()
    {// sets the offset to the object that has this scripts position
        offset = transform.position - GameObject.FindGameObjectWithTag("Player").transform.position;	
	}
	
	void Update ()
    {// adds the above off
        transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + offset;

    }
}
