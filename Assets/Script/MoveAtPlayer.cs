using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAtPlayer : MonoBehaviour
{

    // Objeto Player
    public GameObject Player;

    // Velocidade para o deslocamento
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // O Metodo MoveToward ele necessita da posição atual e a posição (Target), no qual passamos a do player
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
    }
}
