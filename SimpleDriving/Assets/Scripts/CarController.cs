using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{
    private Transform cachedTransform;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveSpeedGainOverTime;
    [SerializeField] private float turnSpeed = 200f;

    private int steerValue;

    void Start()
    {
        cachedTransform = transform;
    }

    void Update()
    {
        moveSpeed += moveSpeedGainOverTime * Time.deltaTime;

        cachedTransform.Rotate(0f, steerValue * turnSpeed * Time.deltaTime, 0f);

        cachedTransform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void Steer(int value)
    {
        steerValue = value;
    }
}
