using UnityEngine;

//This script manages the behavior of individual obstacle
public class Obstacle : MonoBehaviour
{
    [SerializeField] private float Speed = 3;
    void Update()
    {
        PosCheck();
    }
    private void PosCheck()
    {
        if (transform.position.x <= -8)
        {
            Player.AddScore(1);
            Debug.Log("added score");
            Destroy(gameObject);
        }
        else
            transform.Translate(Vector3.right * Time.deltaTime * -Speed);
    }
}
