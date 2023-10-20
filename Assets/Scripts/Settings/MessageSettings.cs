using System.Collections.Generic;
using UnityEngine;
using Extensions;
using System;
using Core;

namespace Settings
{
    [CreateAssetMenu(fileName = "MessageSettings", menuName = "Settings/MessageSettings", order = 0)]
    public sealed class MessageSettings : ScriptableObject
    {
#if UNITY_EDITOR
        [ReadOnly]
#endif
        [SerializeField] private List<Trigger> _triggers;

        public TriggerType GetTrigger(List<string> keyWords)
        {
            var triggerType = TriggerType.None;

            if (keyWords == null)
                return triggerType;

            var IsExists = true;

            _triggers.ForEach(trigger =>
            {
                keyWords.ForEach(word =>
                {
                    if (!trigger.Words.Contains(word))
                        IsExists = false;
                });

                if (IsExists)
                {
                    triggerType = trigger.TriggerType;
                    return;
                }
            });

            return triggerType;
        }
    }


    [Serializable]
    public sealed class Trigger
    {
        [field: SerializeField] public TriggerType TriggerType { get; private set; }
        [field: SerializeField] public List<string> Words { get; private set; }

    }
}