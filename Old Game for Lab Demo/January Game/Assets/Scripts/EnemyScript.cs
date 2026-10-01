using UnityEngine;
using System.Collections;
using JetBrains.Annotations;
public class EnemyScript : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private Animator animator;
    public GameObject Player;
    public float speed;
    public float ReturnDistance;
    public float StopDistance;
    public bool flee = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // makes enemy face player at all times
        Vector3 direction = Player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        
        float distance = Vector2.Distance(transform.position, Player.transform.position);

        // removes 'jittery' behaviour on collision
        if (distance <= StopDistance) return;


        if (!flee)
        {
            // makes enemy follow player at all times
            Vector2 toPlayer = (Player.transform.position - transform.position);
            rb.linearVelocity = toPlayer.normalized * speed;
            animator.SetBool("IsWalking", true);
        }
        else
        {
            // makes enemy flee temporarily after striking player
            if (distance > ReturnDistance) flee = false;
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, -1 * speed * Time.deltaTime);
            animator.SetBool("IsWalking", false);
        }

    }

    public void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            flee = true;
        }

    }

}