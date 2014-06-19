using UnityEngine;

namespace Assets.Scripts
{
    public class Spinner : MonoBehaviour
    {
        public float SpinSpeed = 50;

        void FixedUpdate()
        {
            transform.Rotate(0, 0, SpinSpeed * Time.deltaTime);
        }
    }
}