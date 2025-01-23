using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class PickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if(collision.attachedRigidbody.CompareTag("Player"))
        {
            Debug.Log(collision.attachedRigidbody.GetComponent<Player>());
            PickMeUp(collision.attachedRigidbody.GetComponent<Player>());

            AudioManager.Instance.PlaySFX("PickUp");

            Destroy(gameObject);
        }
    }

    protected abstract void PickMeUp(Player playerInTrigger);
}
