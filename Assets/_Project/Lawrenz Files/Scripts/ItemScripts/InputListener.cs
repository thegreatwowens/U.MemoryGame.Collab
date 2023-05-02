
using UnityEngine;
using ddr.MemoryGame;

public class InputListener : MonoBehaviour
{
  [SerializeField]
  ItemData item;
  void Awake()
  {
  }
  public void ThrowRequest(){
        string name = gameObject.name;
        GameController.Instance.TryMatch(this.gameObject);

  }

  public void Destroythis(){
        Destroy(this);
  }
}
