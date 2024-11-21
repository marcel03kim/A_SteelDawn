using System.Collections;
using UnityEngine;

public class AIRobot : MonsterVehicle
{
    private bool canAttack = true; // 공격 가능 여부
    public Transform firePos; // 총알 발사 위치
    public GameObject bulletPrefab; // 발사할 총알 프리팹

    protected override void Move()
    {
        base.Move();

        if (target != null)
        {
            // 공격 범위에 도달 시 상태 변경
            if (Vector2.Distance(transform.position, target.position) < 10.0f)
            {
                currentState = MonsterData.MonsterState.Attack;
                StartCoroutine(AttackCoroutine());
            }
            else
            {
                currentState = MonsterData.MonsterState.Move; // 공격 범위 외로 나가면 이동 상태로 변경
            }
        }

        // 이동 애니메이션 상태 관리
        anim.SetBool("move", currentState == MonsterData.MonsterState.Move);
    }

    private IEnumerator AttackCoroutine()
    {
        canAttack = false; // 공격 불가 상태로 설정
        anim.SetTrigger("attack");

        yield return new WaitForSeconds(0.4f); // 공격 애니메이션 대기

        // 총알 인스턴스화
        GameObject bulletObject = Instantiate(bulletPrefab, firePos.position, Quaternion.identity);
        Bullet bullet = bulletObject.GetComponent<Bullet>();

        if (bullet != null)
        {
            Vector2 direction = (target.position - firePos.position).normalized; // 타겟 방향 계산
            bullet.SetDirection(direction); // 방향 설정
            bullet.power = monsterData.power; // 총알의 공격력 설정
        }

        yield return new WaitForSeconds(monsterData.attackInterval); // 다음 공격까지 대기
        canAttack = true; // 공격 가능 상태로 변경
        anim.SetBool("move", false);
    }
}
