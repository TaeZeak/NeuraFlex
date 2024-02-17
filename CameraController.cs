using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player; 
    private Vector3 offset;//показывает расстояние между игроком и камерой
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;//расстояние между игроком и камерой
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //положение камеры меняется только по OZ : позиция игрока - offset
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offset.z + player.position.z);
        transform.position = newPosition;//перемещение камеры в выбраную позицию
    }
}
