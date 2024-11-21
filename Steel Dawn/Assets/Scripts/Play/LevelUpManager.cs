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

    // ���� ���� �� ���� ĳ��
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
            Debug.LogError("ItemList�� ���� �����ϴ�. ItemList ������Ʈ�� �ִ��� Ȯ���ϼ���.");
            return;
        }

        CacheSlotData(); // ���� ������ ĳ��
        UpdateRandomItemDetails();
    }

    // ���� �����͸� ĳ���Ͽ� ������ ������ �� �ֵ��� �ϴ� �޼���
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
            ItemData itemData = itemList.GetItemData(selectedItemID); // itemList���� ������ �����͸� ������

            if (itemData != null)
            {
                slot.SetItem(itemData, slot.itemLevel); // ������ �����Ϳ� ���ο� ������ ����
                Debug.Log($"Item ID {selectedItemID}�� ������ {slot.itemLevel}�� �����߽��ϴ�.");
            }
            else
            {
                Debug.LogWarning($"������ ID {selectedItemID}�� �ش��ϴ� ItemData�� ã�� �� �����ϴ�.");
            }
        }
        else
        {
            AddNewItemToSlot(selectedItemID);
        }

        Time.timeScale = 1.0f;
        LevelUpCanvas.SetActive(false);
    }


    // �������� �� ���Կ� �߰��ϴ� �޼���
    private void AddNewItemToSlot(int itemID)
    {
        Slot targetSlot = null;

        // ������ ID�� ���� ������ ������ ����
        if (itemID >= 0 && itemID < 5 && emptyWeaponSlots.Count > 0)
        {
            targetSlot = emptyWeaponSlots[0];
            emptyWeaponSlots.RemoveAt(0); // ������ ������ ����Ʈ���� ����
        }
        else if (itemID >= 5 && itemID < 10 && emptyItemSlots.Count > 0)
        {
            targetSlot = emptyItemSlots[0];
            emptyItemSlots.RemoveAt(0); // ������ ������ ����Ʈ���� ����
        }

        if (targetSlot != null)
        {
            ItemData itemData = itemList.GetItemData(itemID); // itemList���� ������ �����͸� ������

            if (itemData != null)
            {
                targetSlot.state = Slot.SlotState.Full;
                targetSlot.itemID = itemID;
                targetSlot.itemLevel = 1; // �⺻ ������ 1�� ����
                targetSlot.SetItem(itemData, targetSlot.itemLevel); // ������ �����Ϳ� ������ ����
                itemIDtoSlotMap[itemID] = targetSlot; // ������ �ʿ� �߰�

                Debug.Log($"���ο� ������ ID {itemID}�� ���� {targetSlot.slotID}�� ���� 1�� �߰��Ǿ����ϴ�.");
            }
            else
            {
                Debug.LogWarning($"������ ID {itemID}�� �ش��ϴ� ItemData�� ã�� �� �����ϴ�.");
            }
        }
        else
        {
            Debug.LogWarning("�������� �߰��� ������ �� ������ �����ϴ�.");
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
