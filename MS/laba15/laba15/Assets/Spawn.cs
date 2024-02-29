using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;
using System.Threading;
// using System.Timers;

public class Spawn : MonoBehaviour
{
    private void Start()
    {
    }

    private IEnumerator BombSpawner()
    {
            const float ScaleIndex = 3;                                                   //Масштаб бомбы
            float RadiusX = gameObject.GetComponent<Renderer>().bounds.size.x;      //Максимальный радиус спавна бомбы по иксу
            float RadiusZ = gameObject.GetComponent<Renderer>().bounds.size.z;      //Максимальный радиус спавна бомбы по зэт
            var rend = gameObject.transform.position;
            float minX = rend.x - Random.Range(0, RadiusX);                         //Минимальные координаты спавна бомбы по иксу
            float minZ = rend.z - Random.Range(0, RadiusZ);                         //Минимальные координаты спавна бомбы по зэт
            float maxX = rend.x + Random.Range(0, RadiusX);                         //Максимальные координаты спавна бомбы по иксу
            float maxZ = rend.z + Random.Range(0, RadiusZ);                         //Максимальные координаты спавна бомбы по зэт
            float ObjectX = Random.Range(minX, maxX);                               //Икс координата спавна бомбы
            float ObjectZ = Random.Range(minZ, maxZ);                               //Зэт координата спавна бомбы
            float ObjectY = 40f;                                                    //Высота спавна бомбы
            const float TimeToSpawn = 100f;                                                 //Задержка спавна бомбы

            var Object = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Object.transform.position = new Vector3(ObjectX, ObjectY, ObjectZ);
            Object.GetComponent<Renderer>().material.color = Color.red;
            Object.GetComponent<Renderer>().transform.localScale = new Vector3(ScaleIndex, 1, ScaleIndex);
            Object.AddComponent<Rigidbody>();
            yield return new WaitForSeconds(TimeToSpawn);
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.name == "tank")
        {   
            // var timer = new Timer() { Interval = 1000};
            // timer.Start();
            // timer.Elapsed +=  (o, e) =>
            // {
                StartCoroutine(BombSpawner());
            // };
        }
    }
}
