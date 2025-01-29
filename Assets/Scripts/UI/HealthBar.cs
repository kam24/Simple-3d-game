using SimpleGame.Common;
using SimpleGame.GameObjects;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof(Slider))]
    public class HealthBar : MonoBehaviour
    {
        private Slider slider;
        private Health health;

        [Inject]
        public void Init(Player player)
        {
            health = player.GetHealth();
        }

        private void Awake()
        {
            slider = GetComponent<Slider>();
        }

        private void OnEnable()
        {
            health.Changed += OnHealthChanged;
            OnHealthChanged();
        }

        private void OnDisable()
        {
            health.Changed -= OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            slider.value = health.Value / health.MaxValue;
        }
    }
}
