using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpIncrease : MonoBehaviour
{
    public int itemLevel;
    public GameObject player;
    private void Start()
    {
        itemLevel = 0;
    }

    public void Update()
    {
        switch(itemLevel)
        {
            case 0 : player.GetComponent<Player>().Hp = 100;
                break;
            case 1:
                player.GetComponent<Player>().Hp = 100;
                break;
            case 2:
                player.GetComponent<Player>().Hp = 100;
                break;
            case 3:
                player.GetComponent<Player>().Hp = 100;
                break;
        }
    }
}
