using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameProgression : MonoBehaviour
{
    public static int waveScore;

    public static GameProgression instance;

    public Levels[] levels;

    public PlayerShooting playerShooting;
    public Player player;
    public EnemySpawner enemySpawner;
    
    public Slider waveSlider;

    public GameObject upgradeUI;
    public GameObject levelUpEffect;
    public SceneFader sceneFader;
    public string sceneToLoad;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        waveScore = 0;
        
        waveSlider.value = 0;

        Time.timeScale = 1f;
        
    }
    private void Start()
    {
        enemySpawner.currentWave = levels[0].wave;
        levels[0].isUnlock = true;
        waveSlider.maxValue = levels[1].scoreToUnlock;
    }
    public void AddScore(int amount)
    {
        waveScore += amount;
        waveSlider.value = waveScore;
        for(int i = 0; i < levels.Length; i++)
        {
            if(!levels[i].isUnlock && waveScore >= levels[i].scoreToUnlock)
            {
                if(levels[i].endGame)
                {
                    StartCoroutine(EndGame());
                }
                else
                {
                    UpLevel();
                    Debug.Log(levels[i]);
                    
                }
                enemySpawner.currentWave = levels[i].wave;

                if(i < levels.Length - 1)
                {
                    waveSlider.minValue = waveScore;
                    waveSlider.maxValue = levels[i + 1].scoreToUnlock;
                }

                levels[i].isUnlock = true;
            }
        }
    }

    void UpLevel()
    {        
        Debug.Log("LEVEL UP");
        waveScore = 0;
        GameObject effect = Instantiate(levelUpEffect, PlayerController.Position, Quaternion.identity);
        Destroy(effect, 5f);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<Enemy>().Remove();
        }
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bullet in bullets)
        {
            //if (bullet != null)
            //    bullet.GetComponent<Bullet>().Remove();
            //else
                return;
        }
    }
    
    IEnumerator EndGame()
    {
        Time.timeScale = .5f;
        

        GameObject effect = Instantiate(levelUpEffect, PlayerController.Position, Quaternion.identity);
        Destroy(effect, 5f);

        yield return new WaitForSecondsRealtime(5f);
        sceneFader.FadeTo(sceneToLoad);
        
    }

}
