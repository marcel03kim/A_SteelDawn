using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    public Sprite[] itemSprites; // 유니티 에디터에서 연결할 스프라이트 배열
    private List<ItemData> itemLists;

    private void Awake()
    {
        itemLists = new List<ItemData>
        {
            new ItemData(0, "칼", "근접 공격", itemSprites.Length > 0 ? itemSprites[0] : null),
            new ItemData(1, "총", "원거리 공격.", itemSprites.Length > 1 ? itemSprites[1] : null),
            new ItemData(2, "캐논", "광역 원거리 공격", itemSprites.Length > 2 ? itemSprites[2] : null),
            new ItemData(3, "구체", "네 곁을 맴돈다", itemSprites.Length > 3 ? itemSprites[3] : null),
            new ItemData(4, "장판", "네 주변이 붉어질 거야", itemSprites.Length > 4 ? itemSprites[4] : null),
            new ItemData(5, "체력", "더 많이 맞을 수 있게 된다", itemSprites.Length > 5 ? itemSprites[5] : null),
            new ItemData(6, "범위", "더 커질 거야", itemSprites.Length > 6 ? itemSprites[6] : null),
            new ItemData(7, "스킬 가속", "더 빠르게, 더 많이", itemSprites.Length > 7 ? itemSprites[7] : null),
            new ItemData(8, "방어력", "꽤 단단해지겠군", itemSprites.Length > 8 ? itemSprites[8] : null),
            new ItemData(9, "공격력", "피 냄새... 아니, 오일 냄새가 진동을 하는군", itemSprites.Length > 9 ? itemSprites[9] : null),
            new ItemData(100, "칼", "근접 공격 + 1", itemSprites.Length > 0 ? itemSprites[0] : null),
            new ItemData(101, "총", "원거리 공격 + 1", itemSprites.Length > 1 ? itemSprites[1] : null),
            new ItemData(102, "캐논", "광역 원거리 공격 + 1", itemSprites.Length > 2 ? itemSprites[2] : null),
            new ItemData(103, "구체", "네 곁을 맴돈다 + 1", itemSprites.Length > 3 ? itemSprites[3] : null),
            new ItemData(104, "장판", "네 주변이 붉어질 거야 + 1", itemSprites.Length > 4 ? itemSprites[4] : null),
            new ItemData(105, "체력", "더 많이 맞을 수 있게 된다 + 1", itemSprites.Length > 5 ? itemSprites[5] : null),
            new ItemData(106, "범위", "더 커질 거야 + 1", itemSprites.Length > 6 ? itemSprites[6] : null),
            new ItemData(107, "스킬 가속", "더 빠르게, 더 많이 + 1", itemSprites.Length > 7 ? itemSprites[7] : null),
            new ItemData(108, "방어력", "꽤 단단해지겠군 + 1", itemSprites.Length > 8 ? itemSprites[8] : null),
            new ItemData(109, "공격력", "피 냄새... 아니, 오일 냄새가 진동을 하는군 + 1", itemSprites.Length > 9 ? itemSprites[9] : null),
            new ItemData(200, "칼", "근접 공격 + 2", itemSprites.Length > 0 ? itemSprites[0] : null),
            new ItemData(201, "총", "원거리 공격 + 2", itemSprites.Length > 1 ? itemSprites[1] : null),
            new ItemData(202, "캐논", "광역 원거리 공격 + 2", itemSprites.Length > 2 ? itemSprites[2] : null),
            new ItemData(203, "구체", "네 곁을 맴돈다 + 2", itemSprites.Length > 3 ? itemSprites[3] : null),
            new ItemData(204, "장판", "네 주변이 붉어질 거야 + 2", itemSprites.Length > 4 ? itemSprites[4] : null),
            new ItemData(205, "체력", "더 많이 맞을 수 있게 된다 + 2", itemSprites.Length > 5 ? itemSprites[5] : null),
            new ItemData(206, "범위", "더 커질 거야 + 2", itemSprites.Length > 6 ? itemSprites[6] : null),
            new ItemData(207, "스킬 가속", "더 빠르게, 더 많이 + 2", itemSprites.Length > 7 ? itemSprites[7] : null),
            new ItemData(208, "방어력", "꽤 단단해지겠군 + 2", itemSprites.Length > 8 ? itemSprites[8] : null),
            new ItemData(209, "공격력", "피 냄새... 아니, 오일 냄새가 진동을 하는군 + 2", itemSprites.Length > 9 ? itemSprites[9] : null)
        };
    }

    public ItemData GetItemData(int index)
    {
        return itemLists.Find(item => item.Id == index) ?? new ItemData(-1, "Unknown", "Item not found", null);
    }
}