using UnityEngine;
using UnityEngine.InputSystem;

public class WheelScript : MonoBehaviour
{
    private WheelJoint2D wheel;
    private JointMotor2D motor;
    public float speed = 0f;
    InputAction accelerateAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wheel = GetComponent<WheelJoint2D>();
        motor = wheel.motor;

        accelerateAction = InputSystem.actions.FindAction("Accelerate");
        accelerateAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        float hForce = accelerateAction.ReadValue<float>();
        motor.motorSpeed = speed * hForce;

        wheel.motor = motor;
    }

    void OnDisable()
    {
        accelerateAction.Disable();
    }

}
