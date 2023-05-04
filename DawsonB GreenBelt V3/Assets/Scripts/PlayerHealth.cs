using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health;
    private bool alive;
    private bool canTakeDamage;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim =  GetComponent<Animator>();
        if(health== 0)
        {
            health = 100;
        }
         alive = true;
        canTakeDamage = true;

        
    }

    IEnumerator DamageCooldown()
    {
        canTakeDamage= false;
        yield return new WaitForSeconds(1f);
        canTakeDamage = true;
    }
    public  void Block()
    {
        canTakeDamage=false;
    }

    public void Unblock()
    {
        canTakeDamage=true;
    }

    public void SetAlive(bool state)
    {
        alive = state;
        if(alive ==  false)
        {

        }
    }

    public void SetHealth(float amount)
    {
        if (canTakeDamage)
        {
            StartCoroutine("DamageCooldown");
            health += amount;
            if(health <=0)
            {
                SetAlive(false);
            }

            if(amount <0)
            {
                anim.SetTrigger("Hurt");
            }

        }
    }
    public float GetHealth()
    { return health; }

    public bool GetAlive()
    {
        return alive;
    }
}
