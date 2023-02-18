using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAgentController : MonoBehaviour
{

    [SerializeField] private ZombieAgent[] agents;
    private static ZombieAgentController instance;

    public static ZombieAgentController Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<ZombieAgentController>();
            return instance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        agents = GetComponentsInChildren<ZombieAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            OnTap(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        }
    }

    public void OnTap(Vector2 touchPos)
    {
        Debug.Log("Tap Success");
        Ray r = Camera.main.ScreenPointToRay(touchPos);
        Debug.DrawRay(r.origin, r.direction * 10f, Color.red, 5.0f);
        RaycastHit hit;
        int layerMask = LayerMask.GetMask("ImageTarget");
        if(Physics.Raycast(r, out hit, 100, layerMask))
        {
            Debug.Log("Hit " + hit.transform.name);
            Vector3 hitPoint = hit.point;
            MoveAgentsToPosition(hitPoint);
        }
    }

    public void MoveAgentsToPosition(Vector3 position)
    {
        foreach(var agent in agents)
        {
            //Debug.Log("Instructing " + agent.name + " to move");
            agent.MoveToPosition(position);
        }
    }
    public void StopAgents(bool shouldStop)
    {
        foreach(var agent in agents)
        {
            agent.StopAgent(shouldStop);
        }
    }
    public void SetAgentsActive(bool isActive)
    {
        foreach(var agent in agents)
        {
            agent.StopAgent(!isActive);
            agent.gameObject.SetActive(isActive);
        }
    }
}
