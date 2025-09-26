using UnityEngine;
using System.Collections.Generic;

public class Generator : MonoBehaviour
{
    [Header("Particle Settings")]
    [SerializeField] public Particle ParticlePrefabs;

    [SerializeField] private float minSpeedParticle;
    [SerializeField] private float maxSpeedParticle;
    [SerializeField] private float minTimeToLive;
    [SerializeField] private float maxTimeToLive;

    [Header("Spawn Settings")]
    [SerializeField] private float spawnInterval = 0.02f;
    [SerializeField] private int maxParticles = 100;
    [SerializeField] private bool spawnAllAtOnce = false;

    private float timer = 0f;
    private int currentParticleCount = 0;

    private List<Particle> spawnedParticles = new(); // Optionals

    public enum MovementType
    {
        Linear,
        Tornado
    }

    [SerializeField] private MovementType movementType = MovementType.Linear;

    public MovementType GetMovementType()
    {
        return movementType;
    }

    void Start()
    {
    }

    void Update()
    {
        if (spawnAllAtOnce)
        {
            if (currentParticleCount == 0)
            {
                for (int i = 0; i < maxParticles; i++)
                {
                    CreateParticle();
                }
            }

            return; // skip interval spawning
        }

        if (currentParticleCount < maxParticles)
        {
            timer += Time.deltaTime;

            if (timer >= spawnInterval)
            {
                timer = 0f;
                CreateParticle();
            }
        }
    }

    void CreateParticle()
    {
        if (currentParticleCount >= maxParticles)
            return;

        Particle particle = Instantiate(ParticlePrefabs, transform);

        particle.Init(
            Random.onUnitSphere,
            Random.Range(minSpeedParticle, maxSpeedParticle),
            Random.Range(minTimeToLive, maxTimeToLive),
            Random.ColorHSV());

        currentParticleCount++;
        spawnedParticles.Add(particle);
    }

    public void OnParticleDestroyed(Particle p)
    {
        currentParticleCount--;
        spawnedParticles.Remove(p);
    }
}
