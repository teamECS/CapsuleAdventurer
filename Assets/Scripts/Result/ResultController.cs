using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ResultController : MonoBehaviour {

    public GameObject resultMenu;
    public GameObject ranking;
    public GameObject nameInput;

    // Use this for initialization
    void Start()
    {
        if (resultMenu == null) resultMenu = GameObject.Find("ResultMenu");
        if (ranking == null) ranking = GameObject.Find("Ranking");
        if (nameInput == null) nameInput = GameObject.Find("NameInput");

        resultMenu.SetActive(true);
        ranking.SetActive(false);
        nameInput.SetActive(false);

        FocusGameObject(resultMenu.transform.FindChild("Buttons/NameInput").gameObject);
    }

    public void FocusGameObject(GameObject focusedObj)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(focusedObj);
    }
}
