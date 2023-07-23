using UnityEngine;
using Core;

namespace UI.Controllers
{
    public sealed class NpcController : MonoBehaviour
    {
        [field: SerializeField] public NpcType NpcType { get; private set; }
    }
}