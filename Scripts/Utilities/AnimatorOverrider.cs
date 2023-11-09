using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorOverrider : MonoBehaviour
{
    public Animator animator;
    public string parameterName = "isGrabbing";
    public bool parameterValue = true;

    public void OverrideAnimator()
    {
        animator.SetBool(parameterName, parameterValue);
    }
    
}
