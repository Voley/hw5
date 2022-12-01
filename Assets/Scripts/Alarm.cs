using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Siren))]

public class Alarm : MonoBehaviour
{
    private Siren _siren;
    
    private void Start()
    {
        _siren = GetComponent<Siren>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        PlayerMovemement player = col.gameObject.GetComponent<PlayerMovemement>();
        
        if (player != null)
        {
            _siren.IncreaseAlarmSoundOverTime();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        PlayerMovemement player = other.gameObject.GetComponent<PlayerMovemement>();
        
        if (player != null)
        {
            _siren.DecreaseAlarmSoundOverTime();
        }
    }
}
