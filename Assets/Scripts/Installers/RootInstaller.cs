using SimpleGame.GameObjects;
using SimpleGame.Infrastracture.Factories;
using SimpleGame.Infrastracture.Services;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Installers
{
    public class RootInstaller : MonoInstaller
    {
        [SerializeField] private GameObjectFactory factory;
        [SerializeField] private Player player;
        [SerializeField] private WaypointsService waypointsService;

        public override void InstallBindings()
        {
            BindPlayer();
            BindGameObjectFactory();
            BindServices();
        }

        private void BindPlayer()
        {
            Container.Bind<Player>().FromInstance(player).AsSingle();
        }

        private void BindGameObjectFactory()
        {
            Container.Bind<GameObjectFactory>().FromInstance(factory).AsSingle();
        }

        private void BindServices()
        {
            Container.Bind<WaypointsService>().FromInstance(waypointsService).AsSingle();
        }
    }
}
