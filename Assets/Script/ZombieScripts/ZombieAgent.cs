using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAgent : MonoBehaviour
{

    private Animator animator;
    private UnityEngine.AI.NavMeshAgent agent;
        
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isWalking", agent.velocity.sqrMagnitude != 0);
    }

    public void MoveToPosition(Vector3 position)
    {
        ///I'm not sure how agent.isStopped works
        /*
        Debug.Log($"{this.name} is stopped =  {agent.isStopped}");
        if (agent.isStopped)
        {
            agent.isStopped = false;
            Debug.Log("Moving to " + position);
        }
        */
            agent.SetDestination(position);
    }

    public void StopAgent(bool isStopped)
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
            agent.isStopped = isStopped;
        }
    }
}
