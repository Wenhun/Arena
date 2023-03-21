using UnityEngine;
using TMPro;
using Arena.PlayerHealth;

namespace Arena.UI
{
    public class StatsText : MonoBehaviour
    {
        [SerializeField] private PlayerStats _player;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private bool _showHealth;

        void Update()
        {
            if(_showHealth) _text.text = _player.GetHealth.ToString();
            else _text.text = _player.Strength.ToString();
        }
    }
}
