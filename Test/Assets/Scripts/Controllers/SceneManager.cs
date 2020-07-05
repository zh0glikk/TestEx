using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public Slider sl;
   
    private void Start()
    {
        StartCoroutine(LoadAsync(1));
        FindObjectOfType<AudioManager>().Play("Default");
    }

    IEnumerator LoadAsync(int sceneNumber)
    {
        yield return new WaitForSeconds(3f);
        AsyncOperation op = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneNumber);

       

        while(!op.isDone)
        {
            float progress = Mathf.Clamp01(op.progress / 0.9f);

            sl.value = progress;

            yield return null;
        }
    }
}
