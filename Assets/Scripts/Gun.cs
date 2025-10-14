using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [Header("�� ����")]
    public float range = 50f;        //��Ÿ�
    public float fireRate = 0.2f;    //���� �ӵ�
    public float baseDamage = 10f;          //�⺻ ������

    [Header("�ѱ�")]
    public Transform firePoint;             //�Ѿ� ��ġ

    [Header("ī�޶�")]
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

        // �߻�
        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, range))
        {
            //EnemyHitPart�� �ִ��� Ȯ��
            EnemyHitPart part = hit.collider.GetComponent<EnemyHitPart>();

            if(part != null)
            {
                int damage = 0;

                //������ ������
                switch (part.hitType)
                {
                    case HitType.Head:
                        damage = (int)(baseDamage * 2f);          //�Ӹ� ���� �� ������ x2
                        break;
                    case HitType.Body:
                        damage = (int) (baseDamage * 1f);             //�� ���� �� ������ x1
                        break;
                    case HitType.Leg:
                        damage = (int)(baseDamage * 0.5f);        //�ٸ� ���� �� ������ x0.5
                        break;

                }

                //Enemy�� ����
                part.enemy.TakeDamage(damage);

            }
        }
    }
}
