using IGA.UnityHelpers;
using UnityEngine.Events;

public class EventCollector : Singleton<EventCollector>
{
    public UnityEvent<EventData> onGeneralEvent;

}
