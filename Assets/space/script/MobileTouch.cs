using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileTouch : MonoBehaviour
{
    private float rotateSpeed = 10;


    private int isforward;
                          
    private Vector2 oposition1 = new Vector2();
    private Vector2 oposition2 = new Vector2();

    Vector2 m_screenPos = new Vector2();


    Vector3 viewVector;
    Vector3 viewUp;

    bool isEnlarge(Vector2 oP1, Vector2 oP2, Vector2 nP1, Vector2 nP2)
    {
        float leng1 = Mathf.Sqrt((oP1.x - oP2.x) * (oP1.x - oP2.x) + (oP1.y - oP2.y) * (oP1.y - oP2.y));
        float leng2 = Mathf.Sqrt((nP1.x - nP2.x) * (nP1.x - nP2.x) + (nP1.y - nP2.y) * (nP1.y - nP2.y));
        if (leng1 < leng2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Start()
    {
        Input.multiTouchEnabled = true;
        viewVector = transform.forward;
        viewUp = transform.up;
    }

    void Update()
    {
        if (Input.touchCount <= 0)
            return;
        if (Input.touchCount == 1) 
        {
            if (Input.touches[0].phase == TouchPhase.Began)
                m_screenPos = Input.touches[0].position;
            if (Input.touches[0].phase == TouchPhase.Moved)
            {
                Vector2 touch_delta = Input.touches[0].deltaPosition;
                if (touch_delta.magnitude <= 3f)
                {
                    return;
                }

                //log.text = "touch_delta.x = " + touch_delta.x + "  touch_delta.y = " + touch_delta.y;

                viewVector = Quaternion.AngleAxis(touch_delta.x * rotateSpeed * Time.deltaTime, transform.up) * viewVector;
                viewVector = Quaternion.AngleAxis(-touch_delta.y * rotateSpeed * Time.deltaTime, transform.right) * viewVector;

                transform.LookAt(transform.position + viewVector, viewUp);

                //transform.Translate(new Vector3(Input.touches[0].deltaPosition.x * Time.deltaTime, Input.touches[0].deltaPosition.y * Time.deltaTime, 0));
            }
            else if (Input.touches[0].phase == TouchPhase.Ended)
            {
                //log.text = "touch end";
            }

        }

        /*       else if (Input.touchCount > 1)
               {
                   Vector2 nposition1 = new Vector2();
                   Vector2 nposition2 = new Vector2();

                   Vector2 deltaDis1 = new Vector2();
                   Vector2 deltaDis2 = new Vector2();

                   for (int i = 0; i < 2; i++)
                   {
                       Touch touch = Input.touches[i];
                       if (touch.phase == TouchPhase.Ended)
                           break;
                       if (touch.phase == TouchPhase.Moved) 
                       {

                           if (i == 0)
                           {
                               nposition1 = touch.position;
                               deltaDis1 = touch.deltaPosition;
                           }
                           else
                           {
                               nposition2 = touch.position;
                               deltaDis2 = touch.deltaPosition;

                               if (isEnlarge(oposition1, oposition2, nposition1, nposition2)) 
                                   isforward = 1;
                               else
                                   isforward = -1;
                           }
                           oposition1 = nposition1;
                           oposition2 = nposition2;
                       }

        *//*               float delta_scale = isforward * (Mathf.Abs(deltaDis2.x + deltaDis1.x) + Mathf.Abs(deltaDis1.y + deltaDis2.y));
                       log.text = "delta_scale = " + delta_scale;

                       if (Mathf.Abs(pre_delata_scale - delta_scale) < 0.5f)
                       {
                           return;
                       }
                       pre_delata_scale = delta_scale;
                       Camera.main.fieldOfView += delta_scale;*//*
                       //Camera.main.transform.Translate(isforward * Vector3.forward * Time.deltaTime * (Mathf.Abs(deltaDis2.x + deltaDis1.x) + Mathf.Abs(deltaDis1.y + deltaDis2.y)));
                   }
               }*/
    }

    //private float pre_delata_scale = 0;

}

