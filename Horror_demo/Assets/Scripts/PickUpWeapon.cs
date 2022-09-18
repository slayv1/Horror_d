using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    public GameObject camera;
    public float distance = 15f;
    GameObject currentWeapon;
    public Transform arm;
    [HideInInspector] public bool flag = false;
    public float speed = 0.5f;
    Rigidbody myRigidbody;
    bool canPicUp;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) PicUp();
        if (Input.GetKeyDown(KeyCode.Q)) Drop();
        if (Input.GetKeyDown(KeyCode.T)) Throw();
    }

    void PicUp()
    {
        RaycastHit hit;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
        {
            if (hit.transform.tag == "Shell")
            {
                if (canPicUp) Drop();
                {
                    currentWeapon = hit.transform.gameObject;
                    currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
                    currentWeapon.transform.parent = transform;
                    currentWeapon.transform.localPosition = Vector3.zero;
                    currentWeapon.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                    canPicUp = true;
                }
            }
        }
    }

    void Drop()
    {
        currentWeapon.transform.parent = null;
        currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
        canPicUp = false;
        currentWeapon = null;
    }

    public void Throw()
    {
        if (flag == true)
        {
            transform.parent = null;
            myRigidbody.isKinematic = false;
            myRigidbody.AddForce(transform.forward * speed);
            flag = false;
        }
    }
}
