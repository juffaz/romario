using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    public void ClickOnPlay()
    {
        _panel.SetActive(true);
    }

    public void PanelClickOnYes()
    {
        SceneManager.LoadScene("Level1");
    }

    public void PanelClickOnNo()
    {
        _panel.SetActive(false);
    }

    


}
