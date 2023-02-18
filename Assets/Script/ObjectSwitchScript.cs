using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSwitchScript : MonoBehaviour
{

    [SerializeField] private GameObject[] objectSet1;
    [SerializeField] private GameObject[] objectSet2;

    // Start is called before the first frame update
    void Start()
    {
        activateSetA();
    }

    void activateSetA(){
        foreach (GameObject set1 in objectSet1)
        {
            set1.SetActive(true);
        }

        foreach (GameObject set2 in objectSet2)
        {
            set2.SetActive(false);
        }
    }


    void activateSetB(){
        foreach (GameObject set1 in objectSet1)
        {
            set1.SetActive(false);
        }

        foreach (GameObject set2 in objectSet2)
        {
            set2.SetActive(true);
        }
    }

    public void objectSetAPressed(){
        activateSetA();
    }

    public void objectSetBPressed(){
        activateSetB();
    }

}
