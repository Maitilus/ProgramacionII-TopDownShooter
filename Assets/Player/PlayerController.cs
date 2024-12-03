using System.ComponentModel;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables

    [Header("Player Stats")]
    public float MoveSpeed;
    [Tooltip("Movement Speed of the Character")]

    [Header("PlayerLinks")]
    public Rigidbody2D rb;
    [Tooltip("Link the RigidBody2D")]

    public Weapon Weapon;
  
    public Vector2 PlayerInput;
    private Vector2 MousePosition;
    public Transform Crosshair;


    #endregion

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        PlayerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (Input.GetMouseButton(0) && Weapon.CanFire)
        {
            StartCoroutine(Weapon.Fire());
        }
    }
    void FixedUpdate()
    {
        Vector2 moveForce = PlayerInput * MoveSpeed;
        rb.linearVelocity = moveForce;          


        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Crosshair.position = MousePosition;

        Vector2 AimDirection = MousePosition - rb.position;
        float AimAngle = Mathf.Atan2(AimDirection.y, AimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = AimAngle;
    }
}