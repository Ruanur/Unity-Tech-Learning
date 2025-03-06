using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items; //아이템을 담을 리스트

    [SerializeField] private Transform slotParent; //Slot의 부모가 되는 Bag을 담을 곳
    [SerializeField] private Slot[] slots; //Bag의 하위에 등록된 Slot을 담을 곳

#if UNITY_EDITOR
    //OnValidate(): 유니티 에디터에서 바로 작동을 하는 역할
    //Bag을 넣으면 Bag의 하위 slot이 자동으로 등록
    private void OnValidate() 
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
    }
#endif
    //게임이 시작되면 items에 들어 있는 아이템을 인벤토리에 넣음
    void Awake()
    {
        FreshSlot();
    }
    //FreshSlot()
    //아이템이 들어오거나 나가면 Slot의 내용을 다시 정리하여 화면에 출력
    //첫번째 if문: items에 들어있는 수만큼 slots에 차례로 item을 넣음
    //slot에 item이 들어가면 Slot.cs에 선언된 item의 set 안의 내용이 실행,
    //해당 슬롯에 이미지 표시
    public void FreshSlot()
    {
        int i = 0;
        for (; i < items.Count && i < slots.Length; i++)
        {
            slots[i].item = items[i];
        }
        for (; i < slots.Length; i++)
        {
            slots[i].item = null;
        }
    }
    public void AddItem(Item _item)
    {
        if (items.Count < slots.Length)
        {
            items.Add(_item);
            FreshSlot();
        }
        else
        {
            Debug.Log("인벤토리 공간이 모자랍니다!");
        }
    }
}
