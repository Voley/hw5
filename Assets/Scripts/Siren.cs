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
    
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    public void PlayAlarm()
    {
        _audioSource.Play();
        StartCoroutine(IncreaseVolume());
    }

    public void StopAlarm()
    {
        StartCoroutine(DecreaseVolume());
    }

    private IEnumerator IncreaseVolume()
    {
        float startVolume = _audioSource.volume;
        float rate = 1.0f / _fadeDuration;
 
        for (float progress = 0.0f; progress <= 1.0f; progress += Time.deltaTime * rate) {
            _audioSource.volume = Mathf.Lerp(startVolume, _maxVolume, progress);
            yield return null;
        }
    }

    private IEnumerator DecreaseVolume()
    {
        float startVolume = _audioSource.volume;
        float rate = 1.0f / _fadeDuration;
 
        for (float progress = 0.0f; progress <= 1.0f; progress += Time.deltaTime * rate) {
            _audioSource.volume = Mathf.Lerp(startVolume, _minVolume, progress);
            yield return null;
        }
    }
}
