using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicSource : MonoBehaviour
{
    public int loadedScenes = 0;
    
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += (arg0, mode) =>
        {
            loadedScenes++;
        };
        GameObject[] musics = GameObject.FindGameObjectsWithTag("music");
        foreach (var VARIABLE in musics)
        {
            if (VARIABLE.GetComponent<MusicSource>().loadedScenes < 1)
            {
                Destroy(VARIABLE);
            }
        }
    }
}
