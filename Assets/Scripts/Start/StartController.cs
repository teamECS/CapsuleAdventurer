using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class StartController : MonoBehaviour {

    public GameObject titleMenu;
    public GameObject selectMenu;

	// Use this for initialization
	void Start () {
        if (titleMenu == null) titleMenu = GameObject.Find("titleMenu");
        if (selectMenu == null) selectMenu = GameObject.Find("selectMenu");

        titleMenu.SetActive(true);
        selectMenu.SetActive(false);

        FocusGameObject(titleMenu.transform.FindChild("Buttons/Start").gameObject);
	}

    public void FocusGameObject(GameObject focusedObj)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(focusedObj);
    }
}
