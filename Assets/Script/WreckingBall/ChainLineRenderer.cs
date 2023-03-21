using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLineRenderer : MonoBehaviour
{

    public Transform origin;
    public Transform target;
    public LineRenderer lineRenderer;

    public bool isBall = false;

    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.GetComponent<LineRenderer>()){
            lineRenderer = gameObject.GetComponent<LineRenderer>();
        }
        else {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }
        if(origin == null) origin = this.transform;

        if(!isBall) this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, origin.position);
        lineRenderer.SetPosition(1, target.position);
    }
}
