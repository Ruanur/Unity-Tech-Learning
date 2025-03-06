using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items; //�������� ���� ����Ʈ

    [SerializeField] private Transform slotParent; //Slot�� �θ� �Ǵ� Bag�� ���� ��
    [SerializeField] private Slot[] slots; //Bag�� ������ ��ϵ� Slot�� ���� ��

#if UNITY_EDITOR
    //OnValidate(): ����Ƽ �����Ϳ��� �ٷ� �۵��� �ϴ� ����
    //Bag�� ������ Bag�� ���� slot�� �ڵ����� ���
    private void OnValidate() 
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
    }
#endif
    //������ ���۵Ǹ� items�� ��� �ִ� �������� �κ��丮�� ����
    void Awake()
    {
        FreshSlot();
    }
    //FreshSlot()
    //�������� �����ų� ������ Slot�� ������ �ٽ� �����Ͽ� ȭ�鿡 ���
    //ù��° if��: items�� ����ִ� ����ŭ slots�� ���ʷ� item�� ����
    //slot�� item�� ���� Slot.cs�� ����� item�� set ���� ������ ����,
    //�ش� ���Կ� �̹��� ǥ��
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
            Debug.Log("�κ��丮 ������ ���ڶ��ϴ�!");
        }
    }
}
