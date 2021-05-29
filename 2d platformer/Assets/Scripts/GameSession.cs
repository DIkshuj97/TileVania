using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField]
    public int Baselives = 5;

    [SerializeField]
    Text lives;

    [SerializeField]
    Text level;

    [SerializeField]
    Text coinsText;

    [SerializeField]
    float LevelLoadDelay = 2f;

    public float Playerlives;
    public int coins = 0;
    public int scoreboard1 = 0;
    public int scoreboard2 = 0;
    public int scoreboard = 0;
    public int EnemyKilled = 0;

    private void Awake()
    {
        int numGameSession = FindObjectsOfType<GameSession>().Length;
        if(numGameSession>1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    
    void Start()
    {
        Playerlives = Baselives - PlayerPrefsController.GetDifficulty();
        lives.text = Playerlives.ToString();
        coinsText.text = coins.ToString(); 
    }

    public void Update()
    {
        int currentindex = SceneManager.GetActiveScene().buildIndex;
        string scene = SceneManager.GetActiveScene().name;
        level.text = currentindex.ToString();
        if (currentindex == 0 || scene=="Success" )
        {
            Destroy(gameObject);
        }

        
        scoreboard = scoreboard1 + scoreboard2;
    }

    public void addtolives()
    {
        Playerlives += 1;
        lives.text = Playerlives.ToString();
    }

    public void addtocoin(int coinstoadd)
    {
       coins += coinstoadd;
       coinsText.text = coins.ToString();
       scoreboard1 = coins * 100;   
    }

    public void EnemyKilledAdd()
    {
        EnemyKilled += 1;
        scoreboard2 = EnemyKilled * 100;
    }

    public void playerprocesslives()
    {
        if(Playerlives>1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    private void TakeLife()
    {
        Playerlives--;
        lives.text = Playerlives.ToString();
        StartCoroutine(DeathDealy());
    }

    IEnumerator DeathDealy()
    {
        var currentsceneindex = SceneManager.GetActiveScene().buildIndex;
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        SceneManager.LoadScene(currentsceneindex);
    }

    private void ResetGameSession()
    {
        StartCoroutine(LoseGame());
    }

    IEnumerator LoseGame()
    {
        yield return new WaitForSecondsRealtime(LevelLoadDelay);
        FindObjectOfType<LevelController>().LoseCondition();
        Destroy(gameObject);
    }
}
