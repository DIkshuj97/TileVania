using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField]
    float LevelLoadDelay = 2f;

    [SerializeField]
    float LevelExitSlomoFactor = 0.2f;

    bool isalive;

    Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        isalive = other.GetComponent<player>().isalive;
        if (!isalive)
        {
            return;
        }
        StartCoroutine(LoadNextLevel());
        animator.SetBool("Reach", true);
    }

    IEnumerator LoadNextLevel()
    {  
        Time.timeScale = LevelExitSlomoFactor;
        FindObjectOfType<LevelController>().scorescreen();
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        Destroy(FindObjectOfType<ScenePersist>().gameObject);
        Time.timeScale = 1f;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}


