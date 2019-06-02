using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StreetVisualiser : MonoBehaviour
{
    public Text label;

    public void ShowStreet(string name) {
        label.text = name;
        gameObject.GetComponent<Animator>().SetTrigger("Show");
    } 
}
