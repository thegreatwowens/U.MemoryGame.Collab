using UnityEngine;
using UnityEngine.UI;
using ddr.MemoryGame;
public class OptionMainMenuController : MonoBehaviour
{
    public Slider master,music, soundFX;


    public void Mastervolume(){
                GameManager.main.soundManager.VolumeSliderMaster(master.value);
    }
    public void MusicVolume(){
                 GameManager.main.soundManager.VolumeSliderMusic(music.value);
    }
    public void SoundFXVolume(){
                 GameManager.main.soundManager.VolumeSliderSoundFx(soundFX.value);
    }
}
