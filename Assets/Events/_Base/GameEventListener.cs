﻿using UnityEngine;

public class GameEventListener : MonoBehaviour
{
    public GameEvent Event;
    public UnityEngine.Events.UnityEvent Response;

    private void OnEnable()
    { Event.RegisterListener(this); }

    private void OnDisable()
    { Event.UnregisterListener(this); }

    public void OnEventRaised()
    { Response.Invoke(); }
}