using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _playerGraphics;
    
    private Animator _animator;
    private int _speedAnimationHash;
    
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _speedAnimationHash = Animator.StringToHash("Speed");
    }
    
    void Update()
    {
        float animatorValue = 0f;
        if (Input.GetKey(KeyCode.D))
        {
            animatorValue = 1f;
            _playerGraphics.transform.localScale = new Vector3(1, 1, 1);
            transform.Translate(Vector3.right * (_speed * Time.deltaTime));
        } else if (Input.GetKey(KeyCode.A))
        {
            animatorValue = 1f;
            _playerGraphics.transform.localScale = new Vector3(-1, 1, 1);
            transform.Translate(Vector3.right * (-_speed * Time.deltaTime));
        }
        else
        {
            animatorValue = -1f;
        }
        
        _animator.SetFloat(_speedAnimationHash, animatorValue);
    }
}
