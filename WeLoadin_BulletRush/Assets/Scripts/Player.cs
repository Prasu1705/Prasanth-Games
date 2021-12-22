using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 mouseStartPos;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        InputManager.Instance.OnClickDrag += ClickDragControls;
    }

    // Update is called once per frame
    void ClickDragControls(InputControls inputControls)
    {
        switch(inputControls)
        {
            case InputControls.CLICK:
                mouseStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mouseStartPos.y = transform.position.y;
                break;
            case InputControls.HOLD:
                PlayerManager.Instance.player.transform.position += PlayerManager.Instance.player.transform.forward * speed * Time.deltaTime;
                break;
            case InputControls.RELEASE:
                break;
        }
    }
}
