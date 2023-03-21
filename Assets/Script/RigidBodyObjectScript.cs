using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyObjectScript : MonoBehaviour
{

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    

}
