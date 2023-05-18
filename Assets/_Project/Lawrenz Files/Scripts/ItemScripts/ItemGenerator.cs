using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ddr.MemoryGame.Item;

namespace ddr.MemoryGame{
public class ItemGenerator : MonoBehaviour
{ 

    [SerializeField]
    GameObject itemPrefab;
    [Space]
    [SerializeField]
    List<GameObject> itemDataList = new List<GameObject>();
    List<int> randomInts = new List<int>();
    public void PopulateGrid(Transform parent, List<GameObject> GridList)
    {

        for (int i = 0; i < itemDataList.Count; i++)
        {
            randomInts.Add(i);
        }

        randomInts.Shuffle();

        for (int i = 0; i < itemDataList.Count; i++)
        {

            GridList.Add(itemDataList[randomInts[i]]);


        }
        foreach (GameObject item in GridList)
        {

            Instantiate(item, parent);
        }
    }
        public void OnNewGame(){
                randomInts.Clear();
        }
}

}

