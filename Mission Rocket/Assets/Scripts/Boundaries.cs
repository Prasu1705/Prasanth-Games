using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    // Start is called before the first frame update
    // Update is called once per frame
    public Vector3 Update()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(transform.position);
        transform.position = new Vector3(transform.position.x,Mathf.Clamp(transform.position.y, -4f, screenBounds.y), transform.position.z);
        return transform.position;
    }
}
