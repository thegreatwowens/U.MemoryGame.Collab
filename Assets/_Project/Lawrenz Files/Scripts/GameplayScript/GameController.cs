using UnityEngine;
using ddr.MemoryGame;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    void Awake()
    {
        if(Instance == null){
            Instance = this;
        }
    }
    [SerializeField]
    ItemGenerator generator;
    [Header("Items Parent")]
    public Transform ItemHolder;
    private List<GameObject> _items = new List<GameObject>();

    private bool _firstGuess,_secondGuess;
    private ItemData firstItemGuess,secondItemGuess;

    public void Generate(){
                    generator.PopulateGrid(ItemHolder,_items);
                    LeanTween.delayedCall(1f,RemoveParent);
    }
    public void RemoveParent(){
            GridLayoutGroup layout = ItemHolder.GetComponent<GridLayoutGroup>();
                Destroy(layout);
    }

    public void TryMatch(GameObject listener){
            
            if(!_firstGuess){
                firstItemGuess = listener.gameObject.GetComponent<ItemData>();
                    _firstGuess = true;
                    if(listener != null){
                         print("This is First Guess: "+ firstItemGuess.item.name);
                            firstItemGuess.Interacted();
                    }
                   

            
            }else if(!_secondGuess){
                secondItemGuess = listener.gameObject.GetComponent<ItemData>();
                _secondGuess = true;
                if(listener !=null){
                        print("This is Second Guess: "+ secondItemGuess.item.name);
                        secondItemGuess.Interacted();
                        ResetGuesses();
                        MatchResult();

                }
            
            }
            
    }
    public void ResetGuesses(){
            _firstGuess = false;_secondGuess = false;
    } 
    private void MatchResult(){
        if(firstItemGuess.item == secondItemGuess.item){
                Destroy(firstItemGuess.gameObject);
                Destroy(secondItemGuess.gameObject);
        }else{
            firstItemGuess.NotMatched();
            secondItemGuess.NotMatched();
        }

    }
    private void OnTryMatch(GameObject obj){
        // AnimationController.Instance.ItemMatchAnimation(obj,new Vector3(2f,2f,2f).);

    }
    void Update()
    {
        
    }
}
