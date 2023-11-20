using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Image[] Slots;

    public void AddToInventory(Item itemForAdd, int slotNumber)
    {
        Instantiate(itemForAdd.ImageInInventory, Slots[slotNumber].transform, false);
    }

    public void DeleteFromInventory(int slotNumber)
    {
        Destroy(Slots[slotNumber].transform.GetChild(0).gameObject);
    }

    public void ChooseSlot(int slotNumber)
    {
        Slots[slotNumber].color = Slots[slotNumber].color == Color.gray ? Color.white : Color.gray;
        for (var i = 0; i < Slots.Length; i++)
        {
            if (i != slotNumber)
                Slots[i].color = Color.white;
        }
    }
}