using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArea : MonoBehaviour
{

    public int maxPlayerHP = 3;
    public int playerHP = 3;

    TD_GameHandler handler;

    void Start(){
        restoreHP();
        handler = FindObjectOfType<TD_GameHandler>();
    }

    private void OnTriggerEnter(Collider other){
        //Debug.Log($"{other.gameObject.tag} entered the player area!");
        if(other.gameObject.CompareTag("Enemy")){
            playerHP--;
            Mathf.Clamp(playerHP,0, maxPlayerHP);
            Destroy(other.gameObject);
        }

        if(playerHP <= 0){
            GameOver();
        }
    }

    void GameOver(){
        handler.EndGame();
    }

    public void restoreHP(){
        playerHP = maxPlayerHP;
    }
}
