using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : Entitiy
{
    public override void Interact()
    {
        Debug.Log("Lese Schilder um n�tzliches zu lernen");
    }

    public override void Die()
    {
        Destroy(gameObject);
    }

}
