using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;

public class ResultController : MonoBehaviour {

    public GameObject resultMenu;
    public GameObject rankingMenu;
    public GameObject nameInputMenu;

    // Use this for initialization
    void Start()
    {
        if (resultMenu == null) resultMenu = GameObject.Find("ResultMenu");
        if (rankingMenu == null) rankingMenu = GameObject.Find("RankingMenu");
        if (nameInputMenu == null) nameInputMenu = GameObject.Find("NameInputMenu");

        HideMenus();
        DisplayResultMenu();
    }

    public void DisplayResultMenu()
    {
        resultMenu.SetActive(true);
        FocusGameObject(resultMenu.transform.FindChild("Buttons/NameInput").gameObject);
    }
    public void DisplayRankingMenu()
    {
        rankingMenu.SetActive(true);
        FocusGameObject(rankingMenu.transform.FindChild("Buttons/Back").gameObject);
    }
    public void DisplayNamiInputMenu()
    {
        nameInputMenu.SetActive(true);
        FocusGameObject(nameInputMenu.transform.FindChild("Buttons/Enter").gameObject);
    }

    public void FocusGameObject(GameObject focusedObj)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(focusedObj);
    }

    public void SetInteractive(GameObject buttonObj, bool b)
    {
        buttonObj.GetComponent<Button>().interactable = b;
    }

    public void HideMenus()
    {
        resultMenu.SetActive(false);
        rankingMenu.SetActive(false);
        nameInputMenu.SetActive(false);
    }
}
