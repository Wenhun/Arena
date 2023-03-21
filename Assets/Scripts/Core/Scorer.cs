using UnityEngine;

namespace Arena.Core
{
    public class Scorer : MonoBehaviour
    {
        private int _score;
        public int GetScore { get => _score; }

        private void Start()
        {
            _score = 0;
        }

        public void IncreaceScore()
        {
            _score++;
        }
    }
}
