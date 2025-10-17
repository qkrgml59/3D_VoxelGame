using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("총알 정보")]
    public float speed = 50f;
    public float lifeTime = 3f;     //생존시간
    public int baseDamage = 10;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        rb.isKinematic = false;
       

        Collider col = GetComponent<Collider>();
        if (col != null)
            col.isTrigger = true;

        rb.velocity = transform.forward * speed;
        Destroy(gameObject, lifeTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        //EnemyHitPart 찾기
        EnemyHitPart part = other.GetComponent<EnemyHitPart>();

        if (part != null && part.enemy != null)
        {
            int damage = 0;

            //부위별 데미지
            switch (part.hitType)
            {
                case HitType.Head:
                    damage = (int)(baseDamage * 4f);          //머리 맞출 시 데미지 x4
                    break;
                case HitType.Body:
                    damage = (int)(baseDamage * 1f);             //몸 맟술 시 데미지 x1
                    break;
                case HitType.Leg:
                    damage = (int)(baseDamage * 0.5f);        //다리 맞출 시 데미지 x0.5
                    break;

            }

            //Enemy에 적용
            part.enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
