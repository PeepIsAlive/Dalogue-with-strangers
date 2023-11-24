using UnityEngine;

namespace Live2D
{
    public sealed class CameraFollow : MonoBehaviour
    {
        private const float END_POSITION_X = 6.50f;

        private void FixedUpdate()
        {
            if (transform.position.x < END_POSITION_X)
                transform.Translate(Vector2.right * Time.fixedDeltaTime);
        }
    }
}