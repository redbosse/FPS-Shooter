using UnityEditor;
using UnityEngine;

namespace UI
{
    [CustomEditor(typeof(Stick))]
    public class StickInEditor : Editor
    {
        private void OnSceneGUI()
        {
            var t = target as Stick;

            Handles.color = Color.yellow;

            if (t) Handles.DrawWireDisc(t.Center.position, t.Center.forward, t.Radius);
        }
    }
}