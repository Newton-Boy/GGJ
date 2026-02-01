using UnityEngine;

public enum AnimationAction { 
    Idle,
    Walk,
    Run,
    Hit,
    Death
}

[System.Serializable]
public class AnimationClipData
{
    public string name;
    public AnimationAction action;
    public AudioClip audio;
}


