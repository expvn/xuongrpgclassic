using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;

    private Vector2 direction;
    public float speed = 5f;
    private int current = 0;

    private Vector2 currentDirection;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        

        anim.SetFloat("runX", direction.x);
        anim.SetFloat("runY", direction.y);
        anim.SetFloat("velocity", rig.velocity.magnitude);

        if (direction != Vector2.zero)
        {
            currentDirection = direction;
        }

        anim.SetFloat("dirX", currentDirection.x);
        anim.SetFloat("dirY", currentDirection.y);

        direction.Normalize();
    }

    private void FixedUpdate()
    {
        rig.velocity = direction * speed;
    }

    private void OnMouseDrag()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = pos;
    }

    public void PlayerAnimation()
    {
        if (rig.velocity.magnitude > 0)
        {
            if (direction.x > 0 && direction.y == 0) { anim.Play("PlayerRunE"); current = 1; }
            if (direction.x > 0 && direction.y > 0) { anim.Play("PlayerRunNE"); current = 2; }
            if (direction.x > 0 && direction.y < 0) { anim.Play("PlayerRunSE"); current = 3; }

            if (direction.x < 0 && direction.y == 0) { anim.Play("PlayerRunW"); current = 4; }
            if (direction.x < 0 && direction.y > 0) { anim.Play("PlayerRunNW"); current = 5; }
            if (direction.x < 0 && direction.y < 0) { anim.Play("PlayerRunSW"); current = 6; }

            if (direction.x == 0 && direction.y > 0) { anim.Play("PlayerRunN"); current = 7; }
            if (direction.x == 0 && direction.y < 0) { anim.Play("PlayerRunS"); current = 8; }
        }
        else
        {
            switch (current)
            {
                case 1: anim.Play("PlayerStaticE"); break;
                case 2: anim.Play("PlayerStaticNE"); break;
                case 3: anim.Play("PlayerStaticSE"); break;
                case 4: anim.Play("PlayerStaticW"); break;
                case 5: anim.Play("PlayerStaticNW"); break;
                case 6: anim.Play("PlayerStaticSW"); break;
                case 7: anim.Play("PlayerStaticN"); break;
                case 8: anim.Play("PlayerStaticS"); break;
            }
        }
    }
}