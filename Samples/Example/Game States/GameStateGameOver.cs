using System;
using System.Collections;
using GF.Library.FSM;
using UnityEngine;

namespace StateMachineExample
{
    public class GameStateGameOver : State
    {
        private MonoBehaviour _coroutineRunner;
        
        public GameStateGameOver(
            MonoBehaviour coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
            CanMoveToStates.Add(typeof(GameStateLoading));
        }


        public override void Start(Type lastState)
        {
            base.Start(lastState);
            Debug.Log("Enter Game Over State");
            _coroutineRunner.StartCoroutine(Run());
        }
        
        
        private static IEnumerator Run()
        {
            yield return new WaitForSeconds(5);
            GameManager.GameRestartEvent.Invoke();
        }

        
        public override void Exit()
        {
            Debug.Log("Exit Game Over State");
        }
    }
}