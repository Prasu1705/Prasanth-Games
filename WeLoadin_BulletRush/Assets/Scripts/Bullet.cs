using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody bulletRigidBody;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        bulletRigidBody = GetComponent<Rigidbody>();
        bulletRigidBody.AddForce(bulletRigidBody.transform.forward *speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
