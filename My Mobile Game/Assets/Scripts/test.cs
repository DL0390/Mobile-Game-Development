//using UnityEngine;

//public class BikeControlle : MonoBehaviour
//{
//    public float speed = 0f;
//    public float maxspeed = 400f;
//    public Rigidbody2D rb;
//    public float accelerationspeed;
//    public float mover;

//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        mover = Input.GetAxisRaw("Horizontal");

//        if (mover != 0f && speed < maxspeed)
//        {
//            speed += Time.deltaTime + accelerationspeed;
//        }

//        if (mover == 0f)
//        {
//            speed = 0f;
//        }

//    }
//}
