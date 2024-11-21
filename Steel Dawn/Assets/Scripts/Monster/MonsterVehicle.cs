using System.Collections;
using UnityEngine;

public abstract class MonsterVehicle : MonoBehaviour
{
    public MonsterData monsterData; // 몬스터 데이터

    // 비이클에 있어야 하는 변수들
    protected float hp;              // 몬스터 체력
    protected float speed;           // 몬스터 속도
    protected float power;           // 몬스터 공격력
    protected MonsterData.MonsterState currentState; // 몬스터의 현재 상태

    protected Rigidbody2D rb;        // 리지드바디 사용을 위한 변수
    protected Transform target;      // 플레이어 위치를 가져오기 위한 변수
    protected Animator anim;         // 애니메이션 적용을 위한 변수
    protected SpriteRenderer spriteRenderer; // 스프라이트에 접근하기 위한 변수

    private bool isDropped = false;  // 드랍 상태 변수 추가


    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Rigidbody2D 초기화
        anim = GetComponent<Animator>();   // Animator 초기화
        target = GameObject.FindWithTag("Player").transform;  // Player 태그를 가진 오브젝트 찾기
        spriteRenderer = GetComponent<SpriteRenderer>();  // SpriteRenderer 초기화

        // 몬스터 데이터에서 속성 가져오기
        if (monsterData != null)
        {
            hp = monsterData.hp;
            speed = monsterData.speed;
            power = monsterData.power;
            currentState = monsterData.initialState; // 초기 상태 설정
        }
        else
        {
            Debug.LogWarning("MonsterData is not assigned for " + gameObject.name);
        }

    }

    private void Update()
    {
        if (hp <= 0)
        {
            Die(); // 상태 변경
        }
    }

    protected void FixedUpdate()
    {
        switch (currentState)
        {
            case MonsterData.MonsterState.Move:
                Move();  // Move 메서드에 이동 로직 작성
                break;
            case MonsterData.MonsterState.Die:
                Die(); // Die 메서드에 죽음 로직 작성
                break;
        }
    }

    // Player를 향해 이동하는 메서드
    protected virtual void Move()
    {
        if (target != null)
        {
            Vector2 newPosition = Vector2.MoveTowards(rb.position, target.position, speed * Time.fixedDeltaTime);

            // 이동 방향에 따른 스프라이트 반전
            if (target.position.x > rb.position.x)
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }

            rb.MovePosition(newPosition);  // Rigidbody2D를 사용한 이동

            anim.SetBool("move", true); 

        }
    }


    protected virtual void Die()
    {
        anim.SetBool("move", false); // Move 애니메이션을 중지
        anim.SetTrigger("die");

        int lastClipIndex = anim.runtimeAnimatorController.animationClips.Length - 1;
        
        // 마지막 클립의 길이를 가져오기
        float dieAnimationLength = anim.runtimeAnimatorController.animationClips[lastClipIndex].length;

        // 애니메이션 클립의 길이만큼 대기
        StartCoroutine(FadeOutCoroutine(dieAnimationLength));
    }

    private IEnumerator FadeOutCoroutine(float duration)
    {
        yield return new WaitForSeconds(1.0f);

        float elapsedTime = 0f;
        Color color = spriteRenderer.color;  // 현재 스프라이트 색상 가져오기
        float startAlpha = color.a;  // 시작할 때의 알파 값

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;  // 경과 시간 업데이트
            color.a = Mathf.Lerp(startAlpha, 0f, elapsedTime / duration);  // 알파 값을 선형 보간하여 점차 0으로
            spriteRenderer.color = color;  // 스프라이트 색상 업데이트
            yield return null;  // 다음 프레임까지 대기
        }

        // 골드와 경험치 드랍 로직
        DropItems();

        // 마지막으로 알파 값을 0으로 설정
        color.a = 0f;
        spriteRenderer.color = color;

        // 최종적으로 오브젝트를 삭제
        Destroy(gameObject);
    }

    protected virtual void DropItems()
    {
        if (!isDropped)
        {
            int dropItem = Random.Range(0, 2); // 0 또는 1을 반환
            if (dropItem == 0)
            {
                GameObject exp = Instantiate(monsterData.expPrefab, transform.position, transform.rotation);
                isDropped = true;  // 드랍 완료 상태로 변경
                exp.GetComponent<GetExp>().getExp = 10;
            }
            else if (dropItem == 1)
            {
                GameObject exp = Instantiate(monsterData.expPrefab, transform.position, transform.rotation);
                GameObject gold = Instantiate(monsterData.goldPrefab, transform.position, transform.rotation);
                isDropped = true;  // 드랍 완료 상태로 변경
                exp.GetComponent<GetExp>().getExp = 10;
                gold.GetComponent<GetGold>().getGold = 10;
            }
        }
    }
}
