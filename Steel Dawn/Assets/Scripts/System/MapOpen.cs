using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapOpen : MonoBehaviour
{
    public RectTransform barUp;         // 위쪽 바
    public RectTransform barDown;       // 아래쪽 바
    public RectTransform maskArea;      // Mask가 적용된 영역

    public float upTargetY = 50f;       // BarUp의 목표 y 위치
    public float downTargetY = -50f;    // BarDown의 목표 y 위치
    public float moveSpeed = 2f;        // 바 이동 속도

    public Vector2 maskTargetSize = new Vector2(192f, 108f); // Mask의 목표 크기

    void Start()
    {
        // 시작 시 Mask 영역을 최소로 설정하여 이미지가 보이지 않도록 함
        maskArea.sizeDelta = Vector2.zero;
        StartCoroutine(MoveBarsAndAdjustMask());
        barDown.transform.localPosition = new Vector2(barDown.anchoredPosition.x, 0);
        barUp.transform.localPosition = new Vector2(barUp.anchoredPosition.x, 0);
    }

    IEnumerator MoveBarsAndAdjustMask()
    {
        Vector2 upStartPos = barUp.anchoredPosition;
        Vector2 downStartPos = barDown.anchoredPosition;
        Vector2 upTargetPos = new Vector2(upStartPos.x, upTargetY);
        Vector2 downTargetPos = new Vector2(downStartPos.x, downTargetY);
        Vector2 maskStartSize = Vector2.zero;

        float elapsed = 0f;

        while (elapsed < 1f)
        {
            elapsed += Time.deltaTime * moveSpeed;

            // BarUp과 BarDown을 Lerp로 부드럽게 이동
            barUp.anchoredPosition = Vector2.Lerp(upStartPos, upTargetPos, elapsed);
            barDown.anchoredPosition = Vector2.Lerp(downStartPos, downTargetPos, elapsed);

            // Mask의 크기를 목표 크기로 Lerp로 조정
            maskArea.sizeDelta = Vector2.Lerp(maskStartSize, maskTargetSize, elapsed);

            yield return null;
        }
    }
}
