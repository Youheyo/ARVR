using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerChecker : MonoBehaviour
{
    [SerializeField]private List<GameObject> TowerBricks;
    [SerializeField] GameHandler Handler;

    public float updateDistance = 0.2f;

    void Start(){
        Handler = FindObjectOfType<GameHandler>();
    }

    void OnTriggerEnter(Collider other){
        if(TowerBricks.Contains(other.gameObject)) return;
        TowerBricks.Add(other.gameObject);
        Handler.score++;    
        transform.position += new Vector3(0.0f, updateDistance, 0.0f);
    }

    /*
    void OnTriggerExit(Collider other){
        if(TowerBricks.Contains(other.gameObject)){
            Handler.GameOver();
        }
    }
    */
    
    public void Restart(){
        transform.localPosition = new Vector3(0,0);
        foreach(GameObject brick in TowerBricks){
            Destroy(brick);
        }
        TowerBricks.Clear();
    }

}
