using System;
using System.Collections;
using BBX.Library.FSM;
using UnityEngine;

namespace StateMachineExample
{
    public class GameStateLoading : State
    {
        private readonly MonoBehaviour _coroutineRunner;

        private float _futureTime;
        
        public GameStateLoading(MonoBehaviour coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
            CanMoveToStates.Add(typeof(GameStatePlaying));
        }
        
        
        public override void Start(Type lastState)
        {
            base.Start(lastState);
            Debug.Log("Enter Loading State");
            _coroutineRunner.StartCoroutine(Load());
        }


        public override void Update()
        {
            if (_futureTime > Time.time) return;
            
            _futureTime = Time.time + 1f;
            Debug.Log("Loading");
        }


        private static IEnumerator Load()
        {
            yield return new WaitForSeconds(5);
            GameManager.LoadingFinishedEvent.Invoke();
        }


        public override void Exit()
        {
            Debug.Log("Exit Loading State");
        }
    }
}