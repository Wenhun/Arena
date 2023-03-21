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
            _waveGenerator.TimerUpdate += SetTimer;
        }

        void Update()
        {
            _timer -= Time.deltaTime;
            _text.text = _timer.ToString("0.0");
        }

        void SetTimer(float time)
        {
            _timer = time;
        }

        private void OnDestroy()
        {
            _waveGenerator.TimerUpdate -= SetTimer;
        }
    }
}
