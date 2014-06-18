using UnityEngine;

namespace Assets.Scripts
{
    public class Peg : MonoBehaviour
    {
        public Sprite DefaultImage;
        public Sprite HitImage;

        public bool IsHit;

        private SpriteRenderer _renderer;

        void Start()
        {
            _renderer = transform.GetComponent<SpriteRenderer>();
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            _renderer.sprite = HitImage;
            IsHit = true;
        }
    }
}