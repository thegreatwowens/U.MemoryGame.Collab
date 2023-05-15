using System;
using UnityEngine;
using UnityEngine.UI;

namespace ddr.MemoryGame
{
    public class AnimationController : MonoBehaviour
    {
     
        public void OnItemDespawn(GameObject obj, LeanTweenType intype)
        {
            LeanTween.scale(obj, new Vector3(1, 1, 1), 1f).setEase(intype);
        }
        public void ItemClicked(Image img, Color startingColor, Color endingColor, float speed)
        {

            img.color = Color.Lerp(startingColor, endingColor, Mathf.PingPong(Time.time * speed, 1));

        }
        public void MatchedAnimation(){
            LeanTween.scale(GameManager.main.gameController.firstItemGuess.gameObject,new Vector3(1.5f,1.5f,1.5f),.5f).setDelay(.2f).setEase(LeanTweenType.easeInOutCubic);
         LeanTween.scale(GameManager.main.gameController.secondItemGuess.gameObject,new Vector3(1.5f,1.5f,1.5f),.5f).setDelay(.2f).setEase(LeanTweenType.easeInOutCubic).setOnComplete(FinalMatchedAnimation);

        }

        private void FinalMatchedAnimation()
        {
            LeanTween.rotate(GameManager.main.gameController.firstItemGuess.gameObject,new Vector3(0,0,360),.7f);
        LeanTween.rotate(GameManager.main.gameController.secondItemGuess.gameObject,new Vector3(0,0,-360),.7f);
        LeanTween.scale(GameManager.main.gameController.firstItemGuess.gameObject,new Vector3(0,0,0),1f).setDelay(.2f).setEase(LeanTweenType.easeInOutCubic);
         LeanTween.scale(GameManager.main.gameController.secondItemGuess.gameObject,new Vector3(0,0,0),1f).setDelay(.2f).setEase(LeanTweenType.easeInOutCubic).setOnComplete
         (GameManager.main.gameController.AfterMatched);

        }

        /// MAiN MENU Animation
        



    }

}
