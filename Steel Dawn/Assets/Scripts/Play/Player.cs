using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    public float Hp;
    public float currentHp;
    public float speed;
    public float power;
    public float defense;
    public int level = 0;
    public float exp = 0;
    public Image healthBar; 

    public GameObject playerStartSetting;

    public GameObject gameOver;
    public GameObject stage;
    public Camera cam;

    public bool isLevelUp = false;
    private Animator anim;
    private LevelUpManager levelUpManager;
    public GameObject[] expSprite; // 경험치에 따른 스프라이트 배열
    private SpriteRenderer spriteRenderer; // 스프라이트 렌더러

    Vector2 movement = new Vector2();
    public Rigidbody2D rb;

    private void Start()
    {
        gameObject.transform.position = new Vector3(0, 0, 0);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // 스프라이트 렌더러 초기화
        levelUpManager = GetComponent<LevelUpManager>();
        UpdateExpSprites(); // 초기 스프라이트 설정
        gameOver.SetActive(false);

        Hp = playerStartSetting.GetComponent<PlayerUpgrade>().StartHp;
        speed = playerStartSetting.GetComponent<PlayerUpgrade>().StartSpeed;
        power = playerStartSetting.GetComponent<PlayerUpgrade>().StartPower;
        defense = playerStartSetting.GetComponent<PlayerUpgrade>().StartDefense;
        currentHp = Hp;
        exp = 0;
    }

    private void Update()
    {
        // 경험치에 따라 스프라이트 업데이트
        UpdateExpSprites();
        UpdateHealthBar();

        if (!isLevelUp && exp >= 190)
        {
            isLevelUp = true;
            LevelUp();
        }

        if(currentHp <= 0)
        {
            StartCoroutine(DieCoroutine());
        }
    }

    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = currentHp / Hp;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement != Vector2.zero)
        {
            // 캐릭터의 방향을 설정
            if (movement.x < 0)
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else if (movement.x > 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }

            // 이동 중이면 무브 애니메이션을 출력
            anim.SetBool("move", true);
        }
        else
        {
            // 이동이 멈추면 idle 애니메이션으로 전환
            anim.SetBool("move", false);
        }

        // 벡터를 정규화하고 속도를 곱해서 이동 설정
        movement.Normalize();
        rb.velocity = movement * speed;
    }



    void LevelUp()
    {
        level += 1;
        exp -= 190;
        isLevelUp = false;
        if(stage.GetComponent<StageData>() != null)
        {
            if(stage.GetComponent<StageData>().currentPlayStage == -1)
            {
                isLevelUp = true;
            }
            else
            {
                levelUpManager.GetComponent<LevelUpManager>().PlayerLevelUp();
            }
        }
    }

    // 경험치에 따라 스프라이트를 업데이트하는 메서드
    private void UpdateExpSprites()
    {
        // 모든 스프라이트 비활성화
        foreach (GameObject sprite in expSprite)
        {
            sprite.SetActive(false);
        }

        // 경험치에 따라 스프라이트 활성화 (10 단위로 증가)
        int numSpritesToActivate = (int)exp / 10;

        // 활성화할 스프라이트 개수만큼 반복
        for (int i = 0; i < numSpritesToActivate && i < expSprite.Length; i++)
        {
            expSprite[i].SetActive(true);
        }
    }

    private IEnumerator DieCoroutine()
    {
        anim.SetTrigger("die");

        yield return new WaitForSeconds(3f);

        gameOver.SetActive(true);  
    }

    public void GoMain()
    {
        Loading.LoadScene("MainScene");
    }
}
