using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Vector3 direction;
    public float gravity = -9.8f;
    public float strenght = 5f;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        { 
         direction = Vector3.up * strenght;
        }
    }
}
