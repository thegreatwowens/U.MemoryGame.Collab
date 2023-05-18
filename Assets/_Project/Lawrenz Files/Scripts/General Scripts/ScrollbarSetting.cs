using UnityEngine;
using UnityEngine.UI;


public class ScrollbarSetting : MonoBehaviour
{
        Scrollbar bar;

   void Awake()
   {
    bar = GetComponent<Scrollbar>();

   }
 void OnEnable()
 {
    bar.value = 1;
 }
}
