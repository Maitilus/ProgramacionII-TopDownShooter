using System.ComponentModel;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables

    [Header("Player Stats")]
    public float MoveSpeed;
    [Tooltip("Movement Speed of the Character")]
    public float Health = 100;
    [Tooltip("The Ammount of hitpoints of the player")]

    [Header("PlayerLinks")]
    public Rigidbody2D rb;
    [Tooltip("Link the RigidBody2D")]

    public Weapon Weapon;
  
    private Vector2 MoveDirection;
    private Vector2 MousePosition;

    #endregion

    void Update()
    {
        float MoveX = Input.GetAxisRaw("Horizontal");
        float MoveY = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButton(0) && Weapon.CanFire)
        {
            StartCoroutine(Weapon.Fire());
        }

        MoveDirection = new Vector2(MoveX, MoveY).normalized;
        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        //Set Player velocity
        rb.linearVelocity = new Vector2(MoveDirection.x * MoveSpeed, MoveDirection.y * MoveSpeed);

        //Modify Player Aim With Cursor
        Vector2 AimDirection = MousePosition - rb.position;
        float AimAngle = Mathf.Atan2(AimDirection.y, AimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = AimAngle;
    }
}