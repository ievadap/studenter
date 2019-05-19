using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetVisualiser : MonoBehaviour
{
    public UnityEngine.UI.Text Label;

    public void ShowStreet(string name) {
        Label.text = name;
        gameObject.GetComponent<Animator>().SetTrigger("Show");
    } 
}
