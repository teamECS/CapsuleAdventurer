using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GuideController : MonoBehaviour {

    public GameController gameController;
    public MenuController menuController;
    public string text;

	// Use this for initialization
	void Start () {
        if (gameController == null) gameController = GameObject.Find("GameController").GetComponent<GameController>();
        if (menuController == null) menuController = GameObject.Find("MenuController").GetComponent<MenuController>();
	}

    void OnTriggerStay(Collider other) {
        if (other.tag == "Player") {
            //gameController.PauseGame();
            menuController.DisplayPopupMenu(text);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            menuController.HideMenus();
        }
    }
}
