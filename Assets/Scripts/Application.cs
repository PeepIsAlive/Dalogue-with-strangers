using UI.Controllers;
using UnityEngine;
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
                return Object.FindObjectOfType<NpcController>().NpcType;
            }
        }

        static Application()
        {
            PopupViewManager = new PopupViewManager();
        }
    }
}
