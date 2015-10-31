using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FillterController : MonoBehaviour {

    public float interval = 0.5f;
    private Image image;
    private bool isBlinking;

	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
        Change2Clear();
        isBlinking = false;
	}

    public void Change2Clear()
    {
        image.color = new Color(0f, 0f, 0f, 0f);
    }
    public void Change2Black()
    {
        image.color = new Color(0f, 0f, 0f, 100f / 255f);
    }
    public void Change2Red()
    {
        image.color = new Color(1f, 0f, 0f, 100f / 255f);
    }

    IEnumerator BlinkRedFillter()
    {
        while (true)
        {
            Change2Red();
            yield return new WaitForSeconds(interval);
            Change2Clear();
            yield return new WaitForSeconds(interval);
        }
    }

    public void StartBlinking()
    {
        if (!isBlinking)
        {
            StartCoroutine("BlinkRedFillter");
            isBlinking = true;
        }
    }
    public void StopBlinking()
    {
        if (isBlinking)
        {
            StopCoroutine("BlinkRedFillter");
            Change2Clear();
            isBlinking = false;
        }
    }

}
