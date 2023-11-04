using Application = Live_2D.Application;
using UI.Controllers;
using UnityEngine;
using Settings;
using Modules;
using Events;
using Scenes;
using Core;

namespace Controllers
{
    public sealed class TriggerController : MonoBehaviour
    {
        private void HandleTrigger(OnTriggerEvent data)
        {
            switch (data.TriggerType)
            {
                case TriggerType.ShowCat:
                {
                    var settings = SettingsProvider.Get<NpcCommonSettings>();
                    var preset = settings.GetCatPresetByOwnerType(Application.CurrentNpcType);

                    FadeController.Instance.FadeOnWithDelay(3f, () =>
                    {
                        CatsScene.LoadScene(preset.Id);
                    });

                    break;
                }
            }
        }

        private void Start()
        {
            EventSystem.Subscribe<OnTriggerEvent>(HandleTrigger);
        }

        private void OnDestroy()
        {
            EventSystem.Unsubscribe<OnTriggerEvent>(HandleTrigger);
        }
    }
}