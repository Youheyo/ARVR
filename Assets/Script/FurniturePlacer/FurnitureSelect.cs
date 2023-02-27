using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureSelect : MonoBehaviour
{

    PlaceFurnitureScript PlacerScript;

    private void Start(){
        if(PlacerScript == null){
            PlacerScript = FindObjectOfType<PlaceFurnitureScript>();
        }
    }
    public void SelectFurniture(GameObject SelectedFurniture){
        PlacerScript.SelectedObject = SelectedFurniture;
    }
}
