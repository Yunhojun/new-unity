using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelSwitch : MonoBehaviour
{
    public Button button;

    void Start()
    {
        GetComponent<Canvas>().enabled = false;
    }

    void Update()
    {

    }

    public void AAA()
    {
        GetComponent<Canvas>().enabled = !GetComponent<Canvas>().enabled;
    }

    public void BBB()
    {
        GetComponent<Canvas>().enabled = false;
    }
}
