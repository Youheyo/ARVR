using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOB_Script : MonoBehaviour
{


    void OnTriggerEnter(Collider other){
        Debug.Log(other.gameObject.name + " fell!");
        if(other.gameObject.CompareTag("brick")){
            Debug.Log("Brick fell out of bounds");
            Destroy(other.gameObject);
            GameHandler handler = FindObjectOfType<GameHandler>();
            handler.GameOver();
        }
    }
}
