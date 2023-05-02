using System;
using UnityEngine;
using UnityEngine.UI;

namespace ddr.MemoryGame
{
    public class AnimationController : MonoBehaviour
    {
        public static AnimationController Instance;
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
        public void OnItemDespawn(GameObject obj, LeanTweenType intype)
        {
            LeanTween.scale(obj, new Vector3(1, 1, 1), 1f).setEase(intype);
        }
        public void ItemClicked(Image img, Color startingColor, Color endingColor, float speed)
        {

            img.color = Color.Lerp(startingColor, endingColor, Mathf.PingPong(Time.time * speed, 1));

        }

    }

}
