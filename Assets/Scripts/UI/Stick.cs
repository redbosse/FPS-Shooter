using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

[System.Serializable]
[RequireComponent(typeof(StickEventTrigger))]
public class Stick : MonoBehaviour
{
    public enum StickType
    {
        left,
        right
    }

    [SerializeField]
    private StickType type;

    [SerializeField]
    private Knob knob;

    [SerializeField]
    private Transform center;

    [SerializeField]
    private StickEventTrigger stickEventTrigger;

    [SerializeField]
    private float radius = 125f;

    [SerializeField]
    private Vector2 currentValue;

    [SerializeField]
    private UnityEvent<Vector2> onStick;

    public Vector2 CurrentValue { get => currentValue; set => currentValue = value; }
    public float Radius { get => radius; set => radius = value; }
    public Transform Center { get => center; set => center = value; }
    public StickType Type { get => type; set => type = value; }
    public UnityEvent<Vector2> OnStick { get => onStick; set => onStick = value; }

    private void OnEnable()
    {
        InitDependencies();

        stickEventTrigger.OnStickEventHandler += StickEvent;
    }

    private void OnDisable()
    {
        stickEventTrigger.OnStickEventHandler += StickEvent;
    }

    private void InitDependencies()
    {
        if (!knob)
        {
            knob = GetComponentInChildren<Knob>();

            if (!knob)
                throw new System.Exception("Not finding 'Knob' in children");
        }

        if (!stickEventTrigger)
        {
            stickEventTrigger = GetComponent<StickEventTrigger>();

            if (!stickEventTrigger)
                throw new System.Exception("Not finding 'StickEventTrigger' on the GameObject");
        }
    }

    private void StickEvent(Vector2 position, StickEventTrigger.StickEvent stickEvent)
    {
        Vector2 processed = ProcessThePoint(position);

        switch (stickEvent)
        {
            case StickEventTrigger.StickEvent.BeginDrag:

                knob.MoveTo(processed);

                OnStick?.Invoke(processed / radius);

                break;

            case StickEventTrigger.StickEvent.ProcessDrag:

                knob.MoveTo(processed);

                OnStick?.Invoke(processed / radius);

                break;

            case StickEventTrigger.StickEvent.EndDrag:

                processed = Vector2.zero;

                knob.MoveTo(processed);

                OnStick?.Invoke(processed / radius);

                break;
        }
    }

    private Vector2 ProcessThePoint(Vector2 point)
    {
        Vector2 resultPoint = Vector2.zero;

        Vector2 rawPosition = Center.InverseTransformPoint(point);

        float distance = rawPosition.magnitude > Radius ? Radius : rawPosition.magnitude;

        resultPoint = rawPosition.normalized * distance;

        return resultPoint;
    }
}