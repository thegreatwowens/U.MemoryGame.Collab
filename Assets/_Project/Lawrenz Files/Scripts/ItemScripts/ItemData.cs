using UnityEngine;
using UnityEngine.UI;
using ddr.MemoryGame.Item;
public class ItemData : MonoBehaviour
{
  public LeanTweenType inType;
  public LeanTweenType outType;
  public  Item item;
  [SerializeField]
  Image image;
  [SerializeField]
  GameObject Blocker;

void Awake()
{
    LeanTween.scale(this.gameObject,new Vector3(0,0,0),0.01f);
}
    void Start()
    {
        image.sprite = item.image;
    }
    void OnValidate()
    {
      gameObject.name = item.name;
      image.sprite = item.image;
    }
    void OnEnable()
    {
      LeanTween.scale(this.gameObject, new Vector3(1,1,1),1f).setEase(inType).setDelay(1f);
      LeanTween.delayedCall(5,EnableClosed);
    }
    public void EnableClosed(){
        Blocker.SetActive(true);
    }
    public void Interacted(){
        Blocker.SetActive(false);
    }
}
