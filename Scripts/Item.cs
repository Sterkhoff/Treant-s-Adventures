using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item")]
public class Item : ScriptableObject
{
    public string Name;
    public GameObject ItemToDraw;
}
