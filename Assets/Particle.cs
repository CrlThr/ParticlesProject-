using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Particle : Generator
{
    private Vector3 direction;
    private float speed;
    float time;
    private float TimeToLive;

    private Vector3 _direction;
    private float _speed;
    private float _TimeToLive;
    private float force = 10f;
  

    List<ParticleModule> modules = new List<ParticleModule>();

    public void Init(Vector3 direction, float speed, float timeToLive, Color color)
    {

        time = 0;

        _direction = direction;
        _speed = speed;
        _TimeToLive = timeToLive;
       

        LifecycleModule lifecycleModule = new LifecycleModule();
        lifecycleModule.Init(this);
        modules.Add(lifecycleModule);

        MovementModule movementModule = new MovementModule();
        movementModule.Init(this);
        modules.Add(movementModule);

        VisualModule visualModule = new VisualModule();
        visualModule.Init(this);
        modules.Add(visualModule);


       
    }

    public void ApplyForce(Vector3 force)
    {
        transform.position += force * Time.deltaTime;
    }

    //Update is called once per frame
    void Update()
    {
        EffectArea[] areas = GameObject.FindObjectsByType<EffectArea>(FindObjectsSortMode.None);
        foreach (EffectArea area in areas)
        {
            area.ApplyEffect(this);
        }

        for (int i = 0; i < modules.Count; i++)
        {
            modules[i].Update(Time.deltaTime);
        }

    }
}
