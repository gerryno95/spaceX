using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MessageSystem : MonoBehaviour
{
    [SerializeField] float messageHeight = 10f;
    [SerializeField] GameObject textGOPrefab;
    LinkedList<MessageUI> messages = new LinkedList<MessageUI>();

    private void Start()
    {
      
    }
    
    public void AddMessage(string messageText)
    {
        CleanMessageList();

        int k = messages.Count;
        foreach (MessageUI message in messages)
        {
            message.SetHeight(k * messageHeight);
            k -= 1;
        }
        GameObject newMessage = Instantiate(textGOPrefab, transform);
        newMessage.SetActive(true);
        newMessage.GetComponent<TextMeshProUGUI>().text = messageText;
        MessageUI newMessageUI = newMessage.GetComponent<MessageUI>();
        messages.AddLast(newMessageUI);
    }

    private void CleanMessageList()
    {
        while (messages.Count > 0 && messages.First.Value.Ended)
        {
            messages.RemoveFirst();
        }
    }
}
