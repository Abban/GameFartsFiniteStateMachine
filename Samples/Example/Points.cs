using UnityEngine;
using UnityEngine.UI;

namespace StateMachineExample
{
    public class Points : MonoBehaviour
    {
        [SerializeField] private GameSession session = null;
        [SerializeField] private Text pointsText = null;

        private void LateUpdate()
        {
            pointsText.text = $"You scored {session.Score} points";
        }
    }
}