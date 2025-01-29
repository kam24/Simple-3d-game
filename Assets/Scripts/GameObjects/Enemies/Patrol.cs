using SimpleGame.Infrastracture.Services;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace SimpleGame.GameObjects.Enemies
{
    public class Patrol : MonoBehaviour
    {
        [SerializeField][Min(0)] private float speed = 2f;
        [SerializeField][Min(0)] private int damage = 10;

        private int currentWaypointIndex = 0;
        private List<Transform> wayPoints = new();

        [Inject]
        public void Init(WaypointsService service)
        {
            wayPoints = service.GetWaypoints().ToList();
        }

        private void Update()
        {
            if (wayPoints.Count == 0)
            {
                return;
            }

            Transform targetWaypoint = wayPoints[currentWaypointIndex];
            Vector3 direction = (targetWaypoint.position - transform.position).normalized;
            transform.position += speed * Time.deltaTime * direction;

            if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1)
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % wayPoints.Count;
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
