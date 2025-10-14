using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [Header("총 정보")]
    public float fireRate = 0.2f;    //연사 속도
    public float baseDamage = 10f;          //기본 데미지

    [Header("총구")]
    public Transform firePoint;             //총알 위치

    [Header("프리팹")]
    public GameObject bulletPrefab;      



    private float nextFireTime;

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
        //총알 생성
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        //총에서 설정한 데미지 수치를 발사된 총알에 전달
        Bullet b = bullet.GetComponent<Bullet>(); 
        if (b != null)
            b.baseDamage = (int)baseDamage;                 //Gun 안의 기본 데미지 값을 총알이 가지고 있는 데미지 변수로 넘김
    }


}
