using UnityEngine;

namespace Obstacles
{
    public class SpikeBall : MonoBehaviour
    {
        [SerializeField] float rotationAngle = 90f;

        protected virtual void Update()
        {
            RotateSpikeBall();
        }

        void RotateSpikeBall() => transform.Rotate(Vector3.forward, rotationAngle * Time.deltaTime);
    }
}
