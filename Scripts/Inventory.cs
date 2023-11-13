using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Item[] Items;
    public Image[] Slots;
    public int? ChoosenSlotNumber;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChooseSlot(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChooseSlot(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChooseSlot(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChooseSlot(3);
        }
    }

    public void AddToInventory(Item itemForAdd)
    {
        for (var i = 0; i < Items.Length; i++)
        {
            if (Items[i].IsUnityNull())
            {
                Items[i] = itemForAdd;
                Instantiate(itemForAdd.ItemToDraw, Slots[i].transform, false);
                break;
            }
        }
    }

    public void DeleteFromInventory(int itemSlotNumber)
    {
        Destroy(Slots[itemSlotNumber].transform.GetChild(0).gameObject);
        Items[itemSlotNumber] = null;
        if (ChoosenSlotNumber == itemSlotNumber)
            ChooseSlot(itemSlotNumber);
    }

    private void ChooseSlot(int slotNumber)
    {
        ChoosenSlotNumber = ChoosenSlotNumber == slotNumber ? null : slotNumber;
        Slots[slotNumber].color = Slots[slotNumber].color == Color.gray ? Color.white : Color.gray;
        for (var i = 0; i < Slots.Length; i++)
        {
            if (i != slotNumber)
                Slots[i].color = Color.white;
        }
    }
}
