using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{

Collider2D swordCollider;
    // Start is called before the first frame update
    void Start()
    {
        swordCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
   public void AttackRight(){
   swordCollider.enabled = true;
   }
   
    public void AttackLeft(){
   swordCollider.enabled = true;
   }
   
    public void StopAttack(){
   swordCollider.enabled = false;
   }
}
