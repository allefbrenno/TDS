using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

    public bool alive;
    public Rigidbody player;
    public Rigidbody bot;
    public Transform[] spawnPoints; // precisa de 5 espaços.
    private Vector3 refEnemySpawnPosition;
    private int wave;
    private int randomPoint;
    private Rigidbody botEnemy;
    private GameObject playerAlive;
    private GameObject[] Enemies;
    

    void Awake() {
        alive = true;
        refEnemySpawnPosition = new Vector3();
        wave = 1;
    }

    void ControlSpawnEnemy()
    {
        /* Verificação se existe inimigos no jogo */
        Enemies = GameObject.FindGameObjectsWithTag("BotEnemy");
        if (Enemies.Length == 0)
            alive = false;
        else if (Enemies.Length != 0)
            alive = true;
        /* Caso não exista, crie na posição selecionada no array pulico de tranforms */
        if (alive == false && wave == 1)
        {
            Debug.Log("entrei");

            refEnemySpawnPosition = spawnPoints[0].position;
            Rigidbody botEnemy = Instantiate(bot, refEnemySpawnPosition, Quaternion.identity);
            wave++;
        }
        /* Caso não exista, crie na posição selecionada no array pulico de tranforms de acordo com número da onda */
        else if (alive == false && wave >= 2)
        {
            int x = 2 * wave;
        /* X informa a quantidade de vezes que o loop vai rodar, ou seja determina quantos inimigos vão surgir */
            for(int i=0; i < x; i++)
            {
                /*Um mini código de aleatoriedade para decidir em qual spawn o inimigo vai aparecer */
                randomPoint = Random.Range(0,1000);
                /* O resto da da divisão do número aleatório pelo numero de spawns determina onde o inimigo irá surgir */
                refEnemySpawnPosition = spawnPoints[randomPoint % 4].position;
                Rigidbody botEnemy = Instantiate(bot, refEnemySpawnPosition, Quaternion.identity);
            }
            wave++;

        }
    }
    void ControlSpawnPlayer()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        { 
            //O player sempre é instanciado na ultima posição do array.
            Instantiate(player, spawnPoints[4].position, Quaternion.identity);
        }
    }
    void Update()
    {
          /* A função é chamada nela mesmo, pois dele ficar aclopada em um elemento do cenário para funcionar */
            ControlSpawnEnemy();
            ControlSpawnPlayer();
    }

}

