using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayScript : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject points;
    [SerializeField]
    private Text showScore;
    [SerializeField]
    private GameObject gameOverText;
    [SerializeField]
    private GameObject ring1;
    [SerializeField]
    private GameObject ring2;
    [SerializeField]
    private GameObject ring3;
    [SerializeField]
    private GameObject ring4;
    public List<GameObject> EnemyPrefabs = new List<GameObject>();

    private bool isGameOver;
    private float ringSpawnDis;
    private GameObject ring;
    private int tempEnemy=0;

    private float X_position=2;
    private float Y_position=1;
    private int ran=2;
    private int val=0;
    private int score = 0;
    private bool isMoving=false;
    #endregion

    void Start()
    {
        isGameOver = false;
        ring = ring1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && isGameOver == false)
        {
            isMoving = true;
        }
        if((isMoving==true) && isGameOver == false)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, ring.transform.position, 5f * Time.deltaTime);
        }
        if(player.transform.position == ring.transform.position && isGameOver == false)
        {
            Debug.Log("Temp:"+tempEnemy);
            EnemyPrefabs[tempEnemy].transform.position = new Vector3(100,100,100);
            isMoving = false;
            val = Random.Range(0, 2);
            repeatRing(val);
            if (tempEnemy >= 5)
            {
                tempEnemy=0;
            }
            else tempEnemy++;
        }
        if(Input.GetMouseButton(1))
        {
            isGameOver = false;
            gameOverText.SetActive(false);
            SceneManager.LoadScene(0);
        }
        showScore.text = score.ToString();
    }

    public void repeatRing(int spawnValue)
    {
        ringSpawnDis = Mathf.Round(Random.Range(2f, 3f));
        Debug.Log(ringSpawnDis);
        if(player.transform.position==ring1.transform.position)
        {
            Debug.Log("Ran:" + ran);
            ring = ring2;
            Y_position = ring3.transform.position.y + Random.Range(2, 5);
            if (spawnValue == 1)
            {
                X_position = ring3.transform.position.x + ringSpawnDis;
            }
            else X_position = ring3.transform.position.x - ringSpawnDis;
            ring4.transform.position = new Vector3(X_position, Y_position, ring3.transform.position.z);
            if (ran >= 5)
            {
                ran = 0;
            }
            else ran++;
            EnemyPrefabs[ran].transform.position = ring4.transform.position;
            spawnValue = Random.Range(0, 2);
            if (spawnValue == 1)
            {
                points.transform.position = ring4.transform.position;
            }
        }
        if (player.transform.position == ring2.transform.position)
        {
            Debug.Log("Ran:" + ran);
            ring = ring3;
            Y_position = ring4.transform.position.y + Random.Range(2, 5);
            if (spawnValue == 1)
            {
                X_position = ring4.transform.position.x + ringSpawnDis;
            }
            else X_position = ring4.transform.position.x - ringSpawnDis;
            ring1.transform.position = new Vector3(X_position, Y_position, ring4.transform.position.z);
            if (ran >= 5)
            {
                ran = 0;
            }
            else ran++;
            EnemyPrefabs[ran].transform.position = ring1.transform.position;
            spawnValue = Random.Range(0, 2);
            if (spawnValue == 1)
            {
                points.transform.position = ring1.transform.position;
            }
        }
        if (player.transform.position == ring3.transform.position)
        {
            Debug.Log("Ran:" + ran);
            ring = ring4;
            Y_position = ring1.transform.position.y + Random.Range(2, 5);
            if (spawnValue == 1)
            {
                X_position = ring1.transform.position.x + ringSpawnDis;
            }
            else X_position = ring1.transform.position.x - ringSpawnDis;
            ring2.transform.position = new Vector3(X_position, Y_position, ring1.transform.position.z);
            if (ran >= 5)
            {
                ran = 0;
            }
            else ran++;
            EnemyPrefabs[ran].transform.position = ring2.transform.position;
            spawnValue = Random.Range(0, 2);
            if (spawnValue == 1)
            {
                points.transform.position = ring2.transform.position;
            }
        }
        if (player.transform.position == ring4.transform.position)
        {
            Debug.Log("Ran:" + ran);
            ring = ring1;
            Y_position = ring2.transform.position.y + Random.Range(2, 5);
            if (spawnValue == 1)
            {
                X_position = ring2.transform.position.x + ringSpawnDis;
            }
            else X_position = ring2.transform.position.x - ringSpawnDis;
            ring3.transform.position = new Vector3(X_position, Y_position, ring2.transform.position.z);
            if (ran >= 5)
            {
                ran = 0;
            }
            else ran++;
            EnemyPrefabs[ran].transform.position = ring3.transform.position;
            spawnValue = Random.Range(0, 2);
            if (spawnValue == 1)
            {
                points.transform.position = ring3.transform.position;
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            isGameOver = true;
            gameOverText.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Points") && isGameOver == false)
        {
            points.transform.position= new Vector3(100,100,100);
            score++;
        }
    }
}
