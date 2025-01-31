using UnityEditor;
using UnityEngine;

namespace UI
{
    internal class InputSystemWindow : EditorWindow
    {
        private Stick[] sticks;

        [MenuItem("RED/Manage Input System")]
        private static void ManageInputSystem()
        {
            EditorWindow.GetWindow(typeof(InputSystemWindow));
        }

        private void OnGUI()
        {
            GUILayout.Label("Stick on the Scene", EditorStyles.boldLabel);

            if (GUILayout.Button($"Add the StickCommutator"))
            {
                Stick[] sticks = GameObject.FindObjectsByType<Stick>(UnityEngine.FindObjectsSortMode.None);

                foreach (Stick stick in sticks)
                {
                    StickPool.Init(stick);
                }

                StickCommutator commutator;

                var obj = Selection.activeObject as GameObject ?? throw new System.Exception("Selected is null");

                if (!obj.GetComponent<StickCommutator>())
                {
                    commutator = obj.AddComponent<StickCommutator>();

                    commutator.LeftStick = StickPool.Left;
                    commutator.RigthStick = StickPool.Rigth;
                }
            }

            if (GUILayout.Button("Clear Input from Selected"))
            {
                var obj = Selection.activeObject as GameObject ?? throw new System.Exception("Selected is null");

                var commutator = obj.GetComponent<StickCommutator>();

                if (commutator)
                {
                    commutator.Clear();
                }
            }
        }

        private void OnFocus()
        {
            sticks = GameObject.FindObjectsByType<Stick>(UnityEngine.FindObjectsSortMode.None);
        }
    }
}