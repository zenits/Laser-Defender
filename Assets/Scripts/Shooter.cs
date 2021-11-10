using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float baseFiringRate = 0.2f;

    [Header("AI")]
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimumFiringRate = 0.2f;
    [SerializeField] bool useAI;


    [HideInInspector]
    public bool isFiring = false;
    Coroutine fireCoroutine;
    AudioPlayer audioPlayer;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring && fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }

    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            var instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            var rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.velocity = transform.up * projectileSpeed;
            Destroy(instance, projectileLifetime);
            audioPlayer.PlayShotingClip();
            yield return new WaitForSeconds(GetRandomFiringRate());
        }

    }


    public float GetRandomFiringRate()
    {
        float rate = Random.Range(baseFiringRate - firingRateVariance, baseFiringRate + firingRateVariance);
        return Mathf.Clamp(rate, minimumFiringRate, float.MaxValue);
    }
}
