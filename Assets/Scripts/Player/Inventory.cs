using UnityEngine;


public class Inventory : MonoBehaviour
{
    public string[] Items;
    public InventoryUI InventoryPanel;
    public string ChoosenItem;
    private int choosenSlotNumber;
    private PlayerController player;

    private void Start()
    {
        player = GetComponent<PlayerController>();
        choosenSlotNumber = -1;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ChooseSlot(0);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            ChooseSlot(1);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            ChooseSlot(2);
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            ChooseSlot(3);
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

    public void DeleteChoosenFromInventory()
    {
        if (choosenSlotNumber != -1)
        {
            InventoryPanel.DeleteFromInventory(choosenSlotNumber);
            Items[choosenSlotNumber] = string.Empty;
            choosenSlotNumber = -1;
            ChoosenItem = string.Empty;
        }
    }

    private void ChooseSlot(int slotNumber)
    {
        choosenSlotNumber = choosenSlotNumber == slotNumber ? -1 : slotNumber;
        ChoosenItem = choosenSlotNumber == -1 ? string.Empty : Items[choosenSlotNumber];
        InventoryPanel.ChooseSlot(slotNumber);        
    }
}
