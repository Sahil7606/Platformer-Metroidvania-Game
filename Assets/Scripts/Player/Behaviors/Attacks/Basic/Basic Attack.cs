using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : PlayerAttack
{
    public override Attack attack {get; set;}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }
}
