using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class MainButtonAnimator : MonoBehaviour
{
    private Animator animator;
    private AnimatorControllerParameter AnimationSpeed;
    [SerializeField]
    MainGamePlay mainGamePlay;
    [SerializeField]
    private float MaxAnimationSpeed;
    private AngryLevelController AngryLevelController;
    private void Start()
    {
        animator = GetComponent<Animator>();
        AngryLevelController = mainGamePlay.AngryLevelController;
        AngryLevelController.ReactiveAngryLevel.Subscribe(level => { SetAnimationSpeed(level); });
    }
    private void SetAnimationSpeed(AngryLevel angryLevel)
    {
        int max =(int) Enum.GetValues(typeof(AngryLevel)).Cast<AngryLevel>().Max();
        float animationSpeed =   (float)((float)angryLevel / (float)max) * MaxAnimationSpeed + 1f;
        animator.SetFloat("AnimationSpeed", animationSpeed);
        Debug.Log(animator.parameters[1]+ animator.parameters[1].defaultFloat.ToString() + "new value has to be " + animationSpeed);
        Debug.Log("but value is " + animator.GetFloat("AnimationSpeed"));
        animator.SetFloat(1, animationSpeed);

    }
}