using System;
using UnityEngine;
using GF.Library.FSM;

namespace StateMachineExample
{
    public class GameStateFactory : IStateFactory
    {
        private readonly GameSession _session;
        private readonly MonoBehaviour _coroutineRunner;
        
        public GameStateFactory(
            GameSession session,
            MonoBehaviour coroutineRunner)
        {
            _session = session;
            _coroutineRunner = coroutineRunner;
        }
        
        
        public IState Get(Type type)
        {
            if (type == typeof(GameStateLoading))
            {
                return new GameStateLoading(_coroutineRunner);
            }

            if (type == typeof(GameStatePlaying))
            {
                return new GameStatePlaying(_session);;
            }

            if (type == typeof(GameStateGameOver))
            {
                return new GameStateGameOver(_coroutineRunner);
            }

            throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
}