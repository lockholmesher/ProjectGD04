using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boot : Singleton<Boot>
{
    public float delayExtra;

    void Start()
    {
        StartCoroutine(Loading());
    }

    IEnumerator Loading()
    {
        var load = SceneManager.LoadSceneAsync("GamePlay", LoadSceneMode.Additive);
        load.allowSceneActivation = false;

        LoadData();
        while(!load.isDone)
        {
            if(load.progress >= 0.9f)
            {
                yield return new WaitForSeconds(delayExtra);
                load.allowSceneActivation = true;
            }

            yield return null;
        }

        SceneManager.UnloadSceneAsync("Boot");
    }

    void LoadData()
    {
        LevelManager.Instance.Start();
    }
}
