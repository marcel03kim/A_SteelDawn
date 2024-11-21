using UnityEngine;

public class TutorialMonster : MonsterVehicle
{
    protected override void Start()
    {
        base.Start(); // 부모 클래스의 Start 메서드를 호출
    }

    protected override void Move()
    {
        base.Move(); // 부모 클래스의 Move 메서드 호출
    }

    protected override void Die()
    {
        base.Die(); // 부모 클래스의 Die 메서드 호출
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();  // Player 컴포넌트 가져오기
            if (player != null)
            {
                player.currentHp -= power; // 플레이어의 체력을 power만큼 감소
            }
        }
    }

    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();  // Player 컴포넌트 가져오기
            if (player != null)
            {
                player.currentHp -= power; // 플레이어의 체력을 power만큼 감소
            }
        }
    }

}
