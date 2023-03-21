using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyObjectScript : MonoBehaviour
{

Vector3 OriginalPos;
[SerializeField] float maxDistanceFromOriginalPos = 1000;

public enum RespawnType{Original, Set};

public RespawnType respawnType;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

        OriginalPos = transform.position;
    }
    
    void Update(){
        switch(respawnType){
            case RespawnType.Original: 
                if(Vector3.Distance(OriginalPos, this.transform.position) > maxDistanceFromOriginalPos){
                    transform.position = OriginalPos;
                    rb.velocity = Vector3.zero;
                }
            break;
            case RespawnType.Set:
            break;
            default:
                Debug.Log("Unkown Respawn Type");
            break;
        }
    }
}
