using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{
    [SerializeField] private int _damage;
    [Header("Gradient color")]
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Color _color1;
    [SerializeField] private Color _color2;
    public int damage => _damage;
    [SerializeField] private TextMeshPro _blockText;
    private void OnValidate()
    {
        SetTextBlock();
    }
    private void Start()
    {
        SetColor();
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
    private void SetTextBlock()
    {
        _blockText.text = _damage.ToString();
    }
    private void SetColor()
    {
        _meshRenderer.material.color = Color.Lerp(_color1, _color2, _damage * 0.1f);
    }
}
