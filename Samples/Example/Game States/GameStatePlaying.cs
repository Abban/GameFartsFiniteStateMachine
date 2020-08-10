using System;
using GF.Library.FSM;
using UnityEngine;
using Random = UnityEngine.Random;

namespace StateMachineExample
{
    public class GameStatePlaying : State
    {
        private readonly GameSession _session;

        private float _futureTime;
        
        public GameStatePlaying(GameSession session)
        {
            _session = session;
            CanMoveToStates.Add(typeof(GameStateGameOver));
        }


        public override void Start(Type lastState)
        {
            base.Start(lastState);
            Debug.Log("Enter Playing State");
            _session.Reset();
        }


        public override void Update()
        {
            if (_futureTime > Time.time) return;
            _futureTime = Time.time + 0.5f;
            
            _session.TakeDamage(1);
            _session.AddPoints(Random.Range(0, 30));

            if (_session.Health <= 0)
            {
                GameManager.GameOverEvent.Invoke();
            }
        }


        public override void Exit()
        {
            Debug.Log("Exit Playing State");
        }
    }
}