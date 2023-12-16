using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] model;
    [HideInInspector]
    public GameObject[] modelPrefab = new GameObject[2];
    public GameObject WinPrefab;

    private GameObject temp1,temp2;
    public Vector3 obj;

    public int level = 1, addOn = 7;
     float i =0;
    /* public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;
        float distanceTravelled;*/
    // Start is called before the first frame update
    void Start()
    {
       /* if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }*/
        level = PlayerPrefs.GetInt("Level",1);
        if (level > 9){
            addOn = 0;
        }
        ModelSelection();
        float random = Random.value;
        for ( i = 0; i > -level -addOn; i -= 0.5f)
        {
            int value =1;
            i++;
            if(level <= 20)
                 temp1 = Instantiate(modelPrefab[Random.Range(0,2)]);
            if(level > 20 && level <= 50)
                 temp1 = Instantiate(modelPrefab[Random.Range(1,3)]);
            if(level > 50 && level <= 100)
                 temp1 = Instantiate(modelPrefab[Random.Range(2,4)]);
            if(level > 100)
                 temp1 = Instantiate(modelPrefab[Random.Range(3,4)]);

           /* if (pathCreator != null)
            {
                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
                transform.eulerAngles += new Vector3(0,0,90);
            }*/




           // temp1.transform.position = new Vector3(0,i -0.01f,0);
           //temp1.transform.position = new Vector3(0,0,i*i +0.06f);
              
            //obj= pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
            //temp1.transform.position = new Vector3(0,0,13+obj.y +value*4*value); //+i*4*i+12
            //temp1.transform.eulerAngles = new Vector3(0,i*8,0);

            /*if (Mathf.Abs(i) >= level * .3f && Mathf.Abs(i) <= level * .6f)
            {
                temp1.transform.eulerAngles = new Vector3(0,i*8,0);
                temp1.transform.eulerAngles += Vector3.up *180;
            }else if(Mathf.Abs(i) >= level * .8f)
            {
                temp1.transform.eulerAngles = new Vector3(0,i*8,0);

                if(random > .75f)
                   temp1.transform.eulerAngles += Vector3.up *180;
            }*/

            //temp1.transform.parent = FindObjectOfType<Rotator>().transform;
            
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void ModelSelection(){
        int randomModel =Random.Range(0,2);

        switch (randomModel)
        {
            case 0:
            for (int i = 0; i < 2; i++)
            {
                modelPrefab[i] = model[i];
            }
            break;
            case 1:
            for (int i = 0; i < 2; i++)
            {
                modelPrefab[i] = model[i];
            }
            break;
            case 2:
            for (int i = 0; i < 2; i++)
            {
                modelPrefab[i] = model[i];
            }
            break;
           /* case 3:
            for (int i = 0; i < 2; i++)
            {
                modelPrefab[i] = model[i +12];
            }
            break;
            case 4:
            for (int i = 0; i < 2; i++)
            {
                modelPrefab[i] = model[i + 16];
            }
            break;*/
        }
    }

   /* void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }*/
}
