using UnityEngine;
public class BuildSpikes : BaseBuild
{

    [SerializeField] private SpriteRenderer _spikeRenderer;
    [SerializeField] private BoxCollider2D _collider;

    [SerializeField, Range(1, 20)] private int spikeCount = 3;

    public override void UpdateLayout()
    {
        float width = (float)spikeCount / 3;
        _spikeRenderer.size = new Vector2(width, _spikeRenderer.size.y);

        _collider.size = new Vector2(width, _collider.size.y);
    }
}
