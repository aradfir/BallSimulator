using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimescaleChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public void Button_Click()
    {
        GameObject text= gameObject.transform.Find("TimeScaleField").gameObject;
        string txt=text.GetComponent<InputField>().text;
        float newScale;
        if (float.TryParse(txt, out newScale))
            Time.timeScale = newScale;
    }
}
