using System;
using UnityEngine;

namespace StateMachineExample
{
    public class VisibleInGameState : MonoBehaviour, IDisposable
    {
        [SerializeField] private bool visibleInLoading = false;
        [SerializeField] private bool visibleInPlaying = false;
        [SerializeField] private bool visibleInGameOver = false;


        private void Awake()
        {
            GameStateMachine.StateChangeEvent += OnStateChange;
        }


        public void Dispose()
        {
            GameStateMachine.StateChangeEvent -= OnStateChange;
        }


        private void OnStateChange(Type type)
        {
            if (type == typeof(GameStateLoading))
            {
                gameObject.SetActive(visibleInLoading);
            }
            else if (type == typeof(GameStatePlaying))
            {
                gameObject.SetActive(visibleInPlaying);
            }
            else if (type == typeof(GameStateGameOver))
            {
                gameObject.SetActive(visibleInGameOver);
            }
        }
    }
}