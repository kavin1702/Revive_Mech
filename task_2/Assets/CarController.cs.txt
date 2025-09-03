using UnityEngine;

public class CarController : MonoBehaviour
{
    public float moveSpeed = 50;
    public float steerAngle = 20;
    public float traction = 1;
    public float maxSpeed = 15;
    private Vector3 moveForce;
    public float drag = 0.98f;
    public float brakeStrength = 0.9f;

    void Update()
    {
        moveForce += transform.forward * moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.position += moveForce * Time.deltaTime;

        float steerInput = Input.GetAxis("Horizontal");

        float direction;
        if (Vector3.Dot(moveForce, transform.forward) >= 0)
        {
            direction = 1f;
        }
        else
        {
            direction = -1f;
        }

        transform.Rotate(Vector3.up * steerInput * direction * moveForce.magnitude * steerAngle * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space))
        {
            moveForce *= 1 - brakeStrength * Time.deltaTime;
        }
        else
        {
            moveForce *= drag;
        }

        moveForce = Vector3.ClampMagnitude(moveForce, maxSpeed);
        moveForce = Vector3.Lerp(moveForce.normalized, transform.forward, traction * Time.deltaTime) * moveForce.magnitude;
    }
}
