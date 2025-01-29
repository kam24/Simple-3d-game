using SimpleGame.Common;

using UnityEngine;

namespace SimpleGame.GameObjects
{
    [RequireComponent(typeof(Rigidbody))]
    public class Player : MonoBehaviour
    {
        [SerializeField][Min(0)] private float speed = 5;
        [SerializeField][Min(0)] private int health = 50;

        private Rigidbody rigidbody;

        public Health Health { get; private set; }

        public Health GetHealth() => Health ??= new Health(health);

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
            Health ??= new Health(health);
        }

        private void OnEnable()
        {
            Health.Dying += OnDying;
        }

        private void OnDisable()
        {
            Health.Dying -= OnDying;
        }

        private void OnDying()
        {
            Destroy(gameObject);
        }

        private void Update()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            var direction = new Vector3(moveHorizontal, 0, moveVertical);
            rigidbody.velocity = direction * speed;
        }
    }
}
