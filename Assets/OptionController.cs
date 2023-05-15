using UnityEngine;
using UnityEngine.UI;
using ddr.MemoryGame;
public class OptionController : MonoBehaviour
{
    public Slider master,music, soundFX;
    public bool ingame;


void OnEnable()
{
    if(ingame)
    UpdateValues();
}
    public void UpdateValues(){
       master.value =  PlayerPrefs.GetFloat("Master");
        music.value = PlayerPrefs.GetFloat("BGMusic");
        soundFX.value =PlayerPrefs.GetFloat("SoundFx");
        
    }
    public void Mastervolume(){
                GameManager.main.soundManager.VolumeSliderMaster(master.value);
    }
    public void MusicVolume(){
                 GameManager.main.soundManager.VolumeSliderMusic(music.value);
    }
    public void SoundFXVolume(){
                 GameManager.main.soundManager.VolumeSliderSoundFx(soundFX.value);
    }
    public void OnExit(){
         GameManager.main.soundManager.PlaySoundFx("UIClicks");
    }

    public void ResetGame(){
          Button btn = GameObject.FindWithTag("Option").GetComponent<Button>();
            btn.interactable =false;
             LeanTween.delayedCall(1.2f,delayReset);
             GameManager.main.uIManager.HideOption();
              GameManager.main.soundManager.PlaySoundFx("UIClicks");
    }
    public void ExitToMainMenu(){
            Button btn = GameObject.FindWithTag("Option").GetComponent<Button>();
            btn.interactable =false;
            LeanTween.delayedCall(1.2f,delayQuit);
            GameManager.main.uIManager.HideOption();
             GameManager.main.soundManager.PlaySoundFx("UIClicks");
    }
    public void delayQuit(){
          GameManager.main.sceneChanger.FadeToNextScene(0);
    }
    public void delayReset(){
        GameManager.main.sceneChanger.FadeToNextScene(1);
        
    }
}
