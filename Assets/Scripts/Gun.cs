using UnityEngine;

namespace Assets.Scripts
{
    public class Gun : MonoBehaviour
    {
        public Transform Barrel;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ball = (GameObject)Instantiate(Resources.Load("prefabs/ball"));
                ball.transform.position = Barrel.position;
            }
        }
    }
}