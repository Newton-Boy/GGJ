using UnityEngine;

[CreateAssetMenu(fileName = "AnimationData", menuName = "Scriptable Objects/AnimationData")]
public class AnimationData : ScriptableObject
{
    public AnimationClipData[] animations;

    public AnimationClipData GetAnimation(AnimationAction action) {

        foreach (var anim in animations) {
            if (anim.action == action) return anim;
        }

        return null;
    }
}
    