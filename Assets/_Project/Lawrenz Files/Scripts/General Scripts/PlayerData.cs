using UnityEngine;
using ddr.MemoryGame;

public class PlayerData : MonoBehaviour
{
    public int BestFlipCount {get; set;}
    void Awake()
    {
        if(PlayerPrefs.HasKey("BestFlipCount")){
                BestFlipCount = LoadPlayerData();
        }
        else{
            BestFlipCount = 0;
        }
        
    }
    
    public void SavedPlayerData(int newRecord){
        PlayerPrefs.SetInt("BestFlipCount",newRecord);
        PlayerPrefs.Save();
    }
    
    public int LoadPlayerData(){
        
        return BestFlipCount = PlayerPrefs.GetInt("BestFlipCount");
    }
    public void ResetPlayerData(){
       PlayerPrefs.DeleteKey("BestFlipCount"); 
    }
    
    
}
