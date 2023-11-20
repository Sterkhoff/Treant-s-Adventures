using UnityEngine;


public class Inventory : MonoBehaviour
{
    public string[] Items;
    public int? ChoosenSlotNumber;
    public InventoryUI InventoryPanel;

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
            if (Items[i] == string.Empty)
            {
                Items[i] = itemForAdd.Name;
                InventoryPanel.AddToInventory(itemForAdd, i);
                break;
            }
        }
    }

    public void DeleteFromInventory(int itemSlotNumber)
    {
        InventoryPanel.DeleteFromInventory(itemSlotNumber);
        Items[itemSlotNumber] = string.Empty;
        if (ChoosenSlotNumber == itemSlotNumber)
            ChooseSlot(itemSlotNumber);
    }

    private void ChooseSlot(int slotNumber)
    {
        InventoryPanel.ChooseSlot(slotNumber);
        ChoosenSlotNumber = ChoosenSlotNumber == slotNumber ? null : slotNumber;
    }
}
