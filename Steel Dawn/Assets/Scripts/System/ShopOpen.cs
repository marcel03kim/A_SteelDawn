using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopOpen : MonoBehaviour
{
    public RectTransform barUp;         // ���� ��
    public RectTransform barDown;       // �Ʒ��� ��
    public RectTransform maskArea;      // Mask�� ����� ����

    public float upTargetY = 44f;       // BarUp�� ��ǥ y ��ġ
    public float downTargetY = -44f;    // BarDown�� ��ǥ y ��ġ
    public float moveSpeed = 2f;        // �� �̵� �ӵ�

    public Vector2 maskTargetSize = new Vector2(192f, 108f); // Mask�� ��ǥ ũ��

    void Start()
    {
        // ���� �� Mask ������ �ּҷ� �����Ͽ� �̹����� ������ �ʵ��� ��
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

            // BarUp�� BarDown�� Lerp�� �ε巴�� �̵�
            barUp.anchoredPosition = Vector2.Lerp(upStartPos, upTargetPos, elapsed);
            barDown.anchoredPosition = Vector2.Lerp(downStartPos, downTargetPos, elapsed);

            // Mask�� ũ�⸦ ��ǥ ũ��� Lerp�� ����
            maskArea.sizeDelta = Vector2.Lerp(maskStartSize, maskTargetSize, elapsed);

            yield return null;
        }
    }
}