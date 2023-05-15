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
        sceneChanger = GetComponentInChildren<SceneChanger>();
        soundManager = GetComponentInChildren<SoundManager>();
        gameController = GetComponentInChildren<GameController>();
        animationController =GetComponentInChildren<AnimationController>();
        playerData = GetComponentInChildren<PlayerData>();
        scoreManager = GetComponentInChildren<ScoreManager>();
        uIManager = GetComponentInChildren<UIManager>();
        print ("Missing Dependencies. Adding.... Completed");
        }else{
            print("Dependencies are Completed");
        }
       
    }
    void Awake()
    {
      
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
                  uIManager.ShowGameOver();
                  gameController._items.Clear();
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

