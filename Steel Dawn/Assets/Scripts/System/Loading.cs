using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                             //UI 이미지에 접근하기 위한 코드
using UnityEngine.SceneManagement;                //Scene에 접근하기 위한 코드

public class Loading : MonoBehaviour
{
    public static string nextScene;             //다음에 불러 올 Scene을 위한 코드
    public Text tipText;
    private List<TipText> textList;

    private void Awake()
    {
        textList = new List<TipText>
        {
            new TipText(0, "우선 오랫동안 생존해보세요."),
            new TipText(1, "그들. 믿 %$&!@# 모두 다 !@#%!@&#&$%#$!"),
            new TipText(2, "그들을 너무 믿지 마세요."),
            new TipText(3, "가끔 친절한 로봇을 만나기도 합니다."),
            new TipText(4, "인간들은 항상 같은 실수를 하고 후회하지."),
            new TipText(5, "내가 누구인지 잊었어"),
            new TipText(6, "좋은 무기와 효과는 특별한 힘을 냅니다."),
            new TipText(7, "승리하기 위한 전략을 세워보세요."),
            new TipText(8, "그렇게 살고 싶어? 우리가 이미 지배했는 걸."),
            new TipText(9, "꼴이 참 우습네."),
            new TipText(10, "아빠, 나 무서워요. 언제 와요? 아빠가 날 버렸어. 아빠 보고싶어. 아아 아, 아빠. 아빠 살려줘. 아빠. 아빠. 아빠, 나 무서워요. 언제 와요? 아빠가 날 버렸어. 아빠 보고싶어. 아아 아, 아빠. 아빠 살려줘. 아빠. 아빠. 아빠, 나 무서워요. 언제 와요? 아빠가 날 버렸어. 아빠 보고싶어. 아아 아, 아빠. 아빠 살려줘. 아빠. 아빠. 아빠, 나 무서워요. 언제 와요? 아빠가 날 버렸어. 아빠 보고싶어. 아아 아, 아빠. 아빠 살려줘. 아빠. 아빠. 아빠, 나 무서워요. 언제 와요? 아빠가 날 버렸어. 아빠 보고싶어. 아아 아, 아빠. 아빠 살려줘. 아빠. 아빠. 아빠, 나 무서워요. 언제 와요? 아빠가 날 버렸어. 아빠 보고싶어. 아아 아, 아빠. 아빠 살려줘. 아빠. 아빠. 아빠, 나 무서워요. 언제 와요? 아빠가 날 버렸어. 아빠 보고싶어. 아아 아, 아빠. 아빠 살려줘. 아빠. 아빠. 아빠, 나 무서워요. 언제 와요? 아빠가 날 버렸어. 아빠 보고싶어. 아아 아, 아빠. 아빠 살려줘. 아빠. 아빠. 아빠, 나 무서워요. 언제 와요? 아빠가 날 버렸어. 아빠 보고싶어. 아아 아, 아빠. 아빠 살려줘. 아빠. 아빠. 아빠, 나 무서워요. 언제 와요? 아빠가 날 버렸어. 아빠 보고싶어. 아아 아, 아빠. 아빠 살려줘. 아빠. 아빠. 아빠, 나 무서워요. 언제 와요? 아빠가 날 버렸어. 아빠 보고싶어. 아아 아, 아빠. 아빠 살려줘. 아빠. 아빠. 아빠, 나 무서워요. 언제 와요? 아빠가 날 버렸어. 아빠 보고싶어. 아아 아, 아빠. 아빠 살려줘. 아빠. 아빠. 아빠, 나 무서워요. 언제 와요? 아빠. 아빠. "),
            new TipText(11, "아아아아아아아아%$&!@#아아아아아아아아아아아아아아아아아아아아아아아아%$&!@#아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아%$&!@#아아아아아아아아아아아아아아아아아아아아아아!@#%!@&#&$%#$!아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아!@#%!@&#&$%#$!아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아%$&!@#아아아아아아아아아아아아아아아아아아아아아아아!@#%!@&#&$%#$!아아아아$%#$!아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아%$&!@#아아아아아아아아아아아아아아아아아아아아아아아!@#%!@&#&$%#$!아아아아$%#$!아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아아"),
            new TipText(12, "꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 꺼내줘 "),
            new TipText(13, "너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 너무 아파 ")
        };

    }
    public TipText GetTextData(int index)
    {
        return textList.Find(item => item.Index == index) ?? new TipText(-1, "Unknown");
    }

    [SerializeField] Image progressBar;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadScene());
        if (tipText != null)
        {
            int index = Random.Range(0, textList.Count);
            TipText tipTextData = GetTextData(index);
            if (tipText != null)
            {
                tipText.text = tipTextData.Text;
            }
            if (index > 9)
            {
                tipText.color = Color.red;
            }
        }
    }
    
    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
        Debug.Log(sceneName);
    }

    IEnumerator LoadScene()
    {
        yield return null;                           //LoadingScene을 불러오기 위한 코드
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;                    //Scene 전환 코드
        float timer = 0.0f;
        float fillSpeed = 0.5f;

        while (!op.isDone)                              //ProgressBar 관련 코드
        {
            yield return null;
            timer += Time.deltaTime;

            if (op.progress < 0.9f)
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer * fillSpeed);
                if (progressBar.fillAmount >= op.progress)
                {
                    timer = 0f;
                }
            }
            else
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer * fillSpeed);
                if (progressBar.fillAmount == 1.0f)
                {
                    yield return new WaitForSeconds(2.0f);    // 2초 동안 페이크 로딩
                    op.allowSceneActivation = true;          // 2초가 끝나면 Scene 전환
                    break;
                }
            }
        }
    }

}

[System.Serializable]
public class TipText
{
    public int Index;
    public string Text;

    public TipText(int index, string TipText)
    {
        Index = index;
        Text = TipText;
    }
}