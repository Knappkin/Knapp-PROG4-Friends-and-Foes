using UnityEngine;

public class KibbleSpawner : MonoBehaviour
{
    public GameObject kibblePrefab;
    private float dropHeight = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject kibbleInstance;
            kibbleInstance = Instantiate(kibblePrefab);
            kibbleInstance.transform.position = new Vector3(0, dropHeight, 0);
        }
    }
}
