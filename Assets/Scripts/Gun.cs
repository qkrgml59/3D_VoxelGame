using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [Header("�� ����")]
    public float fireRate = 0.2f;    //���� �ӵ�
    public float baseDamage = 10f;          //�⺻ ������

    [Header("�ѱ�")]
    public Transform firePoint;             //�Ѿ� ��ġ

    [Header("������")]
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
        //�Ѿ� ����
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        //�ѿ��� ������ ������ ��ġ�� �߻�� �Ѿ˿� ����
        Bullet b = bullet.GetComponent<Bullet>(); 
        if (b != null)
            b.baseDamage = (int)baseDamage;                 //Gun ���� �⺻ ������ ���� �Ѿ��� ������ �ִ� ������ ������ �ѱ�
    }


}
