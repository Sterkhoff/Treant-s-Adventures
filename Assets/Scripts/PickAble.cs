using UnityEngine;

public class PickAble : MonoBehaviour, IInteractive
{
    private Inventory inventory;
    public Item Item;

    private void Start()
    {
        inventory = GameObject.Find("UIInventory").GetComponent<Inventory>();
    }
    public void Interact()
    {
        inventory.AddToInventory(Item);            
        Destroy(gameObject);
    }
}
