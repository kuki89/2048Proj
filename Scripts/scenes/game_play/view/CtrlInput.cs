using System;
using UnityEngine;

public class CtrlInput : MonoBehaviour
{
    private Vector3 m_PositionStart;    // 触摸起点
    private int m_MoveLenMin = 30;      // 手指最小有效移动距离
    private float m_TimeStart;          // 开始时间
    private bool m_Flag = false;        // 用于控制操作识别完成后，不松手再滑动，操作无效

    public class EventArgsInputMgr : EventArgs
    {
        public Direction Direction { get; set; }
    }
    public event EventHandler<EventArgsInputMgr> Move;

    // 接收输入事件
    public void Start(Vector3 pos)
    {
        m_PositionStart = pos;          // 记录触摸位置
        m_TimeStart = Time.fixedTime;   // 记录触摸开始时间
        m_Flag = true;                  // 本次操作有效
    }

    // 判断输入方式
    public void CheckMove(Vector3 pos)
    {
        if (m_Flag == false)
        {
            return;
        }
        if (Time.fixedTime - m_TimeStart > 3.0f)
        {
            return;
        }

        var dis = pos - m_PositionStart;
        var len = dis.magnitude;            // 手指移动距离

        if (len < m_MoveLenMin)
        {
            return;
        }

        var degree = Mathf.Rad2Deg * Mathf.Atan2(dis.x, dis.y);     // 返回tan值为x/z的角弧度，再转化为度数

        m_Flag = false;
        if (-45 >= degree && degree >= -135)
        {
            Move(this, new EventArgsInputMgr() { Direction = Direction.Left });
        }
        else if (45 <= degree && degree <= 135)
        {
            Move(this, new EventArgsInputMgr() { Direction = Direction.Right });
        }
        else if (-45 < degree && degree < 45)
        {
            Move(this, new EventArgsInputMgr() { Direction = Direction.Up });
        }
        else if (135 < degree || degree < -135)
        {
            Move(this, new EventArgsInputMgr() { Direction = Direction.Down });
        }
    }
}
