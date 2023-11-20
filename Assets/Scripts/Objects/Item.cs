using UnityEngine;
using UnityEngine.UI;

public class Item : IInteractive
{
    public string Name;
    public Image ImageInInventory;
    private Inventory inventory;

    private void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
    }
    public override void Interact()
    {
        inventory.AddToInventory(gameObject.GetComponent<Item>());            
        Destroy(gameObject);
    }
}
