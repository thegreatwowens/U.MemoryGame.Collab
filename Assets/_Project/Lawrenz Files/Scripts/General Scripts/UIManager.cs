
using UnityEngine;
using ddr.MemoryGame;
using System;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverPanel;
    
    public LeanTweenType inType;
    public LeanTweenType outType;
     public void InstantiateObjectGameOverPanel(){
              Instantiate(gameOverPanel,GameObject.FindWithTag("Canvas").transform);
    }
}
