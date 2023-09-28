using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Base
{
    public class Move : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _deadZone;


        void Update()
        {
            transform.position = transform.position + (Vector3.down * _moveSpeed * Time.deltaTime);

            if (transform.position.y < _deadZone)
            {
                Destroy(gameObject);

            }
        }
    }
}