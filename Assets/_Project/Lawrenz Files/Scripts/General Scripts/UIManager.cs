
using UnityEngine;
using ddr.MemoryGame;
using System;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    CanvasGroup backFade;
    [SerializeField]
    GameObject gameOverPanel;
    [SerializeField]
    GameObject optionPanelGame;
    [SerializeField]
    GameObject mainMenuOptionPanel;

    public Canvas canvas;
    void Awake()
    {
        backFade.alpha = 0;
        backFade.interactable = false;
        backFade.blocksRaycasts = false;

    }
    
    public LeanTweenType inType;
    public LeanTweenType outType;

#region DisablePanelOnCompleteHover

            private void optionDisabled(){
            optionPanelGame.SetActive(false);
    }
        private void GameOverDisabled()
    {  gameOverPanel.SetActive(false); }
#endregion
 
    public void ShowGameOver(){
            gameOverPanel.SetActive(true);
            LeanTween.scale(gameOverPanel,new Vector3(1,1,1),3f).setDelay(.2f).setEase(inType);
            LeanTween.alphaCanvas(backFade,1,.2f);
            backFade.blocksRaycasts = true;
    }
    public void HideGameOver(){
            LeanTween.alphaCanvas(backFade,0,.2f).setDelay(.2f);
            LeanTween.scale(gameOverPanel,new Vector3(0,0,0),3f).setEase(outType).setOnComplete(GameOverDisabled);
            backFade.blocksRaycasts = false;
    }

    public void ShowOption(){
            optionPanelGame.SetActive(true);
            LeanTween.scale(optionPanelGame,new Vector3(1,1,1),3f).setDelay(.2f).setEase(inType);
            LeanTween.alphaCanvas(backFade,1,.2f);
            backFade.blocksRaycasts = true;
    }
    public void HideOption(){
            LeanTween.alphaCanvas(backFade,0,.2f).setDelay(.2f);
            LeanTween.scale(gameOverPanel,new Vector3(0,0,0),3f).setEase(outType).setOnComplete(optionDisabled);
            backFade.blocksRaycasts = false;
    }
    
    public void ShowMainMenuOption(bool value){
            CanvasGroup canvas = mainMenuOptionPanel.GetComponent<CanvasGroup>();
            mainMenuOptionPanel.SetActive(value);
                canvas.interactable = value;
                canvas.blocksRaycasts = value;
    }

}
