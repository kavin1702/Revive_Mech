using UnityEngine;

public class CarMover : MonoBehaviour
{
    [SerializeField] Transform Car;
    private void Update()
    {
        Car.position = new Vector3 (-50,0,0);
        
    }

//    public float speed = 10f;

//    void FixedUpdate()
//    {
//        GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * speed * Time.fixedDeltaTime);
//    }
}

