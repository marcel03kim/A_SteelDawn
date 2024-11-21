using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Image[] tutorialimage;
    private List<TutorialTextData> tutorialText;
    public int currentTextIndex = 0;
    private Coroutine typingCoroutine;
    private bool isMoving;
    private bool isAttacked;
    private bool isLevelUp;
    private bool isSpawned = false;

    public Button skipButton;
    public GameObject player;
    public GameObject monster;
    public GameObject exp;
    public GameObject playerStartSetting;
    public GameObject stage;
    public Text tx;
    private Player playerScript; // Player 스크립트를 참조하기 위한 변수

    private void Awake()
    {
        tutorialText = new List<TutorialTextData>
        {
            new TutorialTextData(0, "Steel Dawn에 오신 걸 환영합니다"),
            new TutorialTextData(1, "기본 조작은 WASD로 이동하며 몬스터를 향해 자동으로 공격합니다"),
            new TutorialTextData(2, "한 번 움직여볼까요?"),
            new TutorialTextData(3, "잘하셨습니다"),
            new TutorialTextData(4, "지금 보이는 슬롯은 아이템과 무기창입니다"),
            new TutorialTextData(5, "레벨업 할 때마다 세 가지 카드 중 원하는 것을 고르면 이곳에 추가됩니다"),
            new TutorialTextData(6, "마침 저기 경험치가 있군요"),
            new TutorialTextData(7, "한 번 다가가볼까요?"),
            new TutorialTextData(8, "잘 하셨습니다"),
            new TutorialTextData(9, "몬스터는 죽을 때마다 랜덤하게 경험치와 골드를 떨어뜨립니다"),
            new TutorialTextData(10, "경험치를 획득하면 해당 게이지가 차오릅니다"),
            new TutorialTextData(11, "이제 몬스터가 출몰하기 시작한 것 같네요"),
            new TutorialTextData(12, "한 번 피해볼까요?"),
            new TutorialTextData(13, "저런, 많이 아프실 것 같네요"),
            new TutorialTextData(14, "지금 보이는 게이지는 당신의 체력입니다"),
            new TutorialTextData(15, "체력이 모두 소모되면 뭐,"),
            new TutorialTextData(16, "당신도 잘 아실 거라고 생각합니다"),
            new TutorialTextData(17, "그럼 부디 무탈하시길")
        };
    }


    private void Start()
    {
        // Player 스크립트 컴포넌트 가져오기
        playerScript = player.GetComponent<Player>();
        currentTextIndex = -1;
        monster.gameObject.SetActive(false);
        exp.gameObject.SetActive(false);
        ButtonClick();
    }

    public void Update()
    {
        // 플레이어가 움직였는지 체크
        if (playerScript != null)
        {
            CheckPlayerMovement();
            CheckPlayerLevelUp();
            CheckPlayerAttack();
        }

        switch(currentTextIndex)
        {
            case 2:
                if (Input.anyKeyDown)
                {
                    foreach (Image img in tutorialimage)
                    {
                        img.gameObject.SetActive(false);
                    }
                }
                break;
            case 6:
                if (!isSpawned)
                {
                    Vector3 expPosition = new Vector3(player.transform.position.x + 12f, player.transform.position.y - 1.5f, player.transform.position.z);
                    exp.transform.position = expPosition;
                    exp.SetActive(true);
                }
                break;

            case 7:
                if (Input.anyKeyDown)
                {
                    foreach (Image img in tutorialimage)
                    {
                        img.gameObject.SetActive(false);
                    }
                }
                break;
            case 12:
                if (Input.anyKeyDown)
                {
                    foreach (Image img in tutorialimage)
                    {
                        img.gameObject.SetActive(false);
                    }

                    if (!isSpawned)
                    {
                        // 새로운 Vector3 위치 생성하여 몬스터 위치 설정
                        Vector3 spawnPosition = new Vector3(player.transform.position.x + 12f, player.transform.position.y - 0.5f, player.transform.position.z);
                        monster.transform.position = spawnPosition;
                        monster.SetActive(true);
                        isSpawned = true;
                    }
                }
                break;
            case 18:
            case 19:
                stage.GetComponent<StageData>().isTutorialClear = true;
                Loading.LoadScene("MainScene");
                break;
        }
    }
    public void ButtonClick()
    {
        ++currentTextIndex;

        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        foreach (Image img in tutorialimage)
        {
            img.gameObject.SetActive(false);
        }

        if (currentTextIndex <= 17)
        {
            typingCoroutine = StartCoroutine(typing(currentTextIndex));
            switch (currentTextIndex)
            {
                case 0:
                case 1:
                    tutorialimage[0].gameObject.SetActive(true);
                    tutorialimage[1].gameObject.SetActive(true);
                    break;
                case 2:
                    tutorialimage[0].gameObject.SetActive(true);
                    tutorialimage[1].gameObject.SetActive(true);
                    skipButton.gameObject.SetActive(false);
                    break;
                case 3:
                    skipButton.gameObject.SetActive(true);
                    tutorialimage[0].gameObject.SetActive(true);
                    tutorialimage[1].gameObject.SetActive(true);
                    break;
                case 4:
                case 5:
                    tutorialimage[0].gameObject.SetActive(true);
                    tutorialimage[1].gameObject.SetActive(true);
                    tutorialimage[2].gameObject.SetActive(true);
                    break;
                case 6:
                    tutorialimage[0].gameObject.SetActive(true);
                    tutorialimage[1].gameObject.SetActive(true);
                    tutorialimage[3].gameObject.SetActive(true);
                    break;
                case 7:
                    tutorialimage[0].gameObject.SetActive(true);
                    tutorialimage[1].gameObject.SetActive(true);
                    tutorialimage[3].gameObject.SetActive(true);
                    skipButton.gameObject.SetActive(false);
                    break;
                case 8:
                    skipButton.gameObject.SetActive(true);
                    tutorialimage[0].gameObject.SetActive(true);
                    tutorialimage[1].gameObject.SetActive(true);
                    break;
                case 9:
                    tutorialimage[0].gameObject.SetActive(true);
                    tutorialimage[1].gameObject.SetActive(true);
                    break;
                case 10:
                    tutorialimage[0].gameObject.SetActive(true);
                    tutorialimage[1].gameObject.SetActive(true);
                    tutorialimage[4].gameObject.SetActive(true);
                break;
                case 11:
                    tutorialimage[0].gameObject.SetActive(true);
                    tutorialimage[1].gameObject.SetActive(true);
                    break;
                case 12:
                    tutorialimage[0].gameObject.SetActive(true);
                    tutorialimage[1].gameObject.SetActive(true);
                    skipButton.gameObject.SetActive(false);
                    break;
                case 13:
                    skipButton.gameObject.SetActive(true);
                    tutorialimage[0].gameObject.SetActive(true);
                    tutorialimage[1].gameObject.SetActive(true);
                    break;
                case 14:
                    tutorialimage[0].gameObject.SetActive(true);
                    tutorialimage[1].gameObject.SetActive(true);
                    tutorialimage[5].gameObject.SetActive(true);
                    break;
                case 15:
                case 16:
                    tutorialimage[0].gameObject.SetActive(true);
                    tutorialimage[1].gameObject.SetActive(true);
                    break;
                case 17:
                    tutorialimage[0].gameObject.SetActive(true);
                    tutorialimage[1].gameObject.SetActive(true);
                    break;
                
                default:
                    foreach (Image img in tutorialimage)
                    {
                        img.gameObject.SetActive(false);
                    }
                    break;
            }
        }
    }

    IEnumerator typing(int textNum)
    {
        string selectedText = tutorialText[textNum].tutorialText;
        tx.text = "";  // 초기화

        for (int i = 0; i <= selectedText.Length; i++)
        {
            tx.text = selectedText.Substring(0, i);
            yield return new WaitForSeconds(0.05f);
        }
    }
    private void CheckPlayerMovement()
    {
        
        if (playerScript.rb.velocity.magnitude > 0 && !isMoving && currentTextIndex == 2)
        {
            ButtonClick();
            isMoving = true;
        }
    }

    private void CheckPlayerLevelUp()
    {
        // 레벨업 여부 체크
        if (playerScript.isLevelUp && !isLevelUp)
        {
            ButtonClick();
            isLevelUp = true;
        }
    }

    private void CheckPlayerAttack()
    {
        // 현재 HP가 최대 HP보다 낮은 경우 공격 당함으로 간주
        if (playerScript.currentHp < playerStartSetting.GetComponent<PlayerUpgrade>().StartHp && !isAttacked)
        {
            ButtonClick();
            monster.gameObject.SetActive(false);
            isAttacked = true;
        }
    }

}
