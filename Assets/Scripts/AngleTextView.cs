using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AngleTextView : MonoBehaviour
{
    public GameObject angleTextObject;

    void Start()
    {
        angleTextObject.SetActive(false);
    }

    void Update()
    {
        
    }

    void OnMouseOver() {
        angleTextObject.SetActive(true);
    }

    void OnMouseExit() {
        angleTextObject.SetActive(false);
    }
}
