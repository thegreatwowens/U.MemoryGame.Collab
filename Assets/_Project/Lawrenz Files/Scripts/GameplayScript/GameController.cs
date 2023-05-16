using UnityEngine;
using ddr.MemoryGame;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour
{

    [SerializeField]
    ItemGenerator generator;
    [Header("Items Parent")]
    [HideInInspector]
    public Transform ItemHolder;
    public CanvasGroup canvasItems;
    [HideInInspector]
    public List<GameObject> _items = new List<GameObject>();

    private bool _firstGuess, _secondGuess;

    [HideInInspector]
    public ItemData firstItemGuess, secondItemGuess;

    public  int flipCount;
    private int itemCounts;
    void Awake()
    {
        
    }
    public void Generate()
    {
        canvasItems.interactable = false;
        generator.PopulateGrid(ItemHolder, _items);
        LeanTween.delayedCall(1f, RemoveParent);
        LeanTween.delayedCall(3f,FlipItem);
    }
    public void RemoveParent()
    {
        GridLayoutGroup layout = ItemHolder.GetComponent<GridLayoutGroup>();
        Destroy(layout);
    }
    public void FlipItem(){
            canvasItems.interactable = true;
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
            GameManager.main.animationController.MatchedAnimation();
        }
        else
        {
            flipCount++;
            NotMatched();
            //sounds
        }

    }
    
    private void CheckCompletedGame(){
        if(ItemHolder.childCount == 0){
             GameManager.main.UpdateGameState(GameState.GameOver);
        }
        return;
    }
    private void NotMatched()
    {
        firstItemGuess.NotMatched();
        secondItemGuess.NotMatched();
        ResetGuesses();
    }
    public void AfterMatched(){
        Destroy(firstItemGuess.gameObject);
        Destroy(secondItemGuess.gameObject);
        LeanTween.delayedCall(.5f,CheckCompletedGame);
        ResetGuesses();
    }
  
}
