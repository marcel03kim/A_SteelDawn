using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpManager : MonoBehaviour
{
    public GameObject LevelUpCanvas;
    public Button[] itemButtons;
    public Text[] nameText;
    public Text[] descText;
    public Image[] itemImage;

    public Slot[] itemSlots;
    private ItemList itemList;
    private List<int> randomIndices;

    // 슬롯 상태 및 정보 캐싱
    private Dictionary<int, Slot> itemIDtoSlotMap;
    private List<Slot> emptyWeaponSlots;
    private List<Slot> emptyItemSlots;

    private void Awake()
    {
        itemIDtoSlotMap = new Dictionary<int, Slot>();
        emptyWeaponSlots = new List<Slot>();
        emptyItemSlots = new List<Slot>();
    }

    public void PlayerLevelUp()
    {
        Time.timeScale = 0f;
        LevelUpCanvas.SetActive(true);
        itemList = FindObjectOfType<ItemList>();

        if (itemList == null)
        {
            Debug.LogError("ItemList가 씬에 없습니다. ItemList 오브젝트가 있는지 확인하세요.");
            return;
        }

        CacheSlotData(); // 슬롯 데이터 캐시
        UpdateRandomItemDetails();
    }

    // 슬롯 데이터를 캐시하여 빠르게 접근할 수 있도록 하는 메서드
    private void CacheSlotData()
    {
        itemIDtoSlotMap.Clear();
        emptyWeaponSlots.Clear();
        emptyItemSlots.Clear();

        foreach (Slot slot in itemSlots)
        {
            if (slot.state == Slot.SlotState.Empty)
            {
                if (slot.slotType == Slot.SlotType.WeaponSlot)
                {
                    emptyWeaponSlots.Add(slot);
                }
                else if (slot.slotType == Slot.SlotType.ItemSlot)
                {
                    emptyItemSlots.Add(slot);
                }
            }
            else
            {
                itemIDtoSlotMap[slot.itemID] = slot;
            }
        }
    }

    public void UpdateRandomItemDetails()
    {
        bool allWeaponSlotsFull = emptyWeaponSlots.Count == 0;
        bool allItemSlotsFull = emptyItemSlots.Count == 0;

        if (allWeaponSlotsFull)
        {
            randomIndices = GetUniqueRandomIndices(3, 5, 10);
        }
        else if (allItemSlotsFull)
        {
            randomIndices = GetUniqueRandomIndices(3, 0, 5);
        }
        else
        {
            randomIndices = GetUniqueRandomIndices(3, 0, 10);
        }

        for (int i = 0; i < randomIndices.Count; i++)
        {
            int index = randomIndices[i];
            ItemData itemData = itemList.GetItemData(index);
            bool isOwned = itemIDtoSlotMap.ContainsKey(index);

            nameText[i].text = itemData.Name;
            itemImage[i].sprite = itemData.Icon;
            descText[i].text = isOwned ? GetUpdatedDescription(index, itemData) : itemData.Description;

            int buttonIndex = i;
            itemButtons[i].onClick.AddListener(() => OnItemButtonClick(buttonIndex));
        }
    }

    private string GetUpdatedDescription(int itemID, ItemData itemData)
    {
        int idMultiplier = itemIDtoSlotMap[itemID].itemLevel * 100;
        return $"{itemData.Description} +{idMultiplier}";
    }

    private void OnItemButtonClick(int index)
    {
        int selectedItemID = randomIndices[index];
        bool itemFound = itemIDtoSlotMap.ContainsKey(selectedItemID);

        if (itemFound)
        {
            Slot slot = itemIDtoSlotMap[selectedItemID];
            slot.itemLevel += 1;
            ItemData itemData = itemList.GetItemData(selectedItemID); // itemList에서 아이템 데이터를 가져옴

            if (itemData != null)
            {
                slot.SetItem(itemData, slot.itemLevel); // 아이템 데이터와 새로운 레벨을 설정
                Debug.Log($"Item ID {selectedItemID}의 레벨이 {slot.itemLevel}로 증가했습니다.");
            }
            else
            {
                Debug.LogWarning($"아이템 ID {selectedItemID}에 해당하는 ItemData를 찾을 수 없습니다.");
            }
        }
        else
        {
            AddNewItemToSlot(selectedItemID);
        }

        Time.timeScale = 1.0f;
        LevelUpCanvas.SetActive(false);
    }


    // 아이템을 빈 슬롯에 추가하는 메서드
    private void AddNewItemToSlot(int itemID)
    {
        Slot targetSlot = null;

        // 아이템 ID에 따라 적절한 슬롯을 선택
        if (itemID >= 0 && itemID < 5 && emptyWeaponSlots.Count > 0)
        {
            targetSlot = emptyWeaponSlots[0];
            emptyWeaponSlots.RemoveAt(0); // 선택한 슬롯을 리스트에서 제거
        }
        else if (itemID >= 5 && itemID < 10 && emptyItemSlots.Count > 0)
        {
            targetSlot = emptyItemSlots[0];
            emptyItemSlots.RemoveAt(0); // 선택한 슬롯을 리스트에서 제거
        }

        if (targetSlot != null)
        {
            ItemData itemData = itemList.GetItemData(itemID); // itemList에서 아이템 데이터를 가져옴

            if (itemData != null)
            {
                targetSlot.state = Slot.SlotState.Full;
                targetSlot.itemID = itemID;
                targetSlot.itemLevel = 1; // 기본 레벨을 1로 설정
                targetSlot.SetItem(itemData, targetSlot.itemLevel); // 아이템 데이터와 레벨을 설정
                itemIDtoSlotMap[itemID] = targetSlot; // 슬롯을 맵에 추가

                Debug.Log($"새로운 아이템 ID {itemID}가 슬롯 {targetSlot.slotID}에 레벨 1로 추가되었습니다.");
            }
            else
            {
                Debug.LogWarning($"아이템 ID {itemID}에 해당하는 ItemData를 찾을 수 없습니다.");
            }
        }
        else
        {
            Debug.LogWarning("아이템을 추가할 적절한 빈 슬롯이 없습니다.");
        }
    }


    private List<int> GetUniqueRandomIndices(int count, int minRange, int maxRange)
    {
        HashSet<int> uniqueIndices = new HashSet<int>();
        while (uniqueIndices.Count < count)
        {
            int randomIndex = UnityEngine.Random.Range(minRange, maxRange);
            uniqueIndices.Add(randomIndex);
        }
        return new List<int>(uniqueIndices);
    }
}
