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
    [Header("���� ����")]
    public HitType hitType;           //���� ����

    [Header("�� ����")]
    public Enemy enemy;


    void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }
}
