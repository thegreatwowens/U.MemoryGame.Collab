using UnityEngine;
using UnityEngine.UI;
using ddr.MemoryGame.Item;
using ddr.MemoryGame;
public class ItemData : MonoBehaviour
{

    [Header("Color Selected Effect")]
    public Color startingColor;
    public Color endingColor;
    public Color colorReset;
    public Image borderImage;
    public LeanTweenType inType;
    public Item item;
    [SerializeField]
    Image itemImage;
    [SerializeField]
    GameObject Blocker;
    Button btn;
    bool interacted;
    bool Matched;
    void Awake()
    {
        LeanTween.scale(this.gameObject, new Vector3(0, 0, 0), 0.01f);
    }
    void Start()
    {
        itemImage.sprite = item.image;
    }
    void OnValidate()
    {
        gameObject.name = item.name;
        itemImage.sprite = item.image;
    }
    void OnEnable()
    {
        AnimationController.Instance.OnItemDespawn(this.gameObject, inType);
        btn = GetComponent<Button>();
    }
    public void EnableClosed()
    {
        Blocker.SetActive(true);
    }
    public void Interacted()
    {
        interacted = true;
        Blocker.SetActive(false);

    }
    public void NotMatched()
    {
        interacted = false;
        borderImage.color = colorReset;
        btn.interactable =true;
    }
    void Update()
    {
        if (interacted)
        {
            AnimationController.Instance.ItemClicked(borderImage, startingColor, endingColor, 1f);
            btn.interactable = false;
        }
    }
}
