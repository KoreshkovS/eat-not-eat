using System;
using System.Collections;
using System.Collections.Generic;
using Game.Base;
using UnityEngine;

namespace Game.Fruits
{
    public class Fruit : MonoBehaviour
    {
        [SerializeField] private int _score = 10;
        [SerializeField] private int _minScore = 1;

        private LogicScript logic;
        

        public static event Action<int> OnAddScore;
        
        //void Start()
        //{
        //    logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        //}

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == 3)
            {

                int score = UnityEngine.Random.Range(_minScore, _score);
                //logic.AddScore();
                OnAddScore?.Invoke(score);
                Destroy(gameObject);
            }


        }
    }
}