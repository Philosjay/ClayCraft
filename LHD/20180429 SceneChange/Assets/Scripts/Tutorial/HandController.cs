using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public FixedJoint joint;
    // Use this for initialization
    void Start()
    {
    }
    void Update()
    {
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Touch");
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.GetComponent<Rigidbody>())
        {

            joint.connectedBody = collision.gameObject.GetComponent<Rigidbody>();
        }
    }
}