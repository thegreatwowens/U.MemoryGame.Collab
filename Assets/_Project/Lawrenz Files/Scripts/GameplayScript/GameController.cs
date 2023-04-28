using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    AnimationController animationController;
    public static GameController Instance;
    [SerializeField]
    GameObject itemPrefab;
    [Space]
    [SerializeField]
    List<GameObject> itemDataList = new List<GameObject>();
    [Space]
    [SerializeField]
    List<GameObject> GridItems = new List<GameObject>();


    List<int> randomInts = new List<int>();
    public GameObject gridItemsPanel;
    public GridLayoutGroup layout;

    private static bool _firstGuess, _secondGuess;

    private string _firstGuessHolder, _secondGuessHolder;

    GameObject firstGuess = null;
    GameObject secondGuess = null;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        

    }
    void Start()
    {
        //PopulateGrid();
        layout = gridItemsPanel.GetComponent<GridLayoutGroup>();


    }
    public void deletelayOut()
    {
        //Destroy(layout);
        PopulateGrid();
    }
    private void PopulateGrid()
    {

        for (int i = 0; i < itemDataList.Count; i++)
        {
            randomInts.Add(i);
        }

        randomInts.Shuffle();

        for (int i = 0; i < itemDataList.Count; i++)
        {

            GridItems.Add(itemDataList[randomInts[i]]);


        }
        foreach (GameObject item in GridItems)
        {

            Instantiate(item, gridItemsPanel.transform);
        }
    }

    public void TryGuess(string value, GameObject gameObject)
    {
 
        ItemData item = gameObject.GetComponent<ItemData>();
        if (!_firstGuess)
        {
            firstGuess = gameObject;
            _firstGuess = true;
            _firstGuessHolder = value;
            Debug.Log(value);

        }
        else if (!_secondGuess)
        {
            secondGuess = gameObject;
            _secondGuess = true;
            _secondGuessHolder = value;
            Debug.Log(value);
            if (_firstGuessHolder == _secondGuessHolder)
            {
                print(_firstGuessHolder + " == " + _secondGuessHolder);
                _firstGuess = false;
                _secondGuess = false;
                Correct();
            }
            
        }



    }

    public void Wrong(){
        ItemData item1 = firstGuess.GetComponent<ItemData>();
        ItemData item2 = secondGuess.GetComponent<ItemData>();
            item1.EnableClosed();
            item2.EnableClosed();

    }
    public void Correct()
    {
        Destroy(firstGuess);
        Destroy(secondGuess);
            if(_firstGuessHolder != _secondGuessHolder){
                        
            }

    }
    public void Animate()
    {
        Destroy(layout);
    }




}
