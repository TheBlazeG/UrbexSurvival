using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSight : MonoBehaviour
{
    [SerializeField]GameObject mouse;

    Player inputActions;
    private void Awake()
    {
        inputActions = new Player();
    }
    private void OnEnable()
    {
        inputActions.Enable();
        
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }


    void Update()
    {
        mouse.transform.position = inputActions.MouseAndKeyboard.Look.ReadValue<Vector2>();
    }

    void LookAtMouse(Vector3 target) 
    {
        float lookAngle = AngleBetweenTwoPoints(transform.position, target);

        
        transform.eulerAngles = new Vector3(0,0,lookAngle);
    }

    private float AngleBetweenTwoPoints(Vector3 a,Vector3 b)
    {
        return Mathf.Atan2(a.y-b.y,a.x-b.x)*Mathf.Rad2Deg;
    }
}
