using System;
using UnityEngine;
using UnityEngine.UI;

namespace ddr.MemoryGame {
public class AnimationController : MonoBehaviour
{
    public static AnimationController Instance;
    void Awake()
    {
        if (Instance == null){
            Instance = this;
        }
    }
    public void OnItemSpawn(GameObject obj, LeanTweenType intype)
    {
        LeanTween.scale(obj, new Vector3(1, 1, 1), 1f).setEase(intype);
    }

    public void OnItemSpawn(GameObject obj, LeanTweenType intype, float delay)
    {
        LeanTween.scale(obj, new Vector3(1, 1, 1), 1f).setEase(intype).setDelay(delay);
    }
    public void OnItemDespawn(GameObject obj, LeanTweenType intype)
    {
        LeanTween.scale(obj, new Vector3(1, 1, 1), 1f).setEase(intype);

    }
    public void OnItemDespawn(GameObject obj, LeanTweenType intype, float delay)
    {
        LeanTween.scale(obj, new Vector3(1, 1, 1), 1f).setEase(intype).setDelay(delay);

    }



    public void ItemMatchAnimation(GameObject obj, LeanTweenType intype){

    }
        public void ItemMatchAnimation(GameObject obj,Vector3 value,LeanTweenType intype,float delay){
            LeanTween.scale(obj,value, 1f).setEase(intype).setDelay(delay);
    }
      public void ItemMatchAnimation(GameObject obj,Vector3 value ,LeanTweenType intype){
            LeanTween.scale(obj,value, 1f).setEase(intype);
    }
          public void ItemMatchAnimation(GameObject obj,Vector3 value,float delay, LeanTweenType intype,Action OnComplete){
            LeanTween.scale(obj,value, 1f).setEase(intype).setDelay(delay).setOnComplete(OnComplete);
    }
           public void ItemMatchAnimation(GameObject obj,Vector3 value,float delay, LeanTweenType intype){
            LeanTween.scale(obj,value, 1f).setEase(intype).setDelay(delay);
    }

            public void ItemClicked(Image img,Color startingColor,Color endingColor, float speed){
                        
                       img.color = Color.Lerp(startingColor,endingColor, Mathf.PingPong(Time.time*speed,1));
                        
            }

        void Update()
        {
                      
        }

}

}
