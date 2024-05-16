// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;



// //     private void Attack()
// //     {
// //         if (meleeWeapon != null && meleeWeapon.weaponType == Weapon.WeaponType.Melee)
// //         {
// //             meleeWeapon.Attack();
// //         }
// //         else if (rangedWeapon != null && rangedWeapon.weaponType == Weapon.WeaponType.Ranged)
// //         {
// //             rangedWeapon.Attack();
// //         }
// //     }




// public class PlayerController : MonoBehaviour
// {
//     [Header("Movement")]
//     public float moveSpeed;

//     public float groundDrag;

//     public float jumpForce;
//     public float jumpCooldown;
//     public float airMultiplier;

//     private bool _isAvailableToJump;

//     [Header("Key bindings")]
//     public KeyCode jumpKey = KeyCode.Space;

//     [Header("Ground Check")]
//     public float playerHeight;

//     public LayerMask whatIsGround;
//     private bool _isOnGround;



    
//     public float meleeDamage;
//     public float rangedDamage;
//     // private CharacterController _charControler;
//     public Transform orientation;



//     private float _horizontalInput;
//     private float _verticalInput;

//     private Vector3 _movementDirection;

//     private Rigidbody _rigidBody;


    
//     // public WeaponSlot nearSlot;
//     // public WeaponSlot farSlot;

//     // public LayerMask weaponLayer; // Layer for weapons that the player can pick up

//     private void Start()
//     {
//         _rigidBody = GetComponent<Rigidbody>();
//         _rigidBody.freezeRotation = true;
//     //     // Initialize weapon slots
//     //     nearSlot = new WeaponSlot();
//     //     farSlot = new WeaponSlot();

//     //     // Initialize weapons in slots
//     //     nearSlot.SetWeapon(new Weapon(10f, Weapon.DamageType.Cutting, Weapon.WeaponType.Melee, 1));
//     //     farSlot.SetWeapon(new Weapon(8f, Weapon.DamageType.Crushing, Weapon.WeaponType.Ranged, 1));
//     }

//     private void InputFromDevice()
//     {
//         _horizontalInput = Input.GetAxisRaw("Horizontal");
//         _verticalInput = Input.GetAxisRaw("Vertical");

//         if (Input.GetKey(jumpKey) && _isOnGround && _isAvailableToJump)
//         {
//             _isAvailableToJump = false;

//             Jump();

//             Invoke(nameof(ResetJump), jumpCooldown);
//         }
//     }
//     void FixedUpdate()
//     {
//         PlayerMove();
//     }
//     private void Jump()
//     {
//         //reset velocity
//         // _rigidBody.velocity = new Vector3(_rigidBody.velocity, 0f, _rigidBody.velocity.z);

//         _rigidBody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
//     }

//     private void ResetJump()
//     {
//         _isAvailableToJump = true;
//     }

//     private void PlayerMove()
//     {
//         //Calculate direction
//         _movementDirection = orientation.forward * _verticalInput + orientation.right * _horizontalInput;

//         if (_isOnGround)
//             _rigidBody.AddForce(_movementDirection * moveSpeed * 10f, ForceMode.Force);
//         else if (!_isOnGround)
//             _rigidBody.AddForce(_movementDirection * moveSpeed * 10f * airMultiplier, ForceMode.Force);

//     }

//     private void ControlOfSpeed()
//     {
//         Vector3 clampVelocity = new Vector3(_rigidBody.velocity.x, 0f, _rigidBody.velocity.z);

//         // Velocity limit
//         if(clampVelocity.magnitude > moveSpeed)
//         {
//             Vector3 velocityLimited = clampVelocity.normalized * moveSpeed;
//             _rigidBody.velocity = new Vector3(velocityLimited.x, _rigidBody.velocity.y, velocityLimited.z);
//         }
//     }

//     void Update()
//     {     
//         // check ground
//         _isOnGround = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

//         InputFromDevice();
//         ControlOfSpeed();

//         if (_isOnGround)
//         {
//             _rigidBody.drag = groundDrag;

//         }
//         else _rigidBody.drag = 0;




        
//         // if (Input.GetMouseButtonDown(0))
//         // {
//         //     Attack(nearSlot);
//         // }

//         // if (Input.GetMouseButtonDown(0))
//         // {
//         //     Attack(farSlot);
//         // }

//         // if (Input.GetMouseButtonDown(1))
//         // {
//         //     Switch();
//         // }

//         // if (Input.GetKeyDown(KeyCode.E))
//         // {
//         //     // Check for nearby weapons to pick up
//         //     TryPickUpWeapon();
//         // }
//     }


// //     private void Attack(WeaponSlot slot)
// //     {
// //         if (slot != null && slot.HasWeapon())
// //         {
// //             slot.GetWeapon().Attack();
// //         }
// //     }

// //     private void Switch()
// //     {
// //         Debug.Log("Switching to melee");
// //         if (farSlot.Deactivate())
// //         {
// //             nearSlot.Activate();
// //         }
// //         else
// //         {
// //             farSlot.Activate();
// //         }
// //     }




// //     private void TryPickUpWeapon()
// //     {
// //         RaycastHit hit;
// //         if (Physics.Raycast(transform.position, transform.forward, out hit, 2f, weaponLayer))
// //         {
// //             WeaponPickup weaponPickup = hit.collider.GetComponent<WeaponPickup>();
// //             if (weaponPickup != null)
// //             {
// //                 Debug.Log($"Picked up weapon: {weaponPickup.weaponType}");
// //                 PickUpWeapon(weaponPickup.weapon);
// //             }
// //         }
// //     }

// //     private void PickUpWeapon(Weapon newWeapon)
// //     {
// //         // Determine whether to add the weapon to the near or far slot
// //         WeaponSlot targetSlot = (newWeapon.weaponType == Weapon.WeaponType.Melee) ? nearSlot : farSlot;

// //         // Check if the target slot already has a weapon, drop it if needed
// //         if (targetSlot.HasWeapon())
// //         {
// //             DropWeapon(targetSlot.GetWeapon());
// //         }

// //         // Set the new weapon to the target slot
// //         targetSlot.SetWeapon(newWeapon);
// //     }

// //     private void DropWeapon(Weapon weapon)
// //     {
// //         // Implement dropping logic here
// //         Debug.Log($"Dropped weapon: {weapon.weaponType}");
// //     }
// }
