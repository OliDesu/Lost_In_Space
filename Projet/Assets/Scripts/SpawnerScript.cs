using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    public GameObject alien1, alien2, alien3, alien4, slowAlien, destroyRandom;
    public float spawnRate = 6f;
    float nextSpawn = 6f;
    public static bool slowBonusSpawned = false;
    public static bool destroyBonusSpawned = false;
    int whatSpawn;
    Vector2 spawnPos;

    /*void Start()
    {
        var posX = -5f;
        for (int i = 0; i < 10; i++)
        {
            whatSpawn = Random.Range(1, 5);
            spawnPos = new Vector2(posX, 4f);
            GameObject newGo;
            switch (whatSpawn)
            {
                case 1:
                    spawnPos = new Vector2(posX, 4f);
                    newGo = (GameObject)Instantiate(alien1, spawnPos, Quaternion.identity);
                    break;
                case 2:
                    spawnPos = new Vector2(posX, 4f);
                    newGo = (GameObject)Instantiate(alien2, spawnPos, Quaternion.identity);
                    break;
                case 3:
                    spawnPos = new Vector2(posX, 4f);
                    newGo = (GameObject)Instantiate(alien3, spawnPos, Quaternion.identity);
                    break;
                case 4:
                    spawnPos = new Vector2(posX, 4f);
                    newGo = (GameObject)Instantiate(alien4, spawnPos, Quaternion.identity);
                    break;
                default:
                    newGo = null;
                    break;
            }
            if (newGo != null)
            {
                GameManager.aliens.Add(newGo);
            }
            posX += 1f;
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            int nbSpawn = Random.Range(5, 15);
            for (int i = 0; i < nbSpawn; i++)
            {

                whatSpawn = Random.Range(1, 11);
                GameObject newGo;

                switch (whatSpawn)
                {
                    case 1: case 2:
                        spawnPos = new Vector2(Random.Range(FindObjectOfType<GameManager>().leftBorder, FindObjectOfType<GameManager>().rightBorder), FindObjectOfType<GameManager>().upperBorder);
                        if (Physics2D.OverlapBox(spawnPos, new Vector2(0.15f,0.15f),0) == null)
                        {
                            newGo = Instantiate(alien1, spawnPos, Quaternion.identity);
                            GameManager.aliens.Add(newGo);
                        }
                        else newGo = null;
                        break;
                    case 3: case 4:
                        spawnPos = new Vector2(Random.Range(FindObjectOfType<GameManager>().leftBorder, FindObjectOfType<GameManager>().rightBorder), FindObjectOfType<GameManager>().upperBorder);
                        if (Physics2D.OverlapBox(spawnPos, new Vector2(0.15f,0.15f),0) == null)
                        {
                            newGo = Instantiate(alien2, spawnPos, Quaternion.identity);
                            GameManager.aliens.Add(newGo);
                        }
                        else newGo = null;
                        break;
                    case 5: case 6:
                        spawnPos = new Vector2(Random.Range(FindObjectOfType<GameManager>().leftBorder, FindObjectOfType<GameManager>().rightBorder), FindObjectOfType<GameManager>().upperBorder);
                        if (Physics2D.OverlapBox(spawnPos, new Vector2(0.15f,0.15f),0) == null)
                        {
                            newGo = Instantiate(alien3, spawnPos, Quaternion.identity);
                            GameManager.aliens.Add(newGo);
                        }
                        else newGo = null;
                        break;
                    case 7: case 8:
                        spawnPos = new Vector2(Random.Range(FindObjectOfType<GameManager>().leftBorder, FindObjectOfType<GameManager>().rightBorder), FindObjectOfType<GameManager>().upperBorder);
                        if (Physics2D.OverlapBox(spawnPos, new Vector2(0.15f,0.15f),0) == null)
                        {
                            newGo = Instantiate(alien4, spawnPos, Quaternion.identity);
                            GameManager.aliens.Add(newGo);
                        }
                        else newGo = null;
                        break;
                    case 9:
                        if(!slowBonusSpawned){
                          spawnPos = new Vector2(Random.Range(FindObjectOfType<GameManager>().leftBorder, FindObjectOfType<GameManager>().rightBorder), FindObjectOfType<GameManager>().upperBorder);
                          if (Physics2D.OverlapBox(spawnPos, new Vector2(0.15f,0.15f),0) == null)
                          {
                              newGo = Instantiate(slowAlien, spawnPos, Quaternion.identity);
                              GameManager.slowAliens.Add(newGo);
                              slowBonusSpawned = true;
                          }
                          else newGo = null;
                          break;
                        }
                        else newGo = null;
                        break;
                    case 10:
                        if(!destroyBonusSpawned){
                          spawnPos = new Vector2(Random.Range(FindObjectOfType<GameManager>().leftBorder, FindObjectOfType<GameManager>().rightBorder), FindObjectOfType<GameManager>().upperBorder);
                          if (Physics2D.OverlapBox(spawnPos, new Vector2(0.15f,0.15f),0) == null)
                          {
                              newGo = Instantiate(destroyRandom, spawnPos, Quaternion.identity);
                              GameManager.destroyRandom.Add(newGo);
                              destroyBonusSpawned = true;
                          }
                          else newGo = null;
                          break;
                        }
                        else newGo = null;
                        break;
                    default:
                        newGo = null;
                        break;
                }
                nextSpawn = Time.time + spawnRate;
            }
        }
    }
}
