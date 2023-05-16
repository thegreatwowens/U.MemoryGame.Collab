using UnityEngine;
using ddr.MemoryGame;
using TMPro;
using System.Collections;

public class GameoverPanelScript : MonoBehaviour

{
  public TextMeshProUGUI RecordedBestFlip;
  public TextMeshProUGUI PlayerFlipCounts;
   
   void OnEnable()
   {
      PlayerFlipCounts.text = GameManager.main.gameController.flipCount.ToString();
      RecordedBestFlip.text = GameManager.main.playerData.LoadPlayerData().ToString();
   }

   public void PlayAgain(){
            GameManager.main.uIManager.HideGameOver();
            LeanTween.delayedCall(.8f,DelayPlayAgain);
   }
   public void ExitGame(){
           GameManager.main.uIManager.HideGameOver();
            LeanTween.delayedCall(.8f,DelayExitGame);
     // 
   }
    
    public void DelayPlayAgain(){
          GameManager.main.sceneChanger.FadeToNextScene(1);
    }
    public void DelayExitGame(){
          GameManager.main.sceneChanger.FadeToNextScene(0);
    }
}
