
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EventType
{
    ShowText,
    Chat,
    ShowMenu,
    HideMenu,
    事故后果分析,
    风险辨识,
    ShowTask,
    HideTask,
    HAZOP分析,
    风险管控措施类别,
    风险管控措施要求,
    实施跟踪,
    开始考核,
    任务完成,
    NextBtn,
    当前进度,
    HAZOP分析完成,
    HAZOP初始化,
    布局图状态设置,
    HAZOP步骤,
}
public class EventCenter 
{
    private static EventCenter instance;
    public static EventCenter Instance {
        get { 
        if (instance == null)
            {
                instance = new EventCenter();
            }
            return instance;
        }
    }


    private static Dictionary<EventType, Delegate> m_EventTable = new Dictionary<EventType, Delegate>();

    public void AddEvent(EventType type,Action action)
    {
      
        if(m_EventTable.ContainsKey(type))
        {
            m_EventTable[type] =(Action)m_EventTable[type]+ action;
        }
        else
        {
            m_EventTable.Add(type, action);
        }

    }

    public void RomeEvent(EventType type)
    {

        if (m_EventTable.ContainsKey(type))
        {
            m_EventTable.Remove(type);
        }
    }

    public void SendEvent(EventType type)
    {
        if (m_EventTable.ContainsKey(type))
        {
            Action action = (Action)m_EventTable[type];
            action.Invoke();
        }
    }
}
