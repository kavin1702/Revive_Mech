using UnityEngine;

public class CarMover : MonoBehaviour
{
    [SerializeField] Transform Car;
    private void Update()
    {
        Car.position = new Vector3 (-50,0,0);
        
    }


}

