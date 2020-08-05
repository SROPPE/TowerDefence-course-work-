using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [SerializeField] int damage = 0;
    public int GetDamageValue()
    {
        return damage;
    }
}
