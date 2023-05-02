using UnityEngine;

public class MainMenuManager : MonoBehaviour
{

    public void StartGame(){
            SceneChanger.instance.FadeToNextScene(1);
    }

}
