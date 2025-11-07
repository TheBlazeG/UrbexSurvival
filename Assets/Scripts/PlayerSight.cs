using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSight : MonoBehaviour
{

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
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(inputActions.MouseAndKeyboard.Look.ReadValue<Vector2>());
        LookAtMouse(mousePosition);
    }

    void LookAtMouse(Vector3 target) 
    {
        float lookAngle = AngleBetweenTwoPoints(transform.position, target)+90;

        
        transform.eulerAngles = new Vector3(0,0,lookAngle);
    }

    private float AngleBetweenTwoPoints(Vector3 a,Vector3 b)
    {
        return Mathf.Atan2(a.y-b.y,a.x-b.x)*Mathf.Rad2Deg;
    }
}
