using UnityEngine;

namespace Assets.Scripts
{
    public class KillZone : MonoBehaviour
    {
        public Director Director;

        void OnTriggerEnter2D(Collider2D col)
        {
            Destroy(col.gameObject);
            Director.KillBall();
        }
    }
}