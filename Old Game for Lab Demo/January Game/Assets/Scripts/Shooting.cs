using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEditor.Experimental.GraphView;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private InputAction attackAction;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    [SerializeField] float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackAction = InputSystem.actions.FindAction("Attack");
    }

    // Update is called once per frame
    void Update()
    {
        // adds cooldown for each bullet, preventing rapid fire
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        // to make bullet fire
        if (attackAction.WasPressedThisFrame() && canFire && !EventSystem.current.IsPointerOverGameObject())  //(attackAction.IsPressed() && canFire)
        {
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            animator.SetBool("isShooting", true);    
        }
        else
        {
            animator.SetBool("isShooting", false);
        }
    }
}


