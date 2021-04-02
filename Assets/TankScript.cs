using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TankScript : MonoBehaviour
{
     Transform Point;
       public float Speed = 5.0f;
    public float accuracy = 1.0f;
    public float rootSpeed = 2.0f;

    public GameObject wpManager;
    GameObject[] wps;
    GameObject currentNode;
    int currentWP = 0;
    Graph g;

    void Start()
    {
        //coleta informações do WaypointManager
        wps = wpManager.GetComponent<WayPointManager>().waypoints;
        g = wpManager.GetComponent<WayPointManager>().graph;
        currentNode = wps[0];

    }
    //muda o caminho pra ir pro heliponto
    public void GoToHeli()
    {
        g.AStar(currentNode, wps[1]);
        currentWP = 0;
    }
    //muda o caminho pra ir pra ruinas
    public void GoToRuin()
    {
        g.AStar(currentNode, wps[6]);
        currentWP = 0;
    }

    public void GoToTanks()
    {
        g.AStar(currentNode, wps[9]);
        currentWP = 0;
    }

    private void LateUpdate()
    {
        if (g.getPathLength() == 0 || currentWP == g.getPathLength()) 
            return;
        //vai ate o nó mais proximo
        currentNode = g.getPathPoint(currentWP);

        //move para o proximo ponto
        if (Vector3.Distance(g.getPathPoint(currentWP).transform.position, transform.position) < accuracy)
        {
            currentWP++;
        }
         //move o tanke
        if (currentWP < g.getPathLength())
        {
            //localisa o ponto de direção
            Point = g.getPathPoint(currentWP).transform;
            //tira a posição do ponto
            Vector3 lookAtGoal = new Vector3(Point.position.x, this.transform.position.y, Point.position.z);
            //cria o vetor de direção
            Vector3 direction = lookAtGoal - this.transform.position;
            //rotaciona o tanke
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rootSpeed);
            transform.position = Vector3.MoveTowards(transform.position, Point.transform.position, Speed * Time.deltaTime);
        }
        }

}
