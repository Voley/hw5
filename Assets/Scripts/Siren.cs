using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Siren : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _minVolume;
    [SerializeField] private float _maxVolume;
    [SerializeField] private float _fadeDuration;
    
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    public void PlayAlarm()
    {
        _audioSource.Play();
        _audioSource.DOFade(_maxVolume, _fadeDuration);
    }

    public void StopAlarm()
    {
        _audioSource.DOFade(_minVolume, _fadeDuration).OnComplete(() => _audioSource.Stop());
    }
}
