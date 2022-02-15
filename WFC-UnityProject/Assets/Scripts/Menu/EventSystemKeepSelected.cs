using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class EventSystemKeepSelected : MonoBehaviour
{
    EventSystem eventSystem;
    GameObject lastSelectedButton = null;

    void Start()
    {
        eventSystem = this.GetComponent<EventSystem>();
        lastSelectedButton = eventSystem.firstSelectedGameObject;
        eventSystem.SetSelectedGameObject(lastSelectedButton);
    }

    void Update()
    {
        if (eventSystem != null)
        {
            if (eventSystem.currentSelectedGameObject != null)
            {
                lastSelectedButton = eventSystem.currentSelectedGameObject;
            }
            else
            {
                eventSystem.SetSelectedGameObject(lastSelectedButton);
            }
        }
    }
}