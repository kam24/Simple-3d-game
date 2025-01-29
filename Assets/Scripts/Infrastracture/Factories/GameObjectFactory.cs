using SimpleGame.GameObjects;

using UnityEngine;

namespace SimpleGame.Infrastracture.Factories
{
    public class GameObjectFactory: MonoBehaviour
    {
        [SerializeField] private GameObject projectile;

        public void CreateProjectile(Vector3 position, Vector3 direction, float damage)
        {
            var prefab = GameObject.Instantiate(projectile, position, Quaternion.identity);
            var projectileGO = prefab.GetComponent<Projectile>();
            projectileGO.SetDirection(direction);
            projectileGO.SetDamage(damage);
        }
    }
}
