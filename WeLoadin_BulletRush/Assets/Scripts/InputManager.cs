using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputControls { NONE, CLICK, HOLD, RELEASE}

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    public GameObject player;
    public delegate void InputController(InputControls input);
    public event InputController OnClickDrag;
    public float rotationSpeed;

    private InputControls inputControls;
    private bool isRotating;
    private Vector3 mouseStartPos, mousecurrentpos, dragDirection;
    private float angle;
    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(Instance);
        }
    }
    void Start()
    {
        inputControls = InputControls.NONE;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isRotating = true;
            OnClickDrag?.Invoke(InputControls.CLICK);
        }
        else if (Input.GetMouseButton(0))
        {
            OnClickDrag?.Invoke(InputControls.HOLD);
            CheckRotation();
        }
        else
        {
            isRotating = false;
            OnClickDrag?.Invoke(InputControls.RELEASE);
        }

    }
    public void CheckRotation()
    {
        if (isRotating)
        {
            mousecurrentpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousecurrentpos.y = transform.position.y;

            dragDirection = mousecurrentpos - mouseStartPos;
            if (dragDirection.magnitude > 0.3f)
            {
                angle = Mathf.Atan2(dragDirection.x, dragDirection.z) * Mathf.Rad2Deg;
                player.transform.rotation = Quaternion.Lerp(player.transform.rotation, Quaternion.AngleAxis(angle, Vector3.up), Time.deltaTime * rotationSpeed);
            }

        }
    }
}
