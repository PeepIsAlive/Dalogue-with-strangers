using UnityEngine;
using Controllers;
using Core;
using UI;

namespace Live_2D
{
    public static class Application
    {
        public static PopupViewManager PopupViewManager { get; private set; }
        public static RectTransform MainCanvasRect
        {
            get
            {
                return GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<RectTransform>();
            }
        }
        public static NpcType CurrentNpcType
        {
            get
            {
                var npcController = Object.FindObjectOfType<NpcController>();
                return npcController != null ? npcController.NpcType : NpcType.Cat;
            }
        }

        static Application()
        {
            PopupViewManager = new PopupViewManager();
        }
    }
}
