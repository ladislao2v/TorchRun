using Code.FireBonus;
using UnityEngine;
using Zenject;

namespace Code.Installers.Local
{
    public class FireBonusPoolInstaller : MonoInstaller
    {
        [SerializeField] private FireBonusView _prefab;
        [SerializeField] private Transform _parent;
        [SerializeField] private int _size = 10;

        public override void InstallBindings() => BindPizzaPool();

        private void BindPizzaPool() =>
            Container.BindMemoryPool<FireBonusView, FireBonusView.Pool>()
                .WithInitialSize(_size)
                .FromComponentInNewPrefab(_prefab)
                .UnderTransform(_parent);
    }
}