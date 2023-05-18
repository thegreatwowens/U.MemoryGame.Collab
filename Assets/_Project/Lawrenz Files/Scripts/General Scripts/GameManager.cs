using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ddr.MemoryGame {

    public enum GameState{

        MainMenu,
        Instruction,
        Generate,
        GameOver


    }
public class GameManager : MonoBehaviour
{
    public static GameManager main;
    public GameState state;
    public static event Action<GameState> OnGameStateChanged;
    public SceneChanger sceneChanger { get; private set;}
    public SoundManager soundManager { get; private set;}
    public GameController gameController { get;  set;}
    public AnimationController animationController {get; private set;}
    public ScoreManager scoreManager {get; set;}
    public PlayerData playerData {get; set;}
    public UIManager uIManager {get; private set;}
    
        void OnValidate()
    {
        if( sceneChanger == null && soundManager == null && gameController == 
        null && animationController == null && scoreManager == null && playerData == null && uIManager == null ){
        
        print ("Missing Dependencies. Adding.... Completed");
        }else{
            print("Dependencies are Completed");
        }
       
    }
    void Awake()
    {
        sceneChanger = GetComponentInChildren<SceneChanger>();
        soundManager = GetComponentInChildren<SoundManager>();
        gameController = GetComponentInChildren<GameController>();
        animationController =GetComponentInChildren<AnimationController>();
        playerData = GetComponentInChildren<PlayerData>();
        scoreManager = GetComponentInChildren<ScoreManager>();
        uIManager = GetComponentInChildren<UIManager>();
      
        if (main != null && main != this) 
    { 

        Destroy(this.gameObject); 
      
    } 
    else 
    { 
              Application.targetFrameRate =120;
        main = this; 
        DontDestroyOnLoad(this.gameObject);
    }
 

    }

    void OnApplicationFocus(bool hasFocus)
    {
        if(!hasFocus){
            uIManager.ShowOption();
        }
    }
    public void UpdateGameState(GameState newState){
            switch(newState){
                case GameState.MainMenu:
                            HandleMainMenuState();
                    break;
                case GameState.Instruction:
                            HandleInstructionState();
                        break;

                case GameState.Generate:
                            HandleGameStartState();

                    break;
                case GameState.GameOver:
                            HandleGameOverState();
                    break;
            }
                OnGameStateChanged?.Invoke(newState);

    }

        private void HandleInstructionState()
        {
            throw new NotImplementedException();
        }

        private void HandleGameOverState()
        {   
                if(GameManager.main.gameController.flipCount<= GameManager.main.playerData.LoadPlayerData()){
                    GameManager.main.scoreManager.SetNewFlipRecord(GameManager.main.gameController.flipCount);
                    PlayerPrefs.Save();
                }
                else if(GameManager.main.playerData.LoadPlayerData() <= 0){
                            
                             GameManager.main.scoreManager.SetNewFlipRecord(GameManager.main.gameController.flipCount);
                            PlayerPrefs.Save();
                }else {
                    PlayerPrefs.Save();
                }
                uIManager.ShowGameOver();
        }

        private void HandleGameStartState()
        {
            sceneChanger.FadeToNextScene(1);
        }

        private void HandleMainMenuState()
        {
            throw new NotImplementedException();
        }
    }


}

