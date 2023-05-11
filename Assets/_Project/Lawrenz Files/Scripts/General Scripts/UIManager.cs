
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
    GameObject optionPanel;
    public Camera canvasCamera;
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
            optionPanel.SetActive(false);
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
            optionPanel.SetActive(true);
            LeanTween.scale(optionPanel,new Vector3(1,1,1),3f).setDelay(.2f).setEase(inType);
            LeanTween.alphaCanvas(backFade,1,.2f);
            backFade.blocksRaycasts = true;
    }
    public void HideOption(){
            LeanTween.alphaCanvas(backFade,0,.2f).setDelay(.2f);
            LeanTween.scale(gameOverPanel,new Vector3(0,0,0),3f).setEase(outType).setOnComplete(optionDisabled);
            backFade.blocksRaycasts = false;
    }

}
