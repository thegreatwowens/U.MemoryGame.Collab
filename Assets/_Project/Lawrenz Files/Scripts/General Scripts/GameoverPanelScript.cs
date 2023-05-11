using UnityEngine;
using ddr.MemoryGame;
using TMPro;
using System.Collections;

public class GameoverPanelScript : MonoBehaviour

{
   TextMeshProUGUI bestFlipUI;
   
   void OnEnable()
   {
      bestFlipUI = this.gameObject.transform.Find("No.FlippedText").GetComponent<TextMeshProUGUI>();
    bestFlipUI.text =GameManager.main.playerData.LoadPlayerData().ToString();
   }


    
}
