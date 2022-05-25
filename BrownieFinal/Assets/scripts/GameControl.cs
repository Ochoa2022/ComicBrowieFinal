using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameControl : MonoBehaviour
{
    public GameObject gun1, gun2, gun3, gameOver;
    public static int health;
    public GameObject player;
   
    // Start is called before the first frame update
    void Start()
    {
        
        gun1.gameObject.SetActive(true);
        gun2.gameObject.SetActive(true);
        gun3.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);
      
        
    }

    // Update is called once per frame
    void Update()
    {
        health = player.GetComponent<playerMovement>().currentHealth;
        if (health > 3)
            health = 3;
        switch (health)
        {
            case 3:
                gun1.gameObject.SetActive(true);
                gun2.gameObject.SetActive(true);
                gun3.gameObject.SetActive(true);
                break;
            case 2:
                gun1.gameObject.SetActive(true);
                gun2.gameObject.SetActive(true);
                gun3.gameObject.SetActive(false);
                break;
            case 1:
                gun1.gameObject.SetActive(true);
                gun2.gameObject.SetActive(false);
                gun3.gameObject.SetActive(false);
                break;
            case 0:
                gun1.gameObject.SetActive(false);
                gun2.gameObject.SetActive(false);
                gun3.gameObject.SetActive(false);
                gameOver.gameObject.SetActive(true);
                Time.timeScale = 0;
                break;

        }
    }
}
