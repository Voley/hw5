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
        _siren.PlayAlarm();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _siren.StopAlarm();
    }
}
