using UnityEngine;
using ddr.MemoryGame;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    [SerializeField]
    ItemGenerator generator;
    [Header("Items Parent")]
    public Transform ItemHolder;
    public List<GameObject> _items = new List<GameObject>();

    private bool _firstGuess, _secondGuess;
    private ItemData firstItemGuess, secondItemGuess;

    void Update()
    {
        
    }

    public void Generate()
    {
        generator.PopulateGrid(ItemHolder, _items);
        LeanTween.delayedCall(1f, RemoveParent);
    }
    public void RemoveParent()
    {
        GridLayoutGroup layout = ItemHolder.GetComponent<GridLayoutGroup>();
        Destroy(layout);
    }
    public void FlipItem(){
        for(int i =0; i<ItemHolder.childCount;i++){
            ItemData data = ItemHolder.transform.GetChild(i).GetComponent<ItemData>();
            data.CallFlip();
        }

    }

    public void TryMatch(GameObject listener)
    {

        if (!_firstGuess)
        {
            firstItemGuess = listener.gameObject.GetComponent<ItemData>();
            _firstGuess = true;
            if (listener != null)
            {
                print("This is First Guess: " + firstItemGuess.item.name);
                firstItemGuess.Interacted();
            }

        }
        else if (!_secondGuess)
        {
            secondItemGuess = listener.gameObject.GetComponent<ItemData>();
            _secondGuess = true;
            if (listener != null)
            {
                print("This is Second Guess: " + secondItemGuess.item.name);
                secondItemGuess.Interacted();
                LeanTween.delayedCall(.2f, Flipped);

            }

        }

    }
    public void ResetGuesses()
    {
        _firstGuess = false; 
        _secondGuess = false;
    }

    private void Flipped()
    {
        LeanTween.delayedCall(.3f, MatchResult);
    }
    private void MatchResult()
    {
        if (firstItemGuess.item == secondItemGuess.item)
        {
            Matched();
            // sounds
        }
        else
        {
            NotMatched();
            //sounds
        }

    }
  
    private void NotMatched()
    {
        firstItemGuess.NotMatched();
        secondItemGuess.NotMatched();
        ResetGuesses();
    }
    private void Matched()
    {
        LeanTween.scale(firstItemGuess.gameObject,new Vector3(1.5f,1.5f,1.5f),.5f).setDelay(.2f).setEase(LeanTweenType.easeInOutCubic);
         LeanTween.scale(secondItemGuess.gameObject,new Vector3(1.5f,1.5f,1.5f),.5f).setDelay(.2f).setEase(LeanTweenType.easeInOutCubic).setOnComplete(FinalMatchedAnimation);  
    }
    
    private void FinalMatchedAnimation(){
        LeanTween.rotate(firstItemGuess.gameObject,new Vector3(0,0,360),.7f);
        LeanTween.rotate(secondItemGuess.gameObject,new Vector3(0,0,-360),.7f);
        LeanTween.scale(firstItemGuess.gameObject,new Vector3(0,0,0),1f).setDelay(.2f).setEase(LeanTweenType.easeInOutCubic);
         LeanTween.scale(secondItemGuess.gameObject,new Vector3(0,0,0),1f).setDelay(.2f).setEase(LeanTweenType.easeInOutCubic).setOnComplete
         (AfterMatched);



    }
    
    private void AfterMatched(){
        
        _items.Remove(_items.Find(firstItemGuess.gameObject.name.Equals));
        Destroy(firstItemGuess.gameObject);
        Destroy(secondItemGuess.gameObject);
        ResetGuesses();
    }
}
