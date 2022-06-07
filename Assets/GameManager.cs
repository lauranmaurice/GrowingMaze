using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class GameManager : MonoBehaviour
    {
        private List<GameObject> _pickups;
        public PlayerController Player;
        public Text ScoreText;
        public Text WinText;
        public int MaxScore = 9;
        private int Score;

        private void UpdateScore()
        {
            ScoreText.text = $"Score: {Score} / {MaxScore}";
            if (Score == MaxScore)
            {
                Debug.Log("You won!");
                WinText.gameObject.SetActive(true);
            }
        }

        private void Awake()
        {
            _pickups = new List<GameObject>();
            var grows = GameObject.FindGameObjectsWithTag("PickupGrow");
            var shrinks = GameObject.FindGameObjectsWithTag("PickupShrink");
            _pickups.AddRange(grows);
            _pickups.AddRange(shrinks);
        }
        
        public void PickupFound(bool grow)
        {
            Debug.Log($"{(grow ? "Grow" : "Shrink")} Pickup found!");
            Player.Grow(grow);
            Score++;
            UpdateScore();
        }

        public void Reset()
        {
            _pickups.ForEach(x => x.SetActive(true));
            WinText.gameObject.SetActive(false);
            Score = 0;
            UpdateScore();
            Player.transform.position = new Vector3(0.0f, 0.5f, 0.0f);
            Player.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }
}
