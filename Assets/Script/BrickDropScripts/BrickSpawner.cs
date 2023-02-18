using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    [SerializeField]GameHandler handler;
    [SerializeField] private GameObject refObj;
    [SerializeField] private float y_offset;
    // Start is called before the first frame update
    void Start()
    {
        handler = FindObjectOfType<GameHandler>();
        refObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            if(!handler.gameOver)spawnBrick();
        }
    }

    void spawnBrick(){

        Debug.Log("Attempting Spawn");
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Debug.DrawRay(r.origin, r.direction * 1000f, Color.red, 5f);

        if(Physics.Raycast(r, out hit, Mathf.Infinity, 3)){
            Debug.Log("Hit " + hit.collider.name);
            Vector3 spawnPoint = hit.point;
            spawnPoint.y += y_offset;
            GameObject brick = Instantiate(refObj, spawnPoint, Quaternion.identity, transform);

            Color randColor = new Color(Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f), 1 );
            brick.GetComponent<Renderer>().material.SetColor("_Color", randColor);

            brick.SetActive(true);
        }
    }
}
