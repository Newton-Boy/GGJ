using System;
using UnityEngine;

public static class AnimationEvents
{
    public static Action<AnimationEventArgs> onExecuteAnimation;

    public class AnimationEventArgs {

        public AnimationData animation;

        public AnimationAction action;

        public AnimationEventArgs(AnimationData animation, AnimationAction action) {
            this.animation = animation;
            this.action = action;
        }
    }

    public static void Execute(AnimationData animation, AnimationAction action) {

        onExecuteAnimation?.Invoke(new AnimationEventArgs(animation, action));
    }
}
