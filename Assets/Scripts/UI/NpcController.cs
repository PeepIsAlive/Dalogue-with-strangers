using Inworld.Sample;
using UnityEngine;
using Inworld;
using Core;

namespace UI.Controllers
{
    public sealed class NpcController : MonoBehaviour
    {
        [field: Header("Inworld data")]
        [field: SerializeField] public InworldCharacter InworldCharacter { get; private set; }
        [field: SerializeField] public InworldPlayer2D InworldPlayer { get; private set; }

        [field:Header("Npc data")]
        [field: SerializeField] public NpcType NpcType { get; private set; }
        
        [SerializeField] private BubbleController _bubbleController;
        private Transform _bubbleParent;
        
        private void EnableBubble()
        {
            if (_bubbleParent.gameObject.activeInHierarchy)
                return;

            _bubbleParent.gameObject.SetActive(true);
        }

        private void Awake()
        {
            if (_bubbleController != null)
                _bubbleParent = _bubbleController.transform.parent;
        }

        private void Start()
        {
            InworldCharacter.OnCharacterSpeaks.AddListener((_, _) => EnableBubble());
            InworldCharacter.OnCharacterSpeaks.AddListener((_, text) => _bubbleController.AddText(text));
        }

        private void OnDestroy()
        {
            InworldCharacter.OnCharacterSpeaks.RemoveAllListeners();
        }
    }
}