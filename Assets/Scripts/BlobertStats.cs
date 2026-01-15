using System.Drawing;
using UnityEngine;

public class BlobertStats : MonoBehaviour
{
    
    // starting/max stats
    public float maxEnergy;
    public float maxSize;
    

    // changing stats
    public float energy;

    public bool canEat;
    public bool eat;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.localScale = new Vector3(50, 50, 50);
        energy = maxEnergy;
        canEat = true;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(energy);
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
