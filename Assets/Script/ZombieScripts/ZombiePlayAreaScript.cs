using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;
using TMPro;

public class ZombiePlayAreaScript : MonoBehaviour
{

    public GameObject OverlayPanel;
    [SerializeField]ObserverBehaviour MainImageTarget;
    private bool mainImageFound = false;
    [SerializeField]ObserverBehaviour BeaconImageTarget;
    private bool beaconImageFound = false;

    // Start is called before the first frame update
    void Start()
    {
        OverlayPanel.SetActive(true);
        //VuforiaApplication.Instance.OnVuforiaStarted += OnVuforiaStarted;
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainTargetFound(bool found){
        Debug.Log("Main Target Found " + found);
        mainImageFound = found;
        /*
        if(mainImageFound){
            //OverlayPanel.SetActive(false);
        }
        else{
        OverlayPanel.GetComponentInChildren<TMP_Text>().SetText("Main Image Target not Found");
        OverlayPanel.SetActive(true);
        }
        */
        displayOverlay();
    }

    public void BeaconTargetFound(bool found){
        Debug.Log("Beacon Target Found " + found);
        beaconImageFound = found;
        /*
        if(mainImageFound && beaconImageFound){
            OverlayPanel.SetActive(false);
        }
        else if(mainImageFound && !beaconImageFound){
            OverlayPanel.GetComponentInChildren<TMP_Text>().SetText("Beacon Image Target not Found");
            OverlayPanel.SetActive(true);
        }
        */
        displayOverlay();
    }

    void displayOverlay(){
        if(mainImageFound){
            if(beaconImageFound){
                OverlayPanel.SetActive(false);
            }
            else{
                OverlayPanel.GetComponentInChildren<TMP_Text>().SetText("Beacon Image Target not Found");
                OverlayPanel.SetActive(true);
            }
        }else{
            OverlayPanel.GetComponentInChildren<TMP_Text>().SetText("Main Image Target not Found");
            OverlayPanel.SetActive(true);
        }
    }
}
