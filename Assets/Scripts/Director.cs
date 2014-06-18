using UnityEngine;

namespace Assets.Scripts
{
    public class Director : MonoBehaviour
    {
        public Gun Gun;

        private bool _shotfired;

        void Update()
        {
            if (Input.GetMouseButtonDown(0) && !_shotfired)
            {
                Gun.Shoot();
                _shotfired = true;
            }
        }

        public void KillBall()
        {
            _shotfired = false;

            foreach (var peg in GameObject.FindGameObjectsWithTag("Peg"))
            {
                var p = peg.GetComponent<Peg>();
                if(p != null && p.IsHit)
                    Destroy(peg.gameObject);
            }
        }
    }
}