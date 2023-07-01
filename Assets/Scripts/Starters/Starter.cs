using System.Threading.Tasks;
using UnityEngine;

namespace Starters
{
    public abstract class Starter : MonoBehaviour
    {
        protected Transform parent;

        protected abstract Task Initialize();

        protected void DestroyStarter()
        {
            Destroy(gameObject);
        }

        private void Awake()
        {
            parent = transform.parent;
        }
    }
}