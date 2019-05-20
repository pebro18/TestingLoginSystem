using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject[] UiObjects;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleLoginRegObj()
    {
        UiObjects[0].SetActive(!UiObjects[0].activeSelf);
        UiObjects[1].SetActive(!UiObjects[1].activeSelf);
    }
}
