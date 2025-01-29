using UnityEngine;

namespace SimpleGame.GameObjects
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField][Min(0)] private float lifetime;
        [SerializeField][Min(0)] private float speed;

        private Vector3 direction;
        private float damage;

        public void SetDirection(Vector3 dir)
        {
            direction = dir.normalized;
        }

        public void SetDamage(float damage) 
        {
            this.damage = damage;
        }

        private void Start()
        {
            Destroy(gameObject, lifetime);
        }

        private void Update()
        {
            transform.position += speed * Time.deltaTime * direction;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Player player))
            {
                player.Health.ApplyDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
