using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossHittable : Hittable
{
    public UnityEvent OnDeath; // 죽었을 때 호출되는 이벤트

    public int hitPoints = 30; // 보스가 맞아야 하는 총 횟수

    public override void Hit()
    {
        hitPoints--; // 맞을 때마다 hitPoints 감소
        OnHit?.Invoke();

        if (hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        OnDeath?.Invoke(); // 죽을 때 이벤트 호출
        Destroy(gameObject); // 오브젝트 제거
    }
}
