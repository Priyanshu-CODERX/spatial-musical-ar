using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Toggle toggleButton;
    public GameObject Canvas;
    public GameObject Reticle;

    private bool keepFinding = true;

    private void Start()
    {
    }

    private void Update()
    {
        if (Reticle == null)
        {
            Reticle = GameObject.Find("Reticle(Clone)");
        }

        Canvas.SetActive(toggleButton.isOn);

        if(toggleButton.isOn == false)
        {
            Destroy(Reticle);
        }

    }
}
