using System.Collections.Generic;
using UnityEngine;

public class timerecord : MonoBehaviour
{

    List<Vector2> positions;
    List<Quaternion> rotations;
    List<Vector2> Velocities;
    List<float> angularVelocities;

    private Rigidbody2D _rb;
    private GameObject Player;
    private PlayerInteraction PlayerScript;
    // Start is called before the first frame update
    void Start()
    {
        positions = new List<Vector2>();
        rotations = new List<Quaternion>();
        Velocities = new List<Vector2>();
        angularVelocities = new List<float>();
        _rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindWithTag("Player");
        PlayerScript = Player.GetComponent<PlayerInteraction>();
        
    }

    void FixedUpdate()
    {
        if (InputManager._isShifting == true && PlayerScript._isGrounded2 == true)
        {
            Shift();
        }
        if (InputManager._isShifting == false || InputManager._isShifting == true && PlayerScript._isGrounded2 == false)
        {
            if (_rb.isKinematic == true)
            {
                _rb.isKinematic = false;
            }
            Record();
        }
    }

    void Shift()
    {
        if (positions.Count > 0 && rotations.Count > 0 && Velocities.Count > 0 && angularVelocities.Count > 0)
        {
            _rb.isKinematic = true;
            transform.position = positions[0];
            transform.rotation = rotations[0];
            _rb.velocity = Velocities[0];
            _rb.angularVelocity = angularVelocities[0];
            positions.RemoveAt(0);
            rotations.RemoveAt(0);
            Velocities.RemoveAt(0);
            angularVelocities.RemoveAt(0);
        }
    }

    void Record()
    {
        positions.Insert(0, transform.position);
        rotations.Insert(0, transform.rotation);
        Velocities.Insert(0, _rb.velocity);
        angularVelocities.Insert(0, _rb.angularVelocity);
    }
}
