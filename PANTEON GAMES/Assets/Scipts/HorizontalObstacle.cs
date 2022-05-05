using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HorizontalObstacle : MonoBehaviour
{

    

     void Start()
    {

        //transform.DOMoveX(-4.5f, 5f);

    }


     void Update()
    {


        if (transform.position.x == -4.5f)
        {
            transform.DOMoveX(3.5f, 2f);
        }

        if (transform.position.x == 3.50f)
        {

            transform.DOMoveX(4f,3f);

        }

         if (transform.position.x == 4f)
         {
            transform.DOMoveX(-4.5f, 1f);
         }

         if (transform.position.x == -4.25f)
        {
            transform.DOMoveX(3.5f, 4f);
        }

        if (transform.position.x == 4.25f)
        {
            transform.DOMoveX(3.5f, 4f);
        }
    }
}
