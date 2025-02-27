using UnityEngine;
using UnityEngine.UIElements;
public abstract class Character : MonoBehaviour 
{
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected float movementSpeed;  // maybe define this from the player?
    [SerializeField] private GameObject dieEffect;
    [SerializeField] protected float health = 12f;

    public Health HealthValue;
    public Weapon CurrentWeapon;       // could have weapon only in children that have weapons

    protected virtual void Start()
    {

        HealthValue = new Health(health);

        // subscribecharacter to OnDied event
        HealthValue.OnDied.AddListener(CharacterDied);
       
    }

    public virtual void Move(Vector2 direction)
    {
        rb.AddForce(direction * movementSpeed * Time.deltaTime, ForceMode2D.Impulse);
    }

    public virtual void CharacterDied()
    {
        Instantiate(dieEffect, transform.position, Quaternion.identity);
        AudioManager.Instance.PlaySFX("Explosion");
        Destroy(gameObject);
    }

    // rotate character to face mouse
    public virtual void Look(Vector2 direction)
    {
        // get the angle of rotation and convert to degrees
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //_rb.SetRotation(angle - 90f);

        // alternative method
        float angle = Vector2.SignedAngle(Vector2.up, direction);
        rb.SetRotation(angle);
    }

    public virtual void Attack() // attack instatiates the bullet
    {

    }

    public virtual void StartAttack() // as i press the mouse down
    {

    }

    public virtual void StopAttack() // as i release the mouse button
    {

    }

}
