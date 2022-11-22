using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Siren))]

public class Alarm : MonoBehaviour
{
    private const String PlayerTag = "Player";
    
    private Siren _siren;
    
    private void Start()
    {
        _siren = GetComponent<Siren>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag(PlayerTag))
        {
            _siren.PlayAlarm();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(PlayerTag))
        {
            _siren.StopAlarm();
        }
    }
}
