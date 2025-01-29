using UnityEngine;

namespace SimpleGame.GameObjects.Enemies
{
    [RequireComponent(typeof(Rigidbody))]
    public class Hunter : MonoBehaviour
    {
        [SerializeField][Min(0)] private float speed = 3;
        [SerializeField][Min(0)] private int damage = 10;
        [SerializeField][Min(0)] private float detectionRadius = 10;
        [SerializeField] private LayerMask playerMask;

        private Collider[] hits = new Collider[1];
        private Rigidbody rigidbody;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            bool isTargetFound = Physics.OverlapSphereNonAlloc(transform.position, detectionRadius, hits, playerMask.value) > 0;
            if (isTargetFound)
            {
                Vector3 direction = (hits[0].gameObject.transform.position - transform.position).normalized;
                rigidbody.velocity = speed * direction;
            }
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
