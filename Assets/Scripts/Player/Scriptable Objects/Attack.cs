using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Attack", menuName = "Attack")]
public class Attack : ScriptableObject
{
    public int startupFrames;
    public int activeFrames;
    public int recoveryFrames;

    public AnimationClip animationClip;
}
