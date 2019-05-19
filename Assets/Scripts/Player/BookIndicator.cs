using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookIndicator : MonoBehaviour
{
    public GameObject ActiveBook;
    public GameObject InactiveBook;

    public void SetBook(bool isActive) {
        ActiveBook.SetActive(isActive);
        InactiveBook.SetActive(!isActive);
    }
}
