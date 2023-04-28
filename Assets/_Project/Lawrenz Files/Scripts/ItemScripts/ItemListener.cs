
using UnityEngine;


public class ItemListener : MonoBehaviour
{
  ItemData item;
  void Awake()
  {
    item = gameObject.transform.GetComponentInParent<ItemData>();
  }
  public void ThrowRequest(){

            string name = gameObject.name;
        GameController.Instance.TryGuess(name,this.gameObject);
        item.Interacted();
  }

  public void Destroythis(){
        Destroy(this);
  }
}
