using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTitle : MonoBehaviour
{
    public Animator thirdSentenceAnimator;
    public string sceneName;

    private void Update()
    {
            StartCoroutine(LoadScene());
  
    }
    IEnumerator LoadScene()
    {
        thirdSentenceAnimator.SetTrigger("Exit");
        yield return new WaitForSeconds(4f);
        TitlePage();
    }

    public void TitlePage()
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
