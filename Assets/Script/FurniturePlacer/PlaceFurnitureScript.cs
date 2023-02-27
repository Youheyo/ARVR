using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceFurnitureScript : MonoBehaviour
{
    [SerializeField] public GameObject SelectedObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetMouseButtonDown(0)){
            if(SelectedObject != null){
                PlaceSelectedFurniture();
            }else{
                //Move the raycasted object
            }
        }
    }

    void PlaceSelectedFurniture(){
        Debug.Log($"Attempting to Place {SelectedObject.name}");
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(r.origin, r.direction * 1000f, Color.red, 5f);

        if (Physics.Raycast(r, out RaycastHit hit, Mathf.Infinity)){
            Debug.Log("Hit " + hit.collider.name);
            Vector3 spawnPoint = hit.point;
            SelectedObject.transform.position = spawnPoint;

            SelectedObject.TryGetComponent<PlacableFurniture>(out PlacableFurniture placeComponent);
            placeComponent.isPlaced = true;

            SelectedObject.SetActive(true);

            SelectedObject = null;
        }
    }

    void MoveSelectedFurniture(){

        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(r.origin, r.direction * 1000f, Color.red, 5f);

        if (Physics.Raycast(r, out RaycastHit hit, Mathf.Infinity, 3)){

            if(!hit.collider.GetComponent<PlacableFurniture>().isPlaced) return;

            Debug.Log($"Attempting to reposition {SelectedObject.name}");

            Vector3 spawnPoint = hit.point;
            SelectedObject.transform.position = spawnPoint;

            SelectedObject.TryGetComponent<PlacableFurniture>(out PlacableFurniture placeComponent);
            placeComponent.isPlaced = true;

            SelectedObject.SetActive(true);
        }
    }
}
