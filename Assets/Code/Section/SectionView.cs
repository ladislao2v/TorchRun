using DG.Tweening;
using UnityEngine;

namespace Code.Section
{
    public class SectionView : MonoBehaviour
    {
        [SerializeField] private GameObject[] _variants;
        [SerializeField] private float _duration = 2f;

        private Transform _transform;
        private int _sectionLenght = 25;

        public Vector3 Position => _transform.position;

        private void Awake()
        {
            _transform = transform;
        }

        public void Move(int currentNumber, Vector3 newPosition)
        {
            Sequence sequence = DOTween.Sequence();

            Vector3 endPosition = _transform.position - Vector3.forward * _sectionLenght * currentNumber;

            sequence
                .Append(transform.DOMove(endPosition, _duration * currentNumber).SetEase(Ease.Linear))
                .AppendCallback(() => Reset(newPosition));
        }

        public void Reset(Vector3 newPosition)
        {
            foreach (var variant in _variants)
                variant.SetActive(false);
            
            _variants[Random.Range(0, _variants.Length)].SetActive(true);
            
            _transform.position = newPosition;
        }
    }
}
