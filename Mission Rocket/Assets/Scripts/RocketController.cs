using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float thrustForce =100f;
    [SerializeField] float rotationForce = 10f;
    [SerializeField] ParticleSystem flame;
    public AudioSource audioPlay;
    public Button ThrustButton;
    private bool thrust;
    private bool moveleft;
    private bool moveright;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        flame = gameObject.GetComponentInChildren<ParticleSystem>();
    }

    public void PointerDownThrust()
    {
        thrust = true;
    }

    public void PointerUpThrust()
    {
        thrust = false;
    }

    public void PointerDownLeft()
    {
        moveleft = true;
    }

    public void PointerUpLeft()
    {
        moveleft = false;
    }

    public void PointerDownRight()
    {
        moveright = true;
    }
    public void PointerUpRight()
    {
        moveright = false;
    }
    void Update()
    {
        CheckThrust();
        CheckRotation();
    }

    private void CheckRotation()
    {
        if(moveleft)
        {
            ProcessLeftRotation();
        }
        else if(moveright)
        {
            ProcessRightRotation();
        }
    }

    private void CheckThrust()
    {
        if(thrust)
        {
            ProcessThrust();
        }
        else
        {
            StopEffects();
        }
    }

    void ProcessThrust()
    {
            rb.AddRelativeForce(Vector3.up * thrustForce *Time.deltaTime);
            if(!flame.isPlaying)
            {
                flame.Play();
            }
            if(!audioPlay.isPlaying)
            {
                audioPlay.Play();
            }
    }
    void ProcessLeftRotation()
    {
            rb.freezeRotation = true;
            transform.Rotate(Vector3.back * rotationForce * Time.deltaTime);
            rb.freezeRotation = false;
        
    }
    void ProcessRightRotation()
    { 
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward *rotationForce * Time.deltaTime);
        rb.freezeRotation = false;
    }
    void StopEffects()
    {
            audioPlay.Stop();
            flame.Stop();
        
    }

}

