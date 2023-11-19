using UnityEngine;

public class PickAble : IInteractive
{
    private Inventory inventory;
    public Item Item;

    private void Start()
    {
        inventory = GameObject.Find("UIInventory").GetComponent<Inventory>();
    }
    public override void Interact()
    {
        inventory.AddToInventory(Item);            
        Destroy(gameObject);
    }
}
