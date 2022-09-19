using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{

    private Transform arm;
    private Transform Player;
    private Rigidbody rd;

    public float pickUpDistance;
    public float forceMulti;

    public bool readyToThrow;
    public bool itemIsPicked;



    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();
        Player = GameObject.Find("Player").transform;
        arm = GameObject.Find("arm").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && itemIsPicked == true && readyToThrow)
        {
            forceMulti += 300 * Time.deltaTime;
        }
        pickUpDistance = Vector3.Distance(Player.position, transform.position);

        if (pickUpDistance <= 2)
        {
            if(Input.GetKey(KeyCode.E) && itemIsPicked == false && arm.childCount < 1)
            {
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<BoxCollider>().enabled = false;
                this.transform.position = arm.position;
                this.transform.parent = GameObject.Find("arm").transform;

                itemIsPicked = true;
                forceMulti = 0;
            }
        }
        if(Input.GetKeyUp(KeyCode.E) && itemIsPicked == true)
        {
             readyToThrow = true;
             if(forceMulti > 10)
             {
                  rd.AddForce(Player.transform.forward * forceMulti);
                  this.transform.parent = null;
                  GetComponent<Rigidbody>().useGravity = true;
                  GetComponent<BoxCollider>().enabled = true;

                  itemIsPicked = false;

                  forceMulti = 0;
                  readyToThrow = false;
             }
             forceMulti = 0;
        }
    }
}
