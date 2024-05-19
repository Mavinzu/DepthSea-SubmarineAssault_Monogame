using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndScene : MonoBehaviour
{
    public TMP_Text text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WinEnd();
        LoseEnd();
    }
    public void PlayAgainScene()
    {
        SceneManager.LoadScene(1);
    }
    void WinEnd()
    {
        if(UiManager.score >= UiManager.target)
        {
            text.text = "Congratulations on completing the challenge Next Target : " + (UiManager.target + UiManager.score);
            UiManager.targetIndex += UiManager.score;
            UiManager.score = 0;
        }
    }
    void LoseEnd()
    {
        if(UiManager.health == 0)
        {
            text.text = "you failed to complete the challenge :(";
            UiManager.score = 0;
            UiManager.targetIndex = 10;
        }
    }
}
