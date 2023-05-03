using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ddr.MemoryGame {
public class GameManager : MonoBehaviour
{
    public static GameManager main;
    
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
        main = this; 
        DontDestroyOnLoad(this.gameObject);
    } 
    }

}


}

