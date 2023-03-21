using UnityEngine;
using TMPro;
using Arena.Spawn;

namespace Arena.UI
{
    public class WaveTimer : MonoBehaviour
    {
        [SerializeField] private WaveGenerator _waveGenerator;
        [SerializeField] private TMP_Text _text;

        private float _timer;

        void Start()
        {
            _waveGenerator.TimerUpdate += Timer;
        }

        void Update()
        {
            _timer -= Time.deltaTime;
            _text.text = (Mathf.Round(_timer * 10f) / 10f).ToString();
        }

        void Timer(float time)
        {
            _timer = time;
        }

        private void OnDestroy()
        {
            _waveGenerator.TimerUpdate -= Timer;
        }
    }
}
