using UnityEngine;

public class TailDestroy : MonoBehaviour
{
    [SerializeField] ParticleSystem _particleSystem;

    public void DestroyTail()
    {
        //PlayParticle();
        Invoke("Destroy",1f);
    }
    public void PlayParticle()
    {
        _particleSystem.Play();
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
