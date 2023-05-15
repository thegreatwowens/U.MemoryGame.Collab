
using UnityEngine;
using ddr.MemoryGame;
using TMPro;
using UnityEngine.UI;

public class ControllerCommunicator : MonoBehaviour
{
        [SerializeField]
      GameObject instruction;
    public void ClickedPopulate()
    {
        GameManager.main.gameController.Generate();
    }
    public void ClickedFlipped()
    {
        GameManager.main.gameController.FlipItem();
    }

    public void OpenOptionPanel()
    {
        GameManager.main.uIManager.ShowOption();
         GameManager.main.soundManager.PlaySoundFx("UIClicks");

    }
    public void CloseOptionPanel()
    {
        GameManager.main.uIManager.HideOption();
         GameManager.main.soundManager.PlaySoundFx("UIClicks");
    }
    public void ShowInstruction(){
        GameManager.main.uIManager.ShowInstruction();
    }

    void Start()
    {   ShowInstruction();
        
    }
 


}
