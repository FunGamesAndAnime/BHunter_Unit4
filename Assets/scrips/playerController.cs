using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody rbplayer;
    public float speed = 10.0f;
    GameObject focalPiont;
    Renderer rplayer;
    private bool hasPowerup = false;
    public float powerupspeed = 10.0f;
    public GameObject powerupinde;
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
        rbplayer.AddForce(focalPiont.transform.forward * magnitude, ForceMode.Force);
        if (forwardInput > 0)
        {
         rplayer.material.color = new Color(1.0f - forwardInput, 1.0f, 1.0f - forwardInput);
        }
        else
        {
            rplayer.material.color = new Color(1.0f + forwardInput, 1.0f, 1.0f + forwardInput);
        }
        powerupinde.transform.position = transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("powerup"))
        {

            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(powerUpCountDown());
            powerupinde.SetActive(true);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (hasPowerup && collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("player has collid with" + collision.gameObject + "with powerup set to:" + hasPowerup);
            Rigidbody rbEnemy = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awydir = collision.gameObject.transform.position - transform.position;
           rbEnemy.AddForce(awydir * powerupspeed, ForceMode.Impulse); 
        }
    }
    IEnumerator powerUpCountDown()
    {
        yield return new WaitForSeconds(8);
        hasPowerup = false;
        powerupinde.SetActive(false);

    }
}
