using UnityEngine;

public class SoulEnemy : MonoBehaviour, IEnemy
{
    [SerializeField] private GameObject InteractionPanelObject;
    [SerializeField] private GameObject ActionsPanelObject;
    [SerializeField] private SpriteRenderer EnemySpriteRenderer;

    private SpawnPoint EnemyPosition;

    public void SetupEnemy(Sprite sprite, SpawnPoint spawnPoint)
    {
        EnemySpriteRenderer.sprite = sprite;
        EnemyPosition = spawnPoint;
        gameObject.SetActive(true);
    }

    public SpawnPoint GetEnemyPosition()
    {
        return EnemyPosition;
    }

    public GameObject GetEnemyObject()
    {
        return gameObject;
    }

    private void ActiveCombatWithEnemy()
    {
        ActiveInteractionPanel(false);
        ActiveActionPanel(true);
    }

    private void ActiveInteractionPanel(bool active)
    {
        InteractionPanelObject.SetActive(active);
    }

    private void ActiveActionPanel(bool active)
    {
        ActionsPanelObject.SetActive(active);
    }

    private void UseBow()
    {
        GameEvents.EnemyKilled?.Invoke(this);
    }

    private void UseSword()
    {
        GameEvents.EnemyKilled?.Invoke(this);
    }

    #region OnClicks
    public void Combat_OnClick()
    {
        ActiveCombatWithEnemy();
    }

    public void Bow_OnClick()
    {
        UseBow();
    }

    public void Sword_OnClick()
    {
        UseSword();
    }
    #endregion
}
