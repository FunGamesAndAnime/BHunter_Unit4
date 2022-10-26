using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody rbplayer;
    public float speed = 10.0f;
    GameObject focalPiont;
    Renderer rplayer;
    // Start is called before the first frame update
    void Start()
    {
       rbplayer = GetComponent<Rigidbody>();
        rplayer = GetComponent<Renderer>();
        focalPiont = GameObject.Find("focal piont");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float magnitude = forwardInput * speed * Time.deltaTime;
        rbplayer.AddForce(focalPiont.transform.forward * magnitude, ForceMode.Impulse);
        if (forwardInput > 0)
        {
         rplayer.material.color = new Color(1.0f - forwardInput, 1.0f, 1.0f - forwardInput);
        }
        else
        {
            rplayer.material.color = new Color(1.0f + forwardInput, 1.0f, 1.0f + forwardInput);
        }
    }
}
