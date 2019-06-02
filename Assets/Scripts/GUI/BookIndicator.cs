using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookIndicator : MonoBehaviour
{
    public GameObject activeBook;
    public GameObject inactiveBook;

    public void SetBook(bool isActive) {
        activeBook.SetActive(isActive);
        inactiveBook.SetActive(!isActive);
    }
}
