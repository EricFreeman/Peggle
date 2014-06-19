using UnityEngine;

namespace Assets.Scripts
{
    public class GameOverMenu : MonoBehaviour
    {
        public UILabel MainLabel;
        public UILabel SecondaryLabel;
        public Director Director;

        public bool IsWin;

        public void Setup()
        {
            IsWin = Director.ClearPegsRemaining == 0; 

            if (IsWin)
            {
                MainLabel.text = "You Win!";
                SecondaryLabel.text = "Click to continue...";
            }
            else
            {
                MainLabel.text = "You Lose!";
                SecondaryLabel.text = "Click to restart...";
            }
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(!IsWin) 
                    Application.LoadLevel(Application.loadedLevelName);
                else
                {
                    //load the next level here
                }
            }
        }
    }
}