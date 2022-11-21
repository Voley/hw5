using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        _audioSource.Play();
        _audioSource.DOFade(0.4f, 3);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _audioSource.DOFade(0f, 3).OnComplete(() => _audioSource.Stop());
    }
}
