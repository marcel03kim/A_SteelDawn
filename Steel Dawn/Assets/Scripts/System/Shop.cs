using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject playerStat;

    private int hpLevel;
    private int speedLevel;
    private int powerLevel;
    private int defenseLevel;

    public void BuyStat(string name)
    {
        switch (name)
        {
            case "Hp":
                playerStat.GetComponent<PlayerUpgrade>().StartHp += 10;
                break;
            case "Speed":
                playerStat.GetComponent<PlayerUpgrade>().StartSpeed += 5;
                break;
            case "Power":
                playerStat.GetComponent<PlayerUpgrade>().StartPower += 15;
                break;
            case "Defense":
                playerStat.GetComponent<PlayerUpgrade>().StartDefense += 8;
                break;
            default:
                break;
        }
    }

    public void GoMain()
    {
        Loading.LoadScene("MainScene");
    }
}
