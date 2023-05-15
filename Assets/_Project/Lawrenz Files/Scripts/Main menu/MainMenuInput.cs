using UnityEngine;
using ddr.MemoryGame;
public class MainMenuInput : MonoBehaviour
{
    
    public void StartListener(){
            GameManager.main.sceneChanger.FadeToNextScene(1);
    }
    public void OptionListener(){
            GameManager.main.uIManager.ShowMainMenuOption(true);

    }
    public void OptionCloseListener(){
        GameManager.main.uIManager.ShowMainMenuOption(false);
    }
    public void ExitListener(){
        Application.Quit();

    }
}
