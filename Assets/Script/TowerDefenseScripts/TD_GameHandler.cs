using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class TD_GameHandler : MonoBehaviour
{

    public UnityEvent startGame;
    public UnityEvent endGame;

    [SerializeField] GameObject EndGamePanel;
    [SerializeField] TMP_Text HPText;
     
    PlayerArea player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerArea>();
    }

    // Update is called once per frame
    void Update()
    {
        HPText.SetText($"HP : {player.playerHP}");
    }

    public void StartGame(){
        startGame.Invoke();
        EndGamePanel.SetActive(false);

    }


    public void EndGame(){
        endGame.Invoke();
        EndGamePanel.SetActive(true);
    }
}
