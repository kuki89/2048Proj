using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{

    private bool m_MouseMove = false;
    private CtrlInput m_CtrlInput = new CtrlInput();        // 处理输入
    

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void MouseAction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_MouseMove = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            m_MouseMove = false;
        }

        if (m_MouseMove)
        {

        }
    }

    void TouchAction()
    {
        if (Input.touchCount == 0)
        {
            return;
        }

        var touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {
            // touch
        }
        else if (touch.phase == TouchPhase.Moved)
        {
            // moving ...
        }
    }
}
