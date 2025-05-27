using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
    // Ej.1
    private int health;
    public string Name;
    protected float Velocity;
    public Vector3 position = new Vector3(3, 3, 3);
    public Variables variables;

    //Ej.3
    public enum States { Idle, Run, Attack, Death }
    private List<States> classListA3D = new List<States>();
    private States[] classArrayA3D = new States[3];

    //Ej.5
    private States stateA3D;

    void Start()
    {
        //Ej.2
        health = 100;
        Name = "Alex Garcia";
        Velocity = 8.0f;
        //Ej.4
        classListA3D.Add(States.Idle);
        classListA3D.Add(States.Run);
        classListA3D.Add(States.Attack);

        classArrayA3D[0] = States.Idle;
        classArrayA3D[1] = States.Run;
        classArrayA3D[2] = States.Attack;

        stateA3D = States.Idle;

        //Ej.9
        if (stateA3D == States.Idle)
            Idle();
        else if (stateA3D == States.Run)
            Run();
        else if (stateA3D == States.Attack)
            Attack();
        else if (stateA3D == States.Death)
            Death();
    }

    void Update()
    {
        //Ej.10
        switch (stateA3D)
        {
            case States.Idle:
                Idle();
                break;
            case States.Run:
                Run();
                break;
            case States.Attack:
                Attack();
                break;
            case States.Death:
                Death();
                break;
            default:
                Debug.Log("error");
                break;
        }
        //Ej.11/12
        int listVal = 0;
        do
        {
            if (listVal < classListA3D.Count)
                classListA3D[listVal] = States.Run;
            listVal++;
        } while (listVal < 2);

        for (int i = 0; i < classArrayA3D.Length; i++)
        {
            if (i < 2)
                classArrayA3D[i] = States.Run;
        }

        //Ej.13
        foreach (var state in classListA3D)
        {
            Debug.Log(state);
        }

        foreach (var state in classArrayA3D)
        {
            Debug.Log(state);
        }
    }

    //Ej.8
    public void Idle() => Debug.Log("Idle");
    public void Run() => Debug.Log("Run");
    public void Attack() => Debug.Log("Attack");
    public void Death() => Debug.Log("Death");

    //Ej.14
    public int Calculate(int a, int b)
    {
        int min = Mathf.Min(a, b);
        return min < 0 ? 0 : min;
    }
}
