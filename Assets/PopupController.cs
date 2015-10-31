using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopupController : MonoBehaviour {

    public GameController gameController;
    public GameObject popupMenu;
    public string text;

    private GameObject textObj;

	// Use this for initialization
	void Start () {
        if (gameController == null) gameController = GameObject.Find("GameController").GetComponent<GameController>();
        if (popupMenu == null) popupMenu = GameObject.Find("PopUpMenu"); //activeじゃないとできない

        textObj = popupMenu.transform.FindChild("Text").gameObject;
	}

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            gameController.PauseGame();
            textObj.GetComponent<Text>().text = text;
            popupMenu.SetActive(true);
            gameController.FocusGameObject(popupMenu.transform.FindChild("Button").gameObject);
        }
    }
}
