using UnityEngine;

namespace StateMachineExample
{
    // [CreateAssetMenu(fileName = "GameSession", menuName = "BBX/Game Session", order = 0)]
    public class GameSession : ScriptableObject
    {
        public int Health { get; private set; }
        public int Score { get; private set; }

        
        public void Reset()
        {
            Health = 10;
            Score = 0;
        }

        
        public void TakeDamage(int damage)
        {
            Health -= damage;
        }


        public void AddPoints(int points)
        {
            Score += points;
        }
    }
}