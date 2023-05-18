using UnityEngine;
using UnityEngine.SceneManagement;
using ddr.MemoryGame;

public class SceneChanger : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public GameObject  image;

    [Header("The Higher the Range the longer for scene to fade ")]
    [Range(0,3)]
    public float fadeInDuration;
    [Range(0,3)]
    public float fadeOutDuration;

    private int indexScene;

    public Scene currentScene;
    void Awake()
    {
            SceneManager.sceneLoaded += OnSceneLoaded;
    }
           
    void Start()
    {
    }
        private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1){
            currentScene = SceneManager.GetActiveScene();
                   
                
                    if(currentScene.buildIndex == 1){

                        GameManager.main.soundManager.PlayMusic("GameBGMusic",true);
                        GameManager.main.gameController.ItemHolder = GameObject.FindWithTag("ItemsParent").transform;
                        GameManager.main.gameController.canvasItems
                         = GameManager.main.gameController.ItemHolder.GetComponent<CanvasGroup>(); 
                   }
                    if(currentScene.buildIndex ==0){

                    //   GameManager.main.soundManager.StopMusic();
                    }
                    
                    FadeFromPreviousScene();
        }
    
    public void FadeToNextScene(int Index){

                indexScene = Index;
            LeanTween.alphaCanvas(canvasGroup,1,fadeOutDuration).setOnComplete(OnFadeComplete);

    }

    void OnFadeComplete(){  
            SceneManager.LoadScene(indexScene);
    }

    public void FadeFromPreviousScene(){

        if(canvasGroup != null)
        LeanTween.alphaCanvas(canvasGroup,0,fadeInDuration);

    }
}
