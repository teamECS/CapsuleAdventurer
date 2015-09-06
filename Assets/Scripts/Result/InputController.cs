using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputController : MonoBehaviour {

    public GameManager gameManager;
    public InputField inputField;
	
    public void SaveName()
    {
        gameManager.SetPlayerName(inputField.text);
    }

    public void RecordPlayData()
    {
        gameManager.GetRemainingTime();
    }
}
