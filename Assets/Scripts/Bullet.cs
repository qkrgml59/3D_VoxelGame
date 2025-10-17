using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("�Ѿ� ����")]
    public float speed = 50f;
    public float lifeTime = 3f;     //�����ð�
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
        //EnemyHitPart ã��
        EnemyHitPart part = other.GetComponent<EnemyHitPart>();

        if (part != null && part.enemy != null)
        {
            int damage = 0;

            //������ ������
            switch (part.hitType)
            {
                case HitType.Head:
                    damage = (int)(baseDamage * 4f);          //�Ӹ� ���� �� ������ x4
                    break;
                case HitType.Body:
                    damage = (int)(baseDamage * 1f);             //�� ���� �� ������ x1
                    break;
                case HitType.Leg:
                    damage = (int)(baseDamage * 0.5f);        //�ٸ� ���� �� ������ x0.5
                    break;

            }

            //Enemy�� ����
            part.enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
