using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SimpleGame.Infrastracture.Services
{
    public class WaypointsService : MonoBehaviour
    {
        [SerializeField] private GameObject WaypointsHost;

        private List<Transform> Waypoints;

        public IEnumerable<Transform> GetWaypoints()
        {
            Waypoints ??= WaypointsHost.GetComponentsInChildren<Transform>().ToList();
            return Waypoints;
        }
    }
}
