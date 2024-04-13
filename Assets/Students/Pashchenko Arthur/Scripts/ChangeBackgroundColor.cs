using Artur.Pashchenko.Player;
using System.Net.Http.Headers;
using UnityEngine;
namespace Artur.Pashchenko.Background
{
    public class ChangeBackgroundColor : MonoBehaviour
    {
        public Color[] availableColors;
        private int randomColor;

        private void Update()
        {

            if (InputController.IsJumped && PlayerMovement.IsGrounded)
            {
                randomColor = Random.Range(0, availableColors.Length);
                Camera.main.backgroundColor = availableColors[randomColor];

            }

        }
    }
}