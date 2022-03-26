using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoAnimator : MonoBehaviour
{
    private Animator _logoAnimator;

    private void Start()
    {
        _logoAnimator = GetComponent<Animator>();
        _logoAnimator.SetTrigger("isLogoAppear");
    }
}
