using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum HitType
{
    Head,
    Body,
    Leg      
}
public class EnemyHitPart : MonoBehaviour
{
    [Header("부위 설정")]
    public HitType hitType;           //부위 선택

    [Header("적 참조")]
    public Enemy enemy;


    void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }
}
