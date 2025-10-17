using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("�� �ɷ�ġ")]
    public int maxHP = 100;      //�ִ� ü��
    public int currentHP;        //���� ü��

    [Header("����")]
    public bool isDead;           //


    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP; //ü�� �ʱ�ȭ
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamage(int damage)
    {
        if (isDead == true)
            return;               //�̹� �׾����� ���� ó��

        currentHP -= damage;

        Debug.Log("���� �������� ���� : " + damage + " / ���� HP" + currentHP);

        
        if(currentHP <= 0)         //ü���� 0 �����϶�
        {
            Die();              //��� ȣ��
        }

    }

    void Die()
    {
        isDead = true;
        Debug.Log("���");
        Destroy(gameObject); 
    }
}
