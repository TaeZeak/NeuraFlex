using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject[] tilePrefabs; //массив префаба
    private List<GameObject> activeTiles = new List<GameObject>(); //список
    private float spawnPos = 0; //показывает позицию спавна платформы по оси z
    private float tileLength = 100; //переменнаяб длина платформы

    [SerializeField] private Transform player; //отслеживаем положение игрока
    private int startTiles = 6; //на старте спавним несколько платформ

    void Start()
    {
        //спавним случайную платформу
        for (int i = 0; i < startTiles; i++)
        {
            SpawnTile(Random.Range(0,tilePrefabs.Length));
        }
    }

    
    void Update()
    {
        //если положение игрока по OZ больше чем разница между позицией для спавна и длиной стартовой дорожкиб то спавним новую платформу
        if (player.position.z - 60> spawnPos - (startTiles * tileLength)) //-60 чтобы не удалялась первая платформа
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile(); //удаляет пройденную платформу
        }                             
    }

    private void SpawnTile(int tileIndex)
    {
        GameObject nextTile = Instantiate(tilePrefabs[tileIndex], transform.forward * spawnPos, transform.rotation); //(нужная платформа, спавним впереди на координате SpawnPos,платформа не должна вертеться)
        activeTiles.Add(nextTile); //Добавляет новую платформу
        spawnPos += tileLength; //увеличиваем на длину платформы
    }
    //Удаляет пройденые платформы
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
