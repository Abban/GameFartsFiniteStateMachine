using System;
using UnityEngine;
using GF.Library.FSM;

namespace StateMachineExample
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameSession session = null;
        
        public static Action LoadingFinishedEvent = () => { };
        public static Action GameOverEvent = () => { };
        public static Action GameRestartEvent = () => { };

        private IStateMachine _stateMachine;


        private void Awake()
        {
            _stateMachine = new GameStateMachine(
                new GameStateFactory(session, this)
            );
            
            _stateMachine.ChangeState(typeof(GameStateLoading));
        }


        private void OnEnable()
        {
            LoadingFinishedEvent += OnLoadingFinished;
            GameOverEvent += OnGameOver;
            GameRestartEvent += OnRestart;
        }


        private void OnDisable()
        {
            LoadingFinishedEvent -= OnLoadingFinished;
            GameOverEvent -= OnGameOver;
            GameRestartEvent -= OnRestart;
        }

        
        /// <summary>
        /// Manually update your states, this allows you to choose
        /// between Update, FixedUpdate, and LateUpdate
        /// </summary>
        private void Update()
        {
            _stateMachine.CurrentState?.Update();
        }


        private void OnLoadingFinished()
        {
            _stateMachine.ChangeState(typeof(GameStatePlaying));
        }


        private void OnGameOver()
        {
            _stateMachine.ChangeState(typeof(GameStateGameOver));
        }
        
        
        private void OnRestart()
        {
            _stateMachine.ChangeState(typeof(GameStateLoading));
        }
    }
}