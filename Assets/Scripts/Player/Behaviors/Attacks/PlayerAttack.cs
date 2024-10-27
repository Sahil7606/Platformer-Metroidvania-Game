using UnityEngine;
public abstract class PlayerAttack : MonoBehaviour
{
    public abstract Attack attack {get; set;}
    public abstract void Attack();
}
