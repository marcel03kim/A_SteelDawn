using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    public GameObject stage;
    public Light2D eyeLight;

    private float Aduration = 2.0f; // 알파값 0인 상태 유지 시간
    private float Bduration = 0.2f; // 알파값 0에서 1로 변하는 시간
    private float Cduration = 0.3f; // 알파값 1에서 0으로 변하는 시간
    private float Dduration = 2.0f; // 알파값 1에서 0으로 변하는 시간

    private void Start()
    {
        if (eyeLight != null)
        {
            StartCoroutine(Fade());
        }
        else
        {
            Debug.LogError("Light component is not assigned.");
        }
    }

    private void Update()
    {
        if(Input.anyKeyDown)
        {
            if(stage.GetComponent<StageData>().isTutorialClear == false)
            {
                stage.GetComponent<StageData>().currentPlayStage = -1;
                Loading.LoadScene("StoryScene");
            }
            if (stage.GetComponent<StageData>().isTutorialClear == true)
            {
                Loading.LoadScene("MainScene");
            }
        }
    }

    private IEnumerator Fade()
    {
        while (true)
        {
            yield return StartCoroutine(FadeTo(1.0f, Bduration));
            yield return StartCoroutine(FadeTo(0.0f, Cduration));
            yield return StartCoroutine(FadeTo(1.0f, Bduration));
            yield return StartCoroutine(FadeTo(0.0f, Dduration));
            // 알파값 0인 상태 유지
            yield return new WaitForSeconds(Aduration);
        }
    }

    private IEnumerator FadeTo(float targetAlpha, float duration)
    {
        float startAlpha = eyeLight.color.a;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / duration);
            Color newColor = new Color(eyeLight.color.r, eyeLight.color.g, eyeLight.color.b, newAlpha);
            eyeLight.color = newColor;
            yield return null;
        }

        Color finalColor = new Color(eyeLight.color.r, eyeLight.color.g, eyeLight.color.b, targetAlpha);
        eyeLight.color = finalColor;
    }

    //private IEnumerator FadeToLOGO(float targetAlpha, float duration)
    //{
    //    float startAlpha = LogoLight.color.a;
    //    float elapsedTime = 0f;

    //    while (elapsedTime < duration)
    //    {
    //        elapsedTime += Time.deltaTime;
    //        float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / duration);
    //        Color newColor = new Color(LogoLight.color.r, LogoLight.color.g, LogoLight.color.b, newAlpha);
    //        LogoLight.color = newColor;
    //        yield return null;
    //    }

    //    Color finalColor = new Color(LogoLight.color.r, LogoLight.color.g, LogoLight.color.b, targetAlpha);
    //    LogoLight.color = finalColor;
    //}
}
