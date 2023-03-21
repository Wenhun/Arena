using System;
using System.Collections;
using UnityEngine;

namespace Arena.Spawn
{
    public class WaveGenerator : MonoBehaviour
    {
        [Header("Pools")]
        [SerializeField] private Spawner _redPool;
        [SerializeField] private Spawner _bluePool;
        [Header("Time Preferences")]
        [SerializeField] private float _maxWaveTime = 5f;
        [SerializeField] private float _mimWaveTime = 2f;
        [SerializeField] private float _reductionTime = 0.5f;
        [Header("Increase Parameters")]
        [SerializeField] private int _increaseNumberRed = 4;
        [SerializeField] private int _increaseNumberBlue = 1;
        [SerializeField] private int _numberWaveForReductionTime = 4;

        private int _waveNumber = 0;
        private int _numberRed;
        private int _numberBlue;
        private float _currentWaveTime;

        private bool _waveOn;
        private bool _minTimeReached = false;

        public event Action<float> TimerUpdate;

        private void Start()
        {
            _numberRed = _increaseNumberRed;
            _numberBlue = _increaseNumberBlue;
            _currentWaveTime = _maxWaveTime;
            _waveOn = true;
        }

        private void Update()
        {
            if (_waveOn)
            {
                _waveOn = false;
                IncreaseWave(_redPool, ref _numberRed, _increaseNumberRed);
                IncreaseWave(_bluePool, ref _numberBlue, _increaseNumberBlue);
                _waveNumber++;
                StartCoroutine(WaveLoader());
            }
        }

        private IEnumerator WaveLoader()
        {
            TimerUpdate?.Invoke(_currentWaveTime);
            yield return new WaitForSeconds(_currentWaveTime);

            if (_currentWaveTime > _mimWaveTime)
            {
                if(_waveNumber % _numberWaveForReductionTime == 0)
                    _currentWaveTime -= _reductionTime;
            }     
            else
                _minTimeReached = true;

            _waveOn = true;
        }

        private void IncreaseWave(Spawner pool, ref int number, int increaseNumber)
        {
            if (_minTimeReached) number += increaseNumber;
            pool.Spawn(number);
        }
    }
}
