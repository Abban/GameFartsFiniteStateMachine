using UnityEngine;
using UnityEngine.UI;

namespace StateMachineExample
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private GameSession session = null;
        [SerializeField] private Text healthText = null;


        private void Update()
        {
            healthText.text = $"Health: {session.Health}";
        }
    }
}