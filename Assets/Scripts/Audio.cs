using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] audio = GameObject.FindGameObjectsWithTag("Music");
        if (audio.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        GameObject[] audio = GameObject.FindGameObjectsWithTag("Music");
        if (audio.Length > 1 && "TitleScreen" != SceneManager.GetActiveScene().name)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }
}
