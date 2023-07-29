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
        [field: Space] [field: SerializeField] public NpcType NpcType { get; private set; }
    }
}