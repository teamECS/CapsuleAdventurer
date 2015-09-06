using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ResultController : MonoBehaviour {

    public GameObject resultMenu;
    public GameObject ranking;

    // Use this for initialization
    void Start()
    {
        if (resultMenu == null) resultMenu = GameObject.Find("ResultMenu");
        if (ranking == null) ranking = GameObject.Find("Ranking");

        resultMenu.SetActive(true);
        ranking.SetActive(false);

        FocusGameObject(resultMenu.transform.FindChild("Buttons/Record").gameObject);
    }

    public void FocusGameObject(GameObject focusedObj)
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(focusedObj);
    }
}
