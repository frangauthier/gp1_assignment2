using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] GameObject deadOverlay;
    [SerializeField] GameObject winOverlay;
    [SerializeField] GameObject enemies;

    private bool playerIsDead = false;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if(enemies.transform.childCount == 0)
        {
            PlayerWon();
        }
    }

    public static void PlayerIsDead()
    {
        if(!Instance.playerIsDead)
        {
            Instance.playerIsDead = true;
            Instance.deadOverlay.SetActive(true);
        }
    }

    public static void PlayerWon() {
        Instance.winOverlay.SetActive(true);
    }

    public static void Restart() {
        SceneManager.LoadScene("DungeonExplorer");
    }

}
