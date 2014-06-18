using UnityEngine;

namespace Assets.Scripts
{
    public class Gun : MonoBehaviour
    {
        public Transform Barrel;
        public float BallSpeed = 30;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ball = (GameObject)Instantiate(Resources.Load("Prefabs/Ball"));
                ball.transform.position = Barrel.position;
                var e = transform.rotation.eulerAngles;
                ball.rigidbody2D.AddForce(transform.up * -BallSpeed);
            }
        }
    }
}