// using UnityEngine;

// public class Weapon
// {
//     public enum WeaponType { Melee, Ranged };
//     public enum DamageType { Cutting, Crushing };
    

//     public float baseDamage;
//     public DamageType damageType;
//     public WeaponType weaponType;

//     public Weapon(float baseDamage, DamageType damageType, WeaponType weaponType)
//     {
//         this.baseDamage = baseDamage;
//         this.damageType = damageType;
//         this.weaponType = weaponType;
//     }
//         public float CalculateDamage()
//     {
//         float damageMultiplier = 1f + (level - 1) * 0.1f;
//         return baseDamage * damageMultiplier;
//     }

//     public void Attack()
//     {
//         float calculatedDamage = CalculateDamage();

//         switch (damageType)
//         {
//             case DamageType.Cutting:
//                 // Perform cutting attack
//                 Debug.Log($"Cutting attack! Damage: {calculatedDamage}");
//                 break;

//             case DamageType.Crushing:
//                 // Perform crushing attack
//                 Debug.Log($"Crushing attack! Damage: {calculatedDamage}");
//                 break;
//         }
//     }

// }

