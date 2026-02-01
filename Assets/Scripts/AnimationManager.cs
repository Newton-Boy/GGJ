using UnityEngine;

public class AnimationManager : MonoBehaviour
{

    Animator animator;

    [SerializeField]
    AnimationData animationData;

    AnimationClipData currentAnimation;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    public void Play(AnimationAction action) {
        var animClip = animationData.GetAnimation(action);

        if (animClip == null) return;

        if (currentAnimation == animClip) return;

        currentAnimation = animClip;

        animator.Play(animClip.name);

        AnimationEvents.Execute(animationData, action);


    }
}
