using System.Drawing;
using UnityEngine;

public class BlobertStats : MonoBehaviour
{
    
    // starting/max stats
    public float maxEnergy;
    public float startSize;
    public float maxSize;
    public float wakeUpThreshold;

    // changing stats
    public float energy;
    public float size;

    public bool canEat;
    public bool eat;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.localScale = new Vector3(100, 100, 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 6)
        {
            Debug.Log("OMNOMNOM");
        
        if (canEat) 
        {
            eat = true;
        }

        Destroy(collision.gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Debug.Log("OMNOMNOM");

            if (canEat)
            {
                eat = true;
            }

            Destroy(other.gameObject);
        }
    }
}
