using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputController : MonoBehaviour {

    public GameManager gameManager;
    public InputField inputField;

    public LogManager logManager;

    public ScoreTextGenerater scoreTextGenerater1;
    public ScoreTextGenerater scoreTextGenerater2;

    public ResultController resultController;
    public GameObject buttonObj;

    public void OnClick()
    {
        if (inputField.text != "")
        {
            gameManager.SetPlayerName(inputField.text);
            logManager.AddLog();
            scoreTextGenerater1.UpdateText();
            scoreTextGenerater2.UpdateText();

            resultController.HideMenus();
            resultController.DisplayResultMenu();
            resultController.SetInteractive(buttonObj, false);
        }
    }
}
