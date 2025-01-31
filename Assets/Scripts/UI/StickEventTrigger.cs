using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace UI
{
    public class StickEventTrigger : EventTrigger
    {
        public enum StickEvent
        {
            BeginDrag,
            ProcessDrag,
            EndDrag
        }

        public event UnityAction<Vector2, StickEvent> OnStickEventHandler;

        private void CallTheEvent(Vector2 position, StickEvent stickEvent) => OnStickEventHandler?.Invoke(position, stickEvent);

        public override void OnBeginDrag(PointerEventData eventData)
        {
            CallTheEvent(eventData.position, StickEvent.BeginDrag);
        }

        public override void OnDrag(PointerEventData eventData)
        {
            CallTheEvent(eventData.position, StickEvent.ProcessDrag);
        }

        public override void OnEndDrag(PointerEventData eventData)
        {
            CallTheEvent(eventData.position, StickEvent.EndDrag);
        }
    }
}