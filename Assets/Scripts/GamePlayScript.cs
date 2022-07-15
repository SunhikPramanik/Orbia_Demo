using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject ring;
    [SerializeField]
    private GameObject points;
    [SerializeField]
    private Text showScore;
    [SerializeField]
    private GameObject gameOverText;
    public List<GameObject> EnemyPrefabs = new List<GameObject>();

    private bool isGameOver;
    private float X_position = -2.0f;
    private float Y_position = 4.6f;
    private int ran=0;
    private int val=0;
    private int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && isGameOver == false)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, ring.transform.position, 5f * Time.deltaTime);
        }
        if(player.transform.position == ring.transform.position && isGameOver == false)
        {
            EnemyPrefabs[ran].transform.position = new Vector3(100, 100, 100);
            val = Random.Range(0, 2);
            repeatRing(val);
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
        Y_position = Y_position + 9.2f;
        ring.transform.position= new Vector3(X_position, Y_position, ring.transform.position.z);
        ran=Random.Range(0,EnemyPrefabs.Count);
        EnemyPrefabs[ran].transform.position = new Vector3(X_position, Y_position, ring.transform.position.z);
        X_position = -X_position;
        if (spawnValue== 1)
        {
            points.transform.position=ring.transform.position;
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
            score = score+1;
        }
    }
}
