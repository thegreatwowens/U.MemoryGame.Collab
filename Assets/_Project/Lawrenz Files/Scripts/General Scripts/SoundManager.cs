using UnityEngine;
using ddr.MemoryGame.SoundClip;
using System;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public SoundClip[] bGMusic,fXClip;
    public AudioSource bGSource,fXSource;
    public AudioMixer mixer;

      public void PlayMusic(string name,bool isLooping){
         SoundClip sound =     Array.Find(bGMusic,x => x.name == name);
            
            if(sound == null){
                
                print ("No sound Named: "+ name+" at "+ bGMusic.ToString());

            } 
            else{
                if(isLooping){
                        bGSource.loop = true;
                }else
                    bGSource.loop = false;   
            
                bGSource.clip = sound.clip;
                bGSource.Play();
            }

    }
    public void PlaySoundFx(string name){
        SoundClip sound =  Array.Find(fXClip,x => x.name == name);
            
            if(sound == null){
                
                print ("No sound Named: "+ name+" at "+ fXSource.ToString());

            } 
            else{

                fXSource.PlayOneShot(sound.clip);
            }
        
    }

    public void VolumeSliderMaster (float volume){
                bGSource.volume = volume;
                fXSource.volume = volume;
            
    }
    public void VolumeSliderSoundFx(float volume){
           
    }
    public void VolumeSliderMusic(float volume){

    }

}
