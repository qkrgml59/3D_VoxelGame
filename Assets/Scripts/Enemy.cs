using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("적 능력치")]
    public int maxHP = 100;      //최대 체력
    public int currentHP;        //현재 체력

    [Header("상태")]
    public bool isDead;           //


    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP; //체력 초기화
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamage(int damage)
    {
        if (isDead == true)
            return;               //이미 죽었으면 무시 처리

        currentHP -= damage;

        Debug.Log("적이 데미지를 받음 : " + damage + " / 남은 HP" + currentHP);

        
        if(currentHP <= 0)         //체력이 0 이하일때
        {
            Die();              //사망 호출
        }

    }

    void Die()
    {
        isDead = true;
        Debug.Log("사망");
        Destroy(gameObject); 
    }
}
