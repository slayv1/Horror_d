using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public Transform arm;
    Rigidbody myRigidbody;
    [HideInInspector] public bool flag = false;
    public float speed = 0.5f;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }
    public void PickUp()
    {
        if (arm.childCount < 1)
        {
            transform.SetParent(arm);
            transform.position = arm.position;
            transform.rotation = arm.rotation;
            myRigidbody.isKinematic = true;
            flag = true;
        }
        else
        {
            Debug.Log("!!!");
        }
    }

    public void Throw ()
    {
        if (flag == true)
        {
            transform.parent = null;
            myRigidbody.isKinematic = false;
            myRigidbody.AddForce(transform.forward * speed);
            flag = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Throw();
        }
    }
}