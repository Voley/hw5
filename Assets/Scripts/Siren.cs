using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Siren : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _minVolume;
    [SerializeField] private float _maxVolume;
    [SerializeField] private float _fadeDuration;

    private Coroutine _soundChangeCoroutine;
    
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    public void IncreaseAlarmSoundOverTime()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }

        if (_soundChangeCoroutine != null)
        {
            StopCoroutine(_soundChangeCoroutine);
        }
        
        _soundChangeCoroutine = StartCoroutine(ChangeVolume(_maxVolume));
    }

    public void DecreaseAlarmSoundOverTime()
    {
        if (_soundChangeCoroutine != null)
        {
            StopCoroutine(_soundChangeCoroutine);
        }
        
        _soundChangeCoroutine = StartCoroutine(ChangeVolume(_minVolume));
    }

    private IEnumerator ChangeVolume(float target)
    {
        float rate = 1.0f / _fadeDuration;

        while (_audioSource.volume != target)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, Time.deltaTime * rate);
            yield return null;
        }

        _soundChangeCoroutine = null;
    }
}
