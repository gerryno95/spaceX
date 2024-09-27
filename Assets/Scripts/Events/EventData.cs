using System.Collections;
using UnityEngine;


public class EventData
{
    public enum EventType
    {
        ENEMY_DEAD
    }
    public EventType eventType;
    public GameObject gameObject;
}
