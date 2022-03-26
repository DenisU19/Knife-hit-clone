using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogHitAnimator : MonoBehaviour
{
    private Animator _logAnimator;

    private void Start()
    {
        _logAnimator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _logAnimator.SetTrigger("LogHit");
    }
}
