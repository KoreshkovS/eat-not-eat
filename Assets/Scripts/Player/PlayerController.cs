using System.Collections;
using System.Collections.Generic;
using Game.Base;
using UnityEngine;

namespace Game.PlayerScripts
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidBody;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private GameObject _gameOverScreen;

        private bool IsOver = false;

        void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }

       
        void Update()
        {
            if (IsOver)
            {
                return;
            }
            PlayerMovement();

        }

        private void PlayerMovement()
        {
            float moveDirection = Input.GetAxisRaw("Horizontal");
            _rigidBody.velocity = new Vector2(moveDirection * _moveSpeed, 0);
        }
        public void StopMove()
        {
            IsOver = true;
            _rigidBody.velocity = Vector2.zero;
        }
    }
}