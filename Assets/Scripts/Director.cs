using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class Director : MonoBehaviour
    {
        #region Properties

        public Gun Gun;
        public UILabel BallsRemainingLabel;
        public UILabel ClearPegsRemainingLabel;
        public Transform PegBoard;
        public GameOverMenu GameOverMenu;

        public List<Transform> LevelList;
        public int CurrentLevel;

        public int BallsRemaining
        {
            get { return _ballsRemaining; }
            set
            {
                _ballsRemaining = value;
                BallsRemainingLabel.text = "Balls Remaining: " + value;
            }
        }

        public int ClearPegsRemaining
        {
            get { return _clearPegsRemaining; }
            set
            {
                _clearPegsRemaining = value;
                ClearPegsRemainingLabel.text = "Orange Pegs Remaining: " + value;
            }
        }

        private bool _shotfired;
        private int _ballsRemaining;
        private int _clearPegsRemaining;

        #endregion

        #region Start/Update

        void Start()
        {
            ReloadLevel();
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0) && !_shotfired && BallsRemaining > 0)
            {
                Gun.Shoot();
                _shotfired = true;
                BallsRemaining--;
            }
        }

        #endregion

        #region Turn Over

        public void KillBall()
        {
            _shotfired = false;
            UpdateClearPegs();

            foreach (var peg in GameObject.FindGameObjectsWithTag("Peg"))
            {
                var p = peg.GetComponent<Peg>();
                if(p != null && p.IsHit)
                    Destroy(peg.gameObject);
            }

            if (BallsRemaining == 0)
            {
                GameOverMenu.gameObject.SetActive(true);
                GameOverMenu.Setup();
            }
        }

        public void UpdateClearPegs()
        {
            ClearPegsRemaining = PegBoard.GetComponentsInChildren<Peg>().Count(x => x.IsClear && !x.IsHit);
        }

        #endregion

        #region Levels

        public void ReloadLevel()
        {
            if(PegBoard != null)
                DestroyImmediate(PegBoard.gameObject);

            PegBoard = ((GameObject)Instantiate(Resources.Load("Prefabs/Levels/" + LevelList[CurrentLevel].name))).transform;
            GameOverMenu.gameObject.SetActive(false);
            BallsRemaining = 5;
            UpdateClearPegs();
        }

        public void LoadNextLevel()
        {
            CurrentLevel++;
            ReloadLevel();
        }

        #endregion
    }
}