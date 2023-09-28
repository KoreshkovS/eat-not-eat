using System;
using System.Collections;
using System.Collections.Generic;
using Game.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Game.NonEatables
{
    

    public class NonEatable : MonoBehaviour
    {
 

        private LogicScript logic;

        public static event Action OnDeath;

        void Start()
        {
            logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == 3)
            {
                
                OnDeath?.Invoke();
                Destroy(gameObject);
            }


        }
    }
}