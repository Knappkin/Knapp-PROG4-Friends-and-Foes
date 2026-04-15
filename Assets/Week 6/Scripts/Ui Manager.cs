using UnityEngine;
using UnityEngine.UI;
public class UiManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Image exclamationImagePrefab;
    public Canvas canvas;

    public GameObject targetTardigrade;
    public float exclamationOffset;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void DrawExclamationUI(Transform tardigrade)
    {
        Vector3 displayPos = tardigrade.position;
        displayPos.y += exclamationOffset;
        Image excInstance = Instantiate(exclamationImagePrefab, displayPos, Quaternion.identity, canvas.transform);
        Destroy(excInstance, 3f);
    }
}
