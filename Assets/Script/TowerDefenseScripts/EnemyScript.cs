using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 5.0f;

    public Transform targetTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision Other)
    {
        if(Other.gameObject.tag == "Player")
        {
            //Health Damaged;
        }
    }
}
