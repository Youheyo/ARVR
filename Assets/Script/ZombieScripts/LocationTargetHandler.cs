using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class LocationTargetHandler : MonoBehaviour
{

    private ObserverBehaviour locationTarget;
    private bool isTracked = false;
    // Start is called before the first frame update
    void Start()
    {
        var obj = GameObject.FindGameObjectWithTag("LocationTarget");
        locationTarget = obj.GetComponent<ObserverBehaviour>();
        if(locationTarget != null)
        {
            locationTarget.OnTargetStatusChanged += OnTargetStatusChanged;
        }
        else
        {
            Debug.LogError("Location Target not found");
        }
    }

    void OnTargetStatusChanged(ObserverBehaviour target, TargetStatus targetStatus)
    {
        Debug.Log($"OnTargetStatusChanged: {target.name} - {targetStatus.StatusInfo}");
        if(targetStatus.Status == Status.NO_POSE)
        {
            OnTargetLost();
        }
        else
        {
            OnTargetFound();
        }
    }

    private Vector3 TranslateBeaconPosition()
    {
        return Camera.main.WorldToScreenPoint(locationTarget.transform.position);
    }

    private void OnTargetFound()
    {
        ZombieAgentController.Instance.StopAgents(false);
        ZombieAgentController.Instance.OnTap(TranslateBeaconPosition());
        isTracked = true;
    }

    private void OnTargetLost()
    {
        ZombieAgentController.Instance.StopAgents(true);
        isTracked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isTracked)
        {
            ZombieAgentController.Instance.OnTap(TranslateBeaconPosition());
        }
    }
}
