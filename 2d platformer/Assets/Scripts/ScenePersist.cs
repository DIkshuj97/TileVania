using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour
{
    int index;

    private void Awake()
    {
        int numscene = FindObjectsOfType<ScenePersist>().Length;
        if(numscene>1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        index = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        int currentindex = SceneManager.GetActiveScene().buildIndex;
        if(currentindex!=index)
        {
            Destroy(gameObject);
        }
    }
}
