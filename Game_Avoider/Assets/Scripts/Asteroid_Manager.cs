//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Asteroid_Manager : MonoBehaviour
{
    // Start is called before the first frame update
 [SerializeField] private GameObject[] obj_prefabs;
 [SerializeField] private float sec_between_objs = 1.5f;

[SerializeField] private Vector2 ForceRange;

private Camera mainCam;

private float timer;

private void Start() 
{
    mainCam = Camera.main;
}

private void Update() 
{
    timer -= Time.deltaTime;

    if(timer <= 0)
    {
        Spawmobj();

        timer += sec_between_objs;
    }

  
}

    private void Spawmobj()
    {
        int side = Random.Range (0,4);

        Vector2 spawnPoint = Vector2.zero;
        Vector2 direction = Vector2.zero;

        switch(side) 
               {
                 case 0:

                       spawnPoint.x = 0;
                       spawnPoint.y = Random.value;
                       direction = new Vector2(1f,Random.Range(-1,1));
                       break; // Right

                 case 1:
                       spawnPoint.x = 1;
                       spawnPoint.y = Random.value;
                       direction = new Vector2(-1f,Random.Range(-1,1));
                       break; //left of screen

                 case 2:
                       spawnPoint.x = Random.value;
                       spawnPoint.y = 0;
                       direction = new Vector2(Random.Range(-1,1),1f);
                
                        break; // bottom of screen
                case 3:
                       spawnPoint.x = Random.value;
                       spawnPoint.y = 1;
                       direction = new Vector2(Random.Range(-1,1),-1f);

                        break; // top of screen

               }

              Vector3  worldspawnPoint = mainCam.ViewportToWorldPoint(spawnPoint);
              worldspawnPoint.z = 0f;
              GameObject selectedObj = obj_prefabs[Random.Range(0,obj_prefabs.Length)];

              GameObject objinstance = Instantiate(
                  selectedObj,
                  worldspawnPoint,
                  Quaternion.Euler(0,0,Random.Range(0,360))
                  
                  );

              Rigidbody rigidbody = objinstance.GetComponent<Rigidbody>();

              rigidbody.velocity = direction.normalized * Random.Range(ForceRange.x,ForceRange.y);

    }
}
