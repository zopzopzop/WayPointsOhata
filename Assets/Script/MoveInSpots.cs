using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInSpots : MonoBehaviour
{
    public GameObject[] Pontos;
    public float speed;
    public float accuracy = 1.0f;
    public float rootSpeed = 0.8f;
    public int index;
    public bool isMoving;
    Animator animator;


    void Start()
    {
        //pega o controle de animação
        animator = GetComponent<Animator>();
        //liga a movimentação
        isMoving = true;
        //reseta os pontos
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("Speed", speed);
        if (isMoving)
        {

            // Deslocamento entre os pontos por Move Foward
            transform.position = Vector3.MoveTowards(transform.position, Pontos[index].transform.position, speed * Time.deltaTime);
            //adiciona um vetor entre o personagem e o destino
            Vector3 diretion = Pontos[index].transform.position - transform.position;
            //rotaciona o personagem para o destino
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(diretion), Time.deltaTime * rootSpeed);

            //checa q se o personagem chegou no destino com forme a distancia do Accuracy

            if (diretion.magnitude < accuracy)
            {
                index = ChangPoit(index);


            }


        }


    }

    // Troca o Ponto onde o personagem vai
    int ChangPoit(int Idx)
        {

            if ((Idx + 1) != Pontos.Length)
            {
                Idx ++;

            }
            else
            {
                Idx = 0;
                
            }

        return Idx;
        }


  
}
