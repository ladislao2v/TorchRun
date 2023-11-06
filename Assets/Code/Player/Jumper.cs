using System;
using DG.Tweening;
using UnityEngine;

namespace Code.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class Jumper : MonoBehaviour
    {
        [SerializeField] private Vector3 _direction = Vector3.zero;
        [SerializeField] private float _power = 5f;
        [SerializeField] private int _count = 1;
        [SerializeField] private float _duration = 1f;
        
        private Rigidbody _rigidbody;
        private bool _canJump = true;

        private void Update()
        {
            if (_rigidbody.position.y < 0)
                _rigidbody.position = Vector3.zero;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Jump(Action jumped = null)
        {
            if(_canJump == false)
                return;

            _canJump = false;
            
            Sequence sequence = DOTween.Sequence();
            sequence
                .Append(_rigidbody.DOJump(_direction, _power, _count, _duration))
                .AppendCallback(() => _canJump = true)
                .AppendCallback(()=> jumped?.Invoke());
        }
    }
}