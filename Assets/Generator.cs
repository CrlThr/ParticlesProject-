using Unity.VisualScripting;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] public Particle ParticlePrefabs;

    [SerializeField] private float minSpeedParticle;
    [SerializeField] private float maxSpeedParticle;
    [SerializeField] private float minTimeToLive;
    [SerializeField] private float maxTimeToLive;


    public float spawnInterval = 0.02f;

    private float timer = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0;

            CreateParticle();
        }

    }

    void CreateParticle()
    {
        Particle particle = Instantiate(ParticlePrefabs, transform);

        particle.Init(
            Random.onUnitSphere
            , Random.Range(minSpeedParticle, maxSpeedParticle)
            , Random.Range(minTimeToLive, maxTimeToLive)
            , Random.ColorHSV());
     }
      
}




