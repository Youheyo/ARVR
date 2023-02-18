using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using Vuforia;
public class GameHandler : MonoBehaviour
{

    public int score;
    private int highScore;

    public GameObject GameOverOverlay;
    public GameObject SettingsOverlay;

    public UnityEvent restart;
    public bool gameOver = false;

    public TMP_Text scoreText;
    public TMP_Text hiScoreText;

    // Start is called before the first frame update
    void Start()
    {
        GameOverOverlay.SetActive(false);
        VuforiaApplication.Instance.OnVuforiaStarted += OnVuforiaStarted;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.SetText($"Score : {score}");
        if(score > highScore){
            highScore = score;
            hiScoreText.SetText($"High Score : {highScore}");
        }
    }

    public void Restart(){
        GameOverOverlay.SetActive(false);
        score = 0;
        gameOver = false;
        restart.Invoke();
    }

    public void GameOver(){
        gameOver = true;
        GameOverOverlay.SetActive(true);
    }

    private void OnVuforiaStarted()
    {
        VuforiaBehaviour.Instance.CameraDevice.SetFocusMode(FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
    }

    public void ResetFocus(){
        Debug.Log("Resetting Focus...");
        VuforiaBehaviour.Instance.CameraDevice.SetFocusMode(FocusMode.FOCUS_MODE_NORMAL);
        StartCoroutine(FocusResetToAuto());
    }

    IEnumerator FocusResetToAuto(){
        yield return new WaitForSeconds(5);

        VuforiaBehaviour.Instance.CameraDevice.SetFocusMode(FocusMode.FOCUS_MODE_TRIGGERAUTO);
        Debug.Log("Focus finished Resetting");

    }
}
