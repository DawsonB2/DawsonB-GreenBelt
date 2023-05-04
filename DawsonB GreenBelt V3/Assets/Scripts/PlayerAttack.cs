using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] float damage;
    BoxCollider2D attackCollider;
    // Start is called before the first frame update
    void Start()
    {
        attackCollider = GetComponent<BoxCollider2D>();
    }

    IEnumerator EnableCollider()
    {
        attackCollider.enabled = true;
        yield return new WaitForSeconds(1f);
        attackCollider.enabled = false;
    }

    public void Attack()
    {
        StartCoroutine("EnableCollider"); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("enemy"))
        {
            //deal dmg
        }
    }
}
