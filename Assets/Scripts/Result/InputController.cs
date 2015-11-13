using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputController : MonoBehaviour {

    public GameManager gameManager;
    public InputField inputField;
	
    public void SetPlayerName()
    {
        if (inputField.text != "")
        {
            gameManager.SetPlayerName(inputField.text);
        }
    }
}
