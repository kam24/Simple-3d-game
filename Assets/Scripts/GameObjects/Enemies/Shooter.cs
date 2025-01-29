using SimpleGame.Infrastracture.Factories;
using System.Collections;
using UnityEngine;
using Zenject;

namespace SimpleGame.GameObjects.Enemies
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private LayerMask playerMask;
        [SerializeField][Min(0)] private float cooldown = 2f;
        [SerializeField][Min(0)] private float detectionRadius = 15f;
        [SerializeField][Min(0)] private float projectileDamage = 15f;

        private Collider[] hits = new Collider[1];
        private bool isTargetFound = false;
        private GameObjectFactory factory;
        private Transform target;

        [Inject]
        public void Init(GameObjectFactory factory)
        {
            this.factory = factory;
        }

        private void Update()
        {
            isTargetFound = Physics.OverlapSphereNonAlloc(transform.position, detectionRadius, hits, playerMask.value) > 0;
            if (target == null && isTargetFound)
            {
                target = hits[0].transform;
                StartCoroutine(ShootingCoroutine());
            }
        }

        private IEnumerator ShootingCoroutine()
        {
            while (true)
            {
                yield return new WaitUntil(() => isTargetFound);

                var direction = target.position - transform.position;
                factory.CreateProjectile(transform.position, direction, projectileDamage);

                yield return new WaitForSeconds(cooldown);
            }
        }
    }
}
