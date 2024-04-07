using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public static float playerHealth;
    public static float enemyHealth;
    public static int enemyType;
    public static float enemyDamage;
    public SpriteRenderer sr;
    public TextMeshProUGUI health1;
    public TextMeshProUGUI health2;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 15;
        sr = GetComponent<SpriteRenderer>();
        enemyType = Random.Range(0, 2);
        if (enemyType == 0)
        {
            enemyHealth = 33;
            enemyDamage = 3;
            sr.color = Color.white;
        }
        if (enemyType == 1)
        {
            enemyHealth = 24;
            enemyDamage = 4;
            sr.color = Color.cyan;
        }
        if (enemyType == 2)
        {
            enemyHealth = 41;
            enemyDamage = 2;
            sr.color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        health1.text = playerHealth.ToString();
        health2.text = enemyHealth.ToString();
        if (enemyHealth < 1)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
            SceneManager.LoadScene(nextSceneIndex);
        }
        if (playerHealth < 1)
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = (currentSceneIndex + 2) % SceneManager.sceneCountInBuildSettings;
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
