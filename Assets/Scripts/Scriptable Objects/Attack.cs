using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

[CreateAssetMenu(fileName = "New Attack")]
public class Attack : ScriptableObject 
{
    // Number of windup/attack/recovery frames that are in the attack animation
    [Header ("Animation Data")]
    public AnimationClip animation;
    
    [Tooltip ("Frames before weapon is swung")]
    public int startupFrames;

    [Tooltip ("Frames that weapon hitbox is active")]
    public int activeFrames;

    [Tooltip ("Any remaining frames")]
    public int recoveryFrames;

    [Header ("Attack Properties")]
    public float damageMultiplier; // Base damage determined by weapon and possibly levels in the future
}
