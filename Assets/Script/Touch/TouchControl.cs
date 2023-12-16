using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    public FixedTouchField fixedTouchField;
    public Transform playerTransform;
    [SerializeField] private float limitValue;
    private float finalXPos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fixedTouchField.Presseds)
        {
            float halfScreen = Screen.width /2.3f ;
            float xPos = (fixedTouchField.TouchDistx - halfScreen) / halfScreen; 
            //540-540/540 = 0 middle of the screen
            //0-540/540 = -1 left edge of the screen
            //1080-540/540 = 1 right edge of the screen
            print(xPos);
            finalXPos = Mathf.Clamp(xPos * limitValue,-limitValue,limitValue);
            //print(xPos);

            //float yPOs =  (Input.mousePosition.y - Screen.height) / Screen.height;
            
             // xValueGet = finalXPos;


            playerTransform.localPosition = new Vector3(finalXPos,-0.8649288f,0);
            //playerTransform.position = fixedTouchField.TouchDist;
        }
         
    }
}
