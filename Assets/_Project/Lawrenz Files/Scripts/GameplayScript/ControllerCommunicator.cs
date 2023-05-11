
using UnityEngine;
using ddr.MemoryGame;
using TMPro;
using UnityEngine.UI;

public class ControllerCommunicator : MonoBehaviour
{   
    [SerializeField]
    private Slider master,music,soundFX;
    
    public void ClickedPopulate(){
        GameManager.main.gameController.Generate();
    }
    public void ClickedFlipped(){
            GameManager.main.gameController.FlipItem();
    }

    public void OpenOptionPanel(){
            GameManager.main.uIManager.ShowOption();
    }
    public void CloseOptionPanel(){
            GameManager.main.uIManager.HideOption();
    }
    
    public void MasterVolume(){
        GameManager.main.soundManager.VolumeSliderMaster(master.value);
    }
    public void MusicVolume(){
            GameManager.main.soundManager.VolumeSliderMusic(music.value);
    }
    public void SoundFxVolume(){
         GameManager.main.soundManager.VolumeSliderSoundFx(soundFX.value);

    }
    

}
