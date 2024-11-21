using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    // 슬롯 상태를 나타내는 enum
    public enum SlotState { Empty, Full }
    public SlotState state = SlotState.Empty;

    // 슬롯 종류를 나타내는 enum
    public enum SlotType { ItemSlot, WeaponSlot }
    public SlotType slotType;

    public Image itemImage;        // 슬롯에 표시할 아이템 이미지
    public Text levelText;         // 슬롯에 표시할 레벨 텍스트
    public int itemID;
    public int itemLevel;
    public int slotID;

    // 아이템을 슬롯에 설정하는 메서드
    public void SetItem(ItemData newItemData, int level)
    {
        itemLevel = level;

        if (newItemData != null)
        {
            // 아이템 데이터가 있을 경우 슬롯에 레벨과 스프라이트 설정
            levelText.text = $"{level}";
            itemImage.sprite = newItemData.Icon;
            itemImage.color = new Color(1, 1, 1, 1); // 알파값을 1로 설정
            levelText.gameObject.SetActive(true);    // 레벨 텍스트 활성화
        }
        else
        {
            // 아이템 데이터가 없을 경우 스프라이트의 알파값을 0으로 설정
            itemImage.color = new Color(1, 1, 1, 0); // 알파값을 0으로 설정
            levelText.gameObject.SetActive(false);   // 레벨 텍스트 비활성화
        }
    }

    // 슬롯이 아이템 슬롯인지 무기 슬롯인지 확인하는 함수
    public bool IsItemSlot()
    {
        return slotType == SlotType.ItemSlot;
    }

    public bool IsWeaponSlot()
    {
        return slotType == SlotType.WeaponSlot;
    }
}
