using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GaugeController : MonoBehaviour {

    public Sprite GaugeG;
    public Sprite GaugeY;
    public Sprite GaugeR;

    private RectTransform rectTrans;
    private Image image;

	// Use this for initialization
	void Start () {
        rectTrans = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        image.sprite = GaugeG;
	}

	public void UpdateGauge (float timeRate)
    {
        rectTrans.localScale = new Vector3(timeRate, 1f, 1f);

        if (timeRate <= 0.1)
            Change2Red();
        else if (timeRate <= 0.3)
            Change2Yellow();
        else
            Change2Green();
	}

    public void Change2Green()
    {
        if (image.sprite != GaugeG) image.sprite = GaugeG;
    }
    public void Change2Yellow()
    {
        if (image.sprite != GaugeY) image.sprite = GaugeY;
    }
    public void Change2Red()
    {
        if (image.sprite != GaugeR) image.sprite = GaugeR;
    }


}
