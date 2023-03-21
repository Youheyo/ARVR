using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyObjectsHandler : MonoBehaviour
{

    RigidBodyObjectScript[] rbList;
    // Start is called before the first frame update
    void Start()
    {
        rbList = FindObjectsOfType<RigidBodyObjectScript>();
    }

    public void ActivateRBs(bool activate){
        foreach(RigidBodyObjectScript rb in rbList){
            rb.GetComponent<Rigidbody>().useGravity = activate;
            rb.gameObject.SetActive(activate);
        }
    }

}
