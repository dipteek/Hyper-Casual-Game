using System.Collections;
using System.Collections.Generic;
using PathCreation;
using PathCreation.Examples;
using UnityEngine;

public class LvelManagerAdvance :  PathSceneTool
{
    public GameObject[] model;
   // [HideInInspector]
    public GameObject[] modelPrefab = new GameObject[6];

    private GameObject temp1,temp2;
    public Vector3 obj;
    public int level = 1, addOn = 7;
     float i =0;
     float distanceTravelled;
     public EndOfPathInstruction endOfPathInstruction;
     public float speed = 5;
     public PathCreator pathCreator;

     public GameObject coin;

     
     public GameObject prefab;
        public GameObject holder;
        public float spacing = 8;

        const float minSpacing = .1f;

        const float minCoinSpacing = .1f;

        public float coinSpacing = 11;
        public GameObject coinHolder;

        private int startRange;

        private int endRange;

        private int gameObjectLength;


     

     PathFollower pathFollower;
    // Start is called before the first frame update
    void Start()
    {
        
        if (pathCreator != null)
        {
            DestroyObjects ();
            DestroyCoins();
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
        }
        level = PlayerPrefs.GetInt("Level",1);
        if (level > 9){
            addOn = 0;
            
        }

        if(level <= 8){
            gameObjectLength = 4;
        }else if (level <= 16)
        {
            gameObjectLength = 5;
        }else if (level <= 32)
        {
            gameObjectLength = 6;
        }else if (level <= 32){
            gameObjectLength = 7;
        }else{
            gameObjectLength = 8;
        }

        

        ModelSelection();
        float random = Random.value;
        for ( i = 0; i > -level -addOn; i -= 0.5f){
            float j = i-i-i;
           // check print("i ="+ j);
           // print("i positive ="+i);
           // print("level :"+ -level +"addOn "+ -addOn);
           // print(-level -addOn);

            if(level <= 8){
                //temp1 = Instantiate(modelPrefab[Random.Range(0,2)]);
                startRange = 0;
                endRange = 2;
            }
            if(level > 8 && level <= 16){
                startRange = 0;
                endRange = 3;
                //temp1 = Instantiate(modelPrefab[Random.Range(1,3)]);
            }
            if(level > 16 && level <= 32){
                startRange = 1;
                endRange = 4;
                //temp1 = Instantiate(modelPrefab[Random.Range(1,3)]);
            }
                 
            if(level > 32 && level <= 40){
                startRange = 2;
                endRange = 5;
                //temp1 = Instantiate(modelPrefab[Random.Range(2,4)]);
            }

            if(level > 40 && level <= 100){
                startRange = 3;
                endRange = 7;
                //temp1 = Instantiate(modelPrefab[Random.Range(2,4)]);
            }
                 
            if(level > 100){
                startRange = 3;
                endRange = 8;
                //temp1 = Instantiate(modelPrefab[Random.Range(3,4)]);
            }
                 



                 

                

                 if (pathCreator != null){
                    distanceTravelled += speed * Time.deltaTime;
                 //obj= pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                 //temp1.transform.position = new Vector3(obj.x,0,obj.y + j *12); //+i*4*i+12
                 // temp1.transform.eulerAngles = new Vector3(0,i*8,0);
                 }

                 
                
                 


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
        }

        levelOneToTwenty();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ModelSelection(){
        modelPrefab = new GameObject[gameObjectLength];
        int randomModel =Random.Range(0,3);
        print("random "+randomModel);
        
        switch (randomModel)
        {
            case 0:
            for (int i = 0; i < gameObjectLength; i++)
            {
                //print("i am getting index 0 "+i);
                modelPrefab[i] = model[i];
                // check print("modelPrefab[i]: "+modelPrefab[i].name + model[i].name);
            }
            break;
            case 1:
            for (int i = 0; i < gameObjectLength; i++)
            {
                //print("i am getting index  1 "+i);
                modelPrefab[i] = model[i];
                //print(model.Length + "i am getting index name "+modelPrefab[i].name + " length "+modelPrefab.Length);
               // print("modelPrefab[i]: "+modelPrefab[i].name + model[i].name);
            }
            break;
            case 2:
            for (int i = 0; i < gameObjectLength; i++)
            {
                //print("i am getting index 2 "+i);
                modelPrefab[i] = model[i+1];
                //print("modelPrefab[i]: "+modelPrefab[i].name + model[i].name);
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

    void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }

        void DestroyObjects () {
            int numChildren = holder.transform.childCount;
            for (int i = numChildren - 1; i >= 0; i--) {
                DestroyImmediate (holder.transform.GetChild (i).gameObject, false);
                //DestroyImmediate (coinHolder.transform.GetChild (i).gameObject, false);
            }
        }

        void DestroyCoins () {
            int numChildren = coinHolder.transform.childCount;
            for (int i = numChildren - 1; i >= 0; i--) {
                DestroyImmediate (coinHolder.transform.GetChild (i).gameObject, false);
                //DestroyImmediate (coinHolder.transform.GetChild (i).gameObject, false);
            }
        }

        protected override void PathUpdated () {
            if (pathCreator != null) {
                Start ();
            }
        }



        void levelOneToTwenty(){
            VertexPath path = pathCreator.path;

                spacing = Mathf.Max(minSpacing, spacing);
                float dst = 0;

                //float yAxis = 0.5f;

                

                while (dst < path.length) {
                    
                    Vector3 point = path.GetPointAtDistance (dst);
                    Vector3 newTest = path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                    Quaternion rot = Quaternion.identity; //path.GetRotationAtDistance (dst)
                    Quaternion rotationForCoin = Quaternion.Euler(-90,-2.5f,-177.92f); //path.GetRotationAtDistance (dst)
                    
                   // temp1.transform.position = new Vector3(point.x,0,point.y +point.z + spacing /*j *12*/);
                   //temp1.transform.position = new Vector3(newTest.x,newTest.y,newTest.z);

                   Vector3 enemyObj =new Vector3(point.x,0.05f,point.z + spacing);

                   // coin
                   coinSpacing  = Mathf.Max(minCoinSpacing, coinSpacing);
                   float randomCoinLocation = Random.Range(-1.3f,1.3f) /*Mathf.Max(0.0f, 1.3f)*/;
                   Vector3 coinObject =new Vector3(randomCoinLocation,0.5f,point.z + coinSpacing);
                   
                    //
                    if (pathCreator != null)
                    {
                        if(enemyObj.z < path.length){

                            GameObject tempGameObject;
                            tempGameObject = modelPrefab[Random.Range(startRange,endRange)];
                            if(tempGameObject.name == "hammer not 2"){
                                 enemyObj =new Vector3(point.x - 0.65f,0.05f,point.z + spacing);
                                Instantiate (/*temp1*/tempGameObject, enemyObj, rot, holder.transform);
                            }else if (tempGameObject.name == "Obstacle 13 V4")
                            {
                                enemyObj =new Vector3(point.x + 1.4f,0.05f,point.z + spacing);
                                Instantiate (/*temp1*/tempGameObject, enemyObj, rot, holder.transform);
                            }else if (tempGameObject.name == "Obstacle 23 V4")
                            {
                                //Quaternion rotForObs1 = Quaternion.Euler(0,0,0);
                                enemyObj =new Vector3(point.x - 1.4f,0.05f,point.z + spacing);
                                Instantiate (/*temp1*/tempGameObject, enemyObj, rot/* * Quaternion.Inverse(rotForObs1)*/, holder.transform);
                            }else{
                                 Instantiate (/*temp1*/tempGameObject, enemyObj, rot, holder.transform);
                            }
                            
                        }
                        
                        if (coinObject.z < path.length)
                        {
                            Instantiate (coin, coinObject, rotationForCoin, coinHolder.transform);
                        }
                        
                        //temp1 = Instantiate(modelPrefab[Random.Range(0,2)]);
                    //temp1.transform.position = point; 
                    }
                    
                 //temp1.transform.localPosition = point;
                    dst += spacing;
                }
        }
}
