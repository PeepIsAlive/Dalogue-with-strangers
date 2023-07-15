using UnityEngine;
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

        static Application()
        {
            PopupViewManager = new PopupViewManager();
        }
    }
}
