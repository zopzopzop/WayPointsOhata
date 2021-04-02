using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Link
{//guarda os valores para serem pegos em outos scrips
    public enum diretion { UNI, BI}
    public GameObject node1;
    public GameObject node2;
    public diretion dir;
}
public class WayPointManager : MonoBehaviour
{
    public GameObject[] waypoints;
    public Link[] links;
    public Graph graph = new Graph();


    void Start()
    {
        //cria os caminhos baseado na posição dos waypoins
        if(waypoints.Length > 0)
        {
            foreach(GameObject wp in waypoints)
            {
                graph.AddNode(wp);
            }
            foreach(Link l in links)
            {
                graph.AddEdge(l.node1, l.node2);
                if (l.dir == Link.diretion.BI)
                    graph.AddEdge(l.node2, l.node1);
            }
        }
    }


    void Update()
    {
        //escreve o caminho na tela
        graph.debugDraw();
    }
}
