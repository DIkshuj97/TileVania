using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{

    // Start is called before the first frame update
    private void Awake()
    {
        int numscene = FindObjectsOfType<MusicPlayer>().Length;
        
        if (numscene > 1 )
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        int currentindex = SceneManager.GetActiveScene().buildIndex;
        if (currentindex == 0)
        {
            Destroy(gameObject);
        }
    }
}

