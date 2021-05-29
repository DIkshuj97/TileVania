using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject Pauselabel;
    [SerializeField] GameObject LoseLabel;
    [SerializeField] GameObject ScoreLabel;

    [SerializeField] Text cointext;
    [SerializeField] Text scoretext;
    [SerializeField] Text EnemyKilledText;

    int coin;
    int score;
    int EnemyKilled;

    private void Start()
    {
        Pauselabel.SetActive(false);
        LoseLabel.SetActive(false);
        ScoreLabel.SetActive(false);
    }

    private void Update()
    {
        Vector2 pos = new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y);

        Pauselabel.transform.position = pos;
        LoseLabel.transform.position = pos;
        ScoreLabel.transform.position = pos;

      if(Input.GetKey(KeyCode.Escape) )/*|| CrossPlatformInputManager.GetButtonDown("Pause")*/
        {
            pause();
        }
    }

    public void pause()
    {
            Pauselabel.SetActive(true);
            FindObjectOfType<player>()._speed = 0f;
            FindObjectOfType<player>().GetComponent<Animator>().SetBool("playerpause", true);
        if(FindObjectOfType<VerticalScroll>())
        {
            FindObjectOfType<VerticalScroll>().scrollrate = 0f;
        }
        
            EnemyMovement[] enemies = FindObjectsOfType<EnemyMovement>();
            foreach (EnemyMovement enemy in enemies)
            {
                enemy.GetComponent<EnemyMovement>().speed = 0f;
                enemy.GetComponent<Animator>().SetBool("Pause", true);
            }
    }

    public void resume()
    {
        Pauselabel.SetActive(false);
        FindObjectOfType<player>()._speed = 5f;
        FindObjectOfType<player>().GetComponent<Animator>().SetBool("playerpause", false);
        if(FindObjectOfType<VerticalScroll>())
        {
            FindObjectOfType<VerticalScroll>().scrollrate = 1.2f;
        }

        EnemyMovement[] enemies = FindObjectsOfType<EnemyMovement>();

        foreach (EnemyMovement enemy in enemies)
        {
            enemy.GetComponent<EnemyMovement>().speed = 2f;
            enemy.GetComponent<Animator>().SetBool("Pause", false);
        }
    }

    public void LoseCondition()
    {
        LoseLabel.SetActive(true);
    }

    public void scorescreen()
    {
        ScoreLabel.SetActive(true);
        coin = FindObjectOfType<GameSession>().coins;
        score = FindObjectOfType<GameSession>().scoreboard;
        EnemyKilled = FindObjectOfType<GameSession>().EnemyKilled;
        EnemyKilledText.text = EnemyKilled.ToString();
        cointext.text = coin.ToString();
        scoretext.text = score.ToString();
    } 
}
