using UnityEngine;
using UnityEngine.UI;
namespace ddr.MemoryGame.Item
{
    [CreateAssetMenu(fileName= "New Item",menuName = "Memory Game/Item")]
    public class Item : ScriptableObject
{
    public string itemName;
    public Sprite image;


    private void OnValidate() {
        itemName = this.name;
    }
}
}


