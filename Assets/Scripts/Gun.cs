using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [Header("총 정보")]
    public float fireRate = 0.2f;     // 연사 속도
    public float baseDamage = 10f;    // 기본 데미지

    [Header("총구")]
    public Transform firePoint;       // 총알 발사 위치

    [Header("프리팹")]
    public GameObject bulletPrefab;   // 총알 프리팹

    [Header("카메라")]
    public Camera playerCamera;       // FPS 시점 카메라

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
        // 카메라 기준 Ray 쏘기 (어디를 조준 중인지 확인)
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Vector3 direction;

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            // 조준 지점 계산
            direction = (hitInfo.point - firePoint.position).normalized;
        }
        else
        {
            // 맞은 게 없으면 멀리 쏘기
            direction = ray.direction;
        }



        //총알 생성


        //총에서 설정한 데미지 수치를 발사된 총알에 전달 / 이전 코드 -> 카메라 기준으로 쏘지 않고 총 기준으로 나감
        // Bullet b = bullet.GetComponent<Bullet>(); 
        //  if (b != null)
        //      b.baseDamage = (int)baseDamage;                 //Gun 안의 기본 데미지 값을 총알이 가지고 있는 데미지 변수로 넘김

        // 카메라 기준으로 발사 방향 설정 
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(direction));

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        Bullet b = bullet.GetComponent<Bullet>();

        if (rb != null && b != null)
        {
            rb.velocity = direction * b.speed;
            b.baseDamage = (int)baseDamage;

        }


    }
}
