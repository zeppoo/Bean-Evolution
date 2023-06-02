using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonAI : MonoBehaviour
{
    public Vector3 nearestApple;
    public GameObject person;
    public GameObject field;

    void Start()
    {
        field = GameObject.Find("Generate Apples");
        
    }

    // Update is called once per frame
    void Update()
    {
        nearestApple = FindNearestApple();
        transform.position += nearestApple;
    }

    public Vector3 FindNearestApple()
    {
        Vector3 nearestApple = new Vector3(10, 1, 10);

        for (int i = 0; i < field.GetComponent<Generateapples>().apples.Count; i++)
        {
            if (nearestApple.x <= Mathf.Abs(field.GetComponent<Generateapples>().apples[i].xPos) && nearestApple.z <= Mathf.Abs(field.GetComponent<Generateapples>().apples[i].zPos))
            {
                nearestApple = new Vector3(field.GetComponent<Generateapples>().apples[i].xPos, 1, field.GetComponent<Generateapples>().apples[i].zPos);
            }
        }
        return nearestApple;
    }
}
