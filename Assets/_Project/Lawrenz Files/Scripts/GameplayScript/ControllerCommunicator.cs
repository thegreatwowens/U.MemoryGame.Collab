
using UnityEngine;
using ddr.MemoryGame;

public class ControllerCommunicator : MonoBehaviour
{
    public void ClickedPopulate(){
        GameManager.main.gameController.Generate();
    }
    public void ClickedFlipped(){
            GameManager.main.gameController.FlipItem();
    }
}
