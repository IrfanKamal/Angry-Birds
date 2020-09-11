using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlBird : Bird
{
    public float blastRadius;
    public float blastTime;
    public SpriteRenderer spriteRenderer;

    // Ketika bertabrakan dengan obstacle atau enemy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        if(tag == "Enemy" || tag == "Obstacle")
        {
            RigidBody.velocity = Vector2.zero;
            spriteRenderer.enabled = false;
            RigidBody.bodyType = RigidbodyType2D.Kinematic;
            StartCoroutine(Blast());
        }
    }

    // Meledak dengan membesarkan collider
    IEnumerator Blast()
    {
        Collider.radius = blastRadius;
        yield return new WaitForSeconds(blastTime);
        Destroy(gameObject);
    }
}
