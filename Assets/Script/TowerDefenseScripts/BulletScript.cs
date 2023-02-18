using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    private Rigidbody m_Rigidbody;
    [SerializeField] private float lifeTime = 5.0f;
    float timePassed = 0.0f;
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision Other)
    {
        if(Other.gameObject.tag == "Enemy")
        {
            Destroy(Other.gameObject);
            Destroy(this.gameObject);
        }
    }

    void Update(){
        timePassed += Time.deltaTime;
        if(timePassed >= lifeTime){
            Destroy(this.gameObject);
        }
        //print(timePassed);
    }

    void FixedUpdate()
    {

    }
}
