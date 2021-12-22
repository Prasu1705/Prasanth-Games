using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    [SerializeField] float smoothingSpeed;
    [SerializeField] Transform rocketTransform;
    public Boundaries boundaries;
    // Start is called before the first frame update
    void Start()
    {
        rocketTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPos = rocketTransform.position + offset;
  
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y,-4f,4f), transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * smoothingSpeed);
        transform.LookAt(rocketTransform);
    }
}
