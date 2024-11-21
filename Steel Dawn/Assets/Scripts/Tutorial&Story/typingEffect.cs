using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class typingEffect : MonoBehaviour
{
    public Text tx;
    public Image[] storyImages;
    private List<StoryTextData> storyText;
    public int currentTextIndex = 0;
    private Coroutine typingCoroutine;

    private void Awake()
    {
        storyText = new List<StoryTextData>
        {
            new StoryTextData(0, "때는 205X년, 세상은 많이 발전했다."),
            new StoryTextData(1, "가온 기업의 기술 개발을 중심으로 세계의 가장 큰 이슈는 기계의 발달이 되었다."),
            new StoryTextData(2, "나는 가온에서 젊음을 바치며 기술 개발에 큰 공을 세워 꽤 높은 직급을 달 수 있었다."),
            new StoryTextData(3, "하지만 문제는 여기서 벌어졌다."),
            new StoryTextData(4, "기업의 욕심으로 시작된 심각한 오류는 인류에게 큰 영향을 미쳤고"),
            new StoryTextData(5, "해당 오류로 인해 기계들은 자아를 가지기 시작하였다."),
            new StoryTextData(6, "모든 기술진들이 알 수 없는 오류를 고치려고 매일 밤을 지새웠지만"),
            new StoryTextData(7, "결국 인류는 기계에게 지배 당하고 말았다."),
            new StoryTextData(8, "거기까지는 나와 상관 없는 일이었다."),
            new StoryTextData(9, "가장 큰 문제는 . . ."),
            new StoryTextData(10, "내 딸이 사라졌다."),
            new StoryTextData(11, "영문도 모른 채 잡혀 간 내 딸을 찾다보니 도착한 곳은"),
            new StoryTextData(12, "가온, 내가 몸 담았던 그 기업이었다."),
            new StoryTextData(13, "몰아치는 적들을 쫓아 가던 중 정신을 차려보니"),
            new StoryTextData(14, "나는 회사 옥상에 올라와있었다.")
        };
    }

    private void Start()
    {
        currentTextIndex = -1;  // Start with the first text index
        ButtonClick();          // Immediately display the first text
    }

    private void Update()
    {
        switch (currentTextIndex)
        {
            case 0:
            case 1:
                storyImages[0].gameObject.SetActive(true); 
                break;
            case 2:
                storyImages[1].gameObject.SetActive(true);
                break;
            case 3:
                foreach (Image img in storyImages)
                {
                    img.gameObject.SetActive(false);
                }
                break;
            case 4:
            case 5:
                storyImages[2].gameObject.SetActive(true);
                break;
            case 6:
                storyImages[3].gameObject.SetActive(true);
                break;
            case 7:
                storyImages[4].gameObject.SetActive(true);
                break;
            case 8:
                storyImages[5].gameObject.SetActive(true);
                break;
            case 9:
                foreach (Image img in storyImages)
                {
                    img.gameObject.SetActive(false);
                }
                break;
            case 10:
                storyImages[6].gameObject.SetActive(true);
                break;
            case 11:
                storyImages[7].gameObject.SetActive(true);
                break;
            case 12:
                storyImages[8].gameObject.SetActive(true);
                break;
            case 13:
                storyImages[9].gameObject.SetActive(true);
                break;
            case 14:
            case 15:
                storyImages[9].gameObject.SetActive(true);
                break;
            default :
                foreach (Image img in storyImages)
                {
                    img.gameObject.SetActive(false);
                }
                break;
        }
    }

    public void ButtonClick()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        if (currentTextIndex <= 14)
        {
            ++currentTextIndex;
            typingCoroutine = StartCoroutine(typing(currentTextIndex));
        }
        if(currentTextIndex == 15)
        {
            Loading.LoadScene("TutorialScene");
        }
    }

    IEnumerator typing(int textNum)
    {
        string selectedText = storyText[textNum].Text;
        tx.text = "";  // 초기화

        for (int i = 0; i <= selectedText.Length; i++)
        {
            tx.text = selectedText.Substring(0, i);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
