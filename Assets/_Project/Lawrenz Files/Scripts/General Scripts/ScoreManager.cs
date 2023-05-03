using UnityEngine;
using ddr.MemoryGame;

public class ScoreManager : MonoBehaviour
{
   public int  _flipCount {get; set;}
   
   public void SetNewFlipRecord(int newRecord){
            _flipCount = newRecord ;
            GameManager.main.playerData.SavedPlayerData(_flipCount);
   }
}
