using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [Header("총 정보")]
    public float range = 50f;        //사거리
    public float fireRate = 0.2f;    //연사 속도
    public float baseDamage = 10f;          //기본 데미지

    [Header("총구")]
    public Transform firePoint;             //총알 위치

    [Header("카메라")]
    public Camera playerCamera;

    private float nextFireTime;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Shoot();
        }
        
    }

    void Shoot()
    {
        RaycastHit hit;

        // 발사
        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, range))
        {
            //EnemyHitPart가 있는지 확인
            EnemyHitPart part = hit.collider.GetComponent<EnemyHitPart>();

            if(part != null)
            {
                int damage = 0;

                //부위별 데미지
                switch (part.hitType)
                {
                    case HitType.Head:
                        damage = (int)(baseDamage * 2f);          //머리 맞출 시 데미지 x2
                        break;
                    case HitType.Body:
                        damage = (int) (baseDamage * 1f);             //몸 맟술 시 데미지 x1
                        break;
                    case HitType.Leg:
                        damage = (int)(baseDamage * 0.5f);        //다리 맞출 시 데미지 x0.5
                        break;

                }

                //Enemy에 적용
                part.enemy.TakeDamage(damage);

            }
        }
    }
}
