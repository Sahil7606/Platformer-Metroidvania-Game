using System.Collections;
using UnityEngine;

public enum AttackPhase
{
    StartUp,
    Active,
    Recovery,
    Complete
}

public class AttackFrameData
{
    public AttackPhase attackPhase;

    public IEnumerator AttackFrameCoroutine(Attack attack)
    {
        attackPhase = AttackPhase.StartUp;
        yield return new WaitForSeconds(attack.startupFrames / attack.animationClip.frameRate);

        attackPhase = AttackPhase.Active;
        yield return new WaitForSeconds(attack.activeFrames / attack.animationClip.frameRate);

        attackPhase = AttackPhase.Recovery;
        yield return new WaitForSeconds(attack.recoveryFrames / attack.animationClip.frameRate);

        attackPhase = AttackPhase.Complete;
    }
}