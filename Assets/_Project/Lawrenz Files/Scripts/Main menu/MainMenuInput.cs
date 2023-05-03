using UnityEngine;
using ddr.MemoryGame;
public class MainMenuInput : MonoBehaviour
{

    public void StartGame(){
            GameManager.main.sceneChanger.FadeToNextScene(1);
    }

}
