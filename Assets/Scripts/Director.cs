using UnityEngine;

namespace Assets.Scripts
{
    public class Director : MonoBehaviour
    {
        public Gun Gun;
        public UILabel BallsRemainingLabel;

        public int BallsRemaining
        {
            get { return _ballsRemaining; }
            set
            {
                _ballsRemaining = value;
                BallsRemainingLabel.text = "Balls Remaining: " + value;
            }
        }

        private bool _shotfired;
        private int _ballsRemaining;

        void Start()
        {
            BallsRemaining = 5;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0) && !_shotfired && BallsRemaining > 0)
            {
                Gun.Shoot();
                _shotfired = true;
                BallsRemaining--;
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