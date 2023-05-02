using UnityEngine;
using UnityEngine.UI;
using ddr.MemoryGame.Item;
using ddr.MemoryGame;
using System.Collections;

public class ItemData : MonoBehaviour
{

    [Header("Color Selected Effect")]
    public Color startingColor;
    public Color endingColor;
    public Color colorReset;
    public Image borderImage;
    public LeanTweenType inType;
    public Item item;
    [Space]
    [SerializeField]
    Image itemImage;
    Button btn;
    [Space]
    [Header("Fliping Effect Variables")]
        public GameObject BackImage;
        public  bool activeBack;
        float timer;
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
    public void Interacted()
    {
        interacted = true;
        CallFlip();
        gameObject.transform.SetSiblingIndex(GameController.Instance._items.Count);
    }
    public void NotMatched()
    {
        CallFlip();
        interacted = false;
        borderImage.color = colorReset;
         btn.interactable = true;
    }
    void Update()
    {
        if (interacted)
        {
            AnimationController.Instance.ItemClicked(borderImage, startingColor, endingColor, 1f);
            btn.interactable = false;
        }
    }
    public void ThrowRequest()
    {
        string name = gameObject.name;
        GameController.Instance.TryMatch(this.gameObject);

    }

    public void Flip(){
                if(activeBack){
                    BackImage.SetActive(false);
                    activeBack = false;
                }else{
                    BackImage.SetActive(true);
                    activeBack = true;
                }
    }

    IEnumerator StartFlipping(){

            for(int i = 0; i<180 ;i+=10){
                yield return new WaitForEndOfFrame();
                transform.rotation = Quaternion.Euler(0,i,0);
                
                timer++;
                    if(i== 90 || i == -90){
                        Flip();
                    }
            }

        timer =0;
    }
    public void CallFlip(){
            StartCoroutine(StartFlipping());
    }
}
