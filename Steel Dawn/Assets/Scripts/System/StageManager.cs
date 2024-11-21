using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public int currentStage;
    public GameObject stageData;
    public GameObject Dic;
    public Text warningText;

    public void Start()
    {
        currentStage = stageData.GetComponent<StageData>().openStage;
        warningText.gameObject.SetActive(false);
        Dic.SetActive(false);
    }

    public void SetPanel(string panelName)
    {
        Dic.SetActive(false);
        switch (panelName)
        {
            case "dic":
                Dic.SetActive(true);
                break;
            case "esc":
                Dic.SetActive(false);
                break;
            case "shop":
                Loading.LoadScene("ShopScene");
                break;
        }
    }

    public void StartStage(int stageNumber)
    {
        if (stageNumber <= currentStage)
        {
            Loading.LoadScene("GameScene");
            stageData.GetComponent<StageData>().currentPlayStage = stageNumber;
        }
        if (stageNumber > currentStage)
        {
            ShowWarning("이전 스테이지를 먼저 클리어 해주세요!");
        }
    }

    private void ShowWarning(string message)
    {
        warningText.text = message;
        warningText.gameObject.SetActive(true);
        Invoke("HideWarning", 1.5f); 
    }

    private void HideWarning()
    {
        warningText.gameObject.SetActive(false);
    }
}
