using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacableFurniture : MonoBehaviour
{

    public bool isPlaced = false;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        this.GetComponent<Renderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlaced){
          this.GetComponent<Renderer>().enabled = true;

        }
    }
}
