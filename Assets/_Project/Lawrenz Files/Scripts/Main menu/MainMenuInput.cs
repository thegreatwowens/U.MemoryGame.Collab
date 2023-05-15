using UnityEngine;
using ddr.MemoryGame;
public class MainMenuInput : MonoBehaviour
{
    
    public void StartListener(){
            GameManager.main.soundManager.PlaySoundFx("UIClicks");
            GameManager.main.sceneChanger.FadeToNextScene(1);
    }
    public void OptionListener(){
            GameManager.main.soundManager.PlaySoundFx("UIClicks");
            GameManager.main.uIManager.ShowMainMenuOption(true);
            

    }
    public void OptionCloseListener(){
        GameManager.main.soundManager.PlaySoundFx("UIClicks");
        GameManager.main.uIManager.ShowMainMenuOption(false);
    }
    public void ExitListener(){
        GameManager.main.soundManager.PlaySoundFx("UIClicks");
        Application.Quit();

    }
}
