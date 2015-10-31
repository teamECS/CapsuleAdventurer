using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MenuController : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject timeUpMenu;
    public GameObject popupMenu;

    // Use this for initialization
    void Start()
    {
        if (pauseMenu == null) pauseMenu = GameObject.Find("PauseMenu");
        if (timeUpMenu == null) timeUpMenu = GameObject.Find("TimeUpMenu");
        if (popupMenu == null) popupMenu = GameObject.Find("PopUpMenu");
        HideMenus();
    }

    public void DisplayPauseMenu()
    {
        pauseMenu.SetActive(true);
        FocusGameObject(pauseMenu.transform.FindChild("Buttons/Resume").gameObject);
    }
    public void DisplayPopupMenu(string text)
    {
        popupMenu.transform.FindChild("Text").gameObject.GetComponent<Text>().text = text;
        popupMenu.SetActive(true);
        FocusGameObject(popupMenu.transform.FindChild("Button").gameObject);
    }
    public void DisplayTimeUpMenu()
    {
        timeUpMenu.SetActive(true);
        FocusGameObject(timeUpMenu.transform.FindChild("Buttons/Reset").gameObject);
    }

    public void FocusGameObject(GameObject focusedObj)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(focusedObj);
    }

    public void HideMenus()
    {
        pauseMenu.SetActive(false);
        timeUpMenu.SetActive(false);
        popupMenu.SetActive(false);
    }
}
