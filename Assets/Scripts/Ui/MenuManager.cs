using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text text;
    public Image image1, image2, image3, buttonImage;
    public Button button;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayScene()
    {
        SceneManager.LoadScene(1);
    }
    public void CreditUi()
    {
        text.enabled = true;
        button.enabled = true;
        image1.enabled = true;
        image2.enabled = true;
        image3.enabled = true;
        buttonImage.enabled = true;
    }
    public void CreditCloseUi()
    {
        text.enabled = false;
        button.enabled = false;
        image1.enabled = false;
        image2.enabled = false;
        image3.enabled = false;
        buttonImage.enabled = false;
    }
}
