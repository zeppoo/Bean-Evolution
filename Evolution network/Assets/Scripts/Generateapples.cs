using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class Generateapples : MonoBehaviour
{
    public List<Apple> apples = new List<Apple>();
    public void GenerateNewApples(int appleAmount)
    {
        for (int l = 0; l < apples.Count; l++) //Delete old apples
        {
            Object.Destroy(apples[l].apple);
            apples.Remove(apples[l]);
        }
        for (int i = 0; i < appleAmount; i++) //Create new apples
        {
            apples.Add(new Apple());
            for (int j = 0; j < apples.Count - 1; j++)
            {
                if (apples[j].position == apples.Last().position) //check if apples is already at the position
                {
                    apples.Last().DeleteApple();
                }
            }
        }
    }
}

public class Apple
{
    public float xPos;
    public float yPos;
    public float zPos;
    public Vector3 position;
    public GameObject apple;
    public Apple()
    {
        this.xPos = Random.Range(-8, 8);
        this.yPos = 1f;
        this.zPos = Random.Range(-8, 8);
        this.position = new Vector3(xPos, yPos, zPos);
        this.apple = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        this.apple.transform.position = position;
        this.apple.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        this.apple.AddComponent<SphereCollider>();
        this.apple.tag = "apple";
        
    }

    public void DeleteApple()
    {
        Object.Destroy(this.apple);
    }
}
