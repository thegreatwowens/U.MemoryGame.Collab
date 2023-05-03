using UnityEngine;
using ddr.MemoryGame;
using TMPro;
using System.Collections;

public class GameoverPanelScript : MonoBehaviour

{
    [SerializeField]
    TextMeshProUGUI flipCount;

    private void OnEnable() {
            
            flipCount.text = "Flip Count: "+ GameManager.main.playerData.LoadPlayerData();
            ShowGameOverPanel();
    }
    public void PlayAgain()
    {
             GameManager.main.sceneChanger.FadeToNextScene(1);
    }
    public void ExitGame()
    { 
        GameManager.main.sceneChanger.FadeToNextScene(0);
    }
     public void ShowGameOverPanel(){
          LeanTween.scale(this.gameObject,new Vector3(1,1,1),1f).setDelay(.1f).setEase(GameManager.main.uIManager.inType);
    }
       public void HideGameOverPanel(){
        StartCoroutine(HidePanel(this.gameObject));
    }
    
    IEnumerator HidePanel(GameObject obj){
          LeanTween.scale(obj,new Vector3(0,0,0),1f).setDelay(.1f).setEase(GameManager.main.uIManager.outType);
        yield return new WaitForSeconds(1.1f);
        DeleteObject(obj);
    }
    public void DeleteObject(GameObject obj){

                Destroy(obj);

    }
    public void InstantiateObject(GameObject obj){
              Instantiate(obj,GameObject.FindWithTag("Canvas").transform);
    }
}
