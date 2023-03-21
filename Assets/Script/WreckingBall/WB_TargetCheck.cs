using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WB_TargetCheck : MonoBehaviour
{

    [SerializeField] private Transform BaseObject;
    [SerializeField] private GameObject WreckingBall;

    // Start is called before the first frame update
    void Start()
    {
        BaseObject.gameObject.SetActive(false);
        WreckingBall.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateBall(Transform parent){
        BaseObject.gameObject.SetActive(true);
        WreckingBall.SetActive(true);
        BaseObject.SetParent(parent);
    }
    public void DeactivateBall(){
        BaseObject.gameObject.SetActive(false);
        WreckingBall.SetActive(false);

    }
}
