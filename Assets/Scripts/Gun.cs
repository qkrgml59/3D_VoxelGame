using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [Header("�� ����")]
    public float fireRate = 0.2f;     // ���� �ӵ�
    public float baseDamage = 10f;    // �⺻ ������

    [Header("�ѱ�")]
    public Transform firePoint;       // �Ѿ� �߻� ��ġ

    [Header("������")]
    public GameObject bulletPrefab;   // �Ѿ� ������

    [Header("ī�޶�")]
    public Camera playerCamera;       // FPS ���� ī�޶�

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
        // ī�޶� ���� Ray ��� (��� ���� ������ Ȯ��)
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Vector3 direction;

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            // ���� ���� ���
            direction = (hitInfo.point - firePoint.position).normalized;
        }
        else
        {
            // ���� �� ������ �ָ� ���
            direction = ray.direction;
        }



        //�Ѿ� ����


        //�ѿ��� ������ ������ ��ġ�� �߻�� �Ѿ˿� ���� / ���� �ڵ� -> ī�޶� �������� ���� �ʰ� �� �������� ����
        // Bullet b = bullet.GetComponent<Bullet>(); 
        //  if (b != null)
        //      b.baseDamage = (int)baseDamage;                 //Gun ���� �⺻ ������ ���� �Ѿ��� ������ �ִ� ������ ������ �ѱ�

        // ī�޶� �������� �߻� ���� ���� 
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
