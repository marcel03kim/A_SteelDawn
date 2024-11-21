using UnityEngine;

public class Drone : MonsterVehicle
{
    private float attackTimer; // 공격 타이머 변수

    protected override void Start()
    {
        base.Start(); // 부모 클래스의 Start 메서드를 호출
        attackTimer = 0f; // 타이머 초기화
    }

    protected override void Move()
    {
        base.Move(); // 부모 클래스의 Move 메서드 호출
    }

    protected override void Die()
    {
        base.Die(); // 부모 클래스의 Die 메서드 호출
    }
    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();  // Player 컴포넌트 가져오기
            if (player != null)
            {
                attackTimer += Time.deltaTime; // 타이머 업데이트
                // attackInterval마다 플레이어에게 피해를 입힘
                if (attackTimer >= monsterData.attackInterval)
                {
                    player.currentHp -= power; // 플레이어의 체력을 power만큼 감소
                    attackTimer = 0f; // 타이머 초기화
                }
            }
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            attackTimer = 0f; // 플레이어와의 충돌이 끝나면 타이머 초기화
        }
    }
}
