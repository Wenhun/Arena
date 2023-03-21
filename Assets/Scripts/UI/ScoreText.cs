using UnityEngine;
using Arena.Core;
using TMPro;

namespace Arena.UI
{
    public class ScoreText : MonoBehaviour
    {
        [SerializeField] private Scorer _scorer;
        [SerializeField] TMP_Text _text; 

        private void Update()
        {
            _text.text = _scorer.GetScore.ToString();
        }
    }
}
