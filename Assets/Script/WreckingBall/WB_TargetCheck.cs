using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WB_TargetCheck : MonoBehaviour
{

    [SerializeField] private Transform BaseObject;

    // Start is called before the first frame update
    void Start()
    {
        BaseObject.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateBall(Transform parent){
        BaseObject.gameObject.SetActive(true);
        BaseObject.SetParent(parent);
    }
    public void DeactivateBall(){
        BaseObject.gameObject.SetActive(false);
    }
}
