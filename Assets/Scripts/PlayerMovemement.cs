using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _playerGraphics;
    
    private Animator _animator;
    
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _animator.SetFloat("Speed", 1.0f);
            _playerGraphics.transform.localScale = new Vector3(1, 1, 1);
            transform.Translate(Vector3.right * (_speed * Time.deltaTime));
        } else if (Input.GetKey(KeyCode.A))
        {
            _animator.SetFloat("Speed", 1.0f);
            _playerGraphics.transform.localScale = new Vector3(-1, 1, 1);
            transform.Translate(Vector3.right * (-_speed * Time.deltaTime));
        }
        else
        {
            _animator.SetFloat("Speed", -1f);
        }
    }
}
