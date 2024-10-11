using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float healthChangeDelay = 0.5f;

    StatHandler statHandler;

    public float currentHP { get; private set; }
    public float maxHP => statHandler.CurrentStat.maxHP;

    private float timeSinceLastChange = float.MaxValue;
    private bool isAttacked = false;

    public event Action OnDamage;
    public event Action OnHeal;
    public event Action OnDeath;
    public event Action OnInvincibilityEnd;


    private void Awake()
    {
        statHandler = GetComponent<StatHandler>();
    }

    private void Start()
    {
        currentHP = maxHP;
    }

    private void Update()
    {
        if (isAttacked && timeSinceLastChange < healthChangeDelay)
        {
            timeSinceLastChange += Time.deltaTime;
            if (timeSinceLastChange >= healthChangeDelay)
            {
                OnInvincibilityEnd?.Invoke();
                isAttacked = false;
            }
        }
    }

    private bool ChangeHealth(float amount)
    {
        if(timeSinceLastChange < healthChangeDelay)
        {
            return false;
        }

        timeSinceLastChange = 0;
        currentHP += amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);

        if(currentHP <= 0)
        {
            OnDeath?.Invoke();
            return true;
        }
        if(amount > 0)
        {
            OnHeal?.Invoke();
        }
        else
        {
            OnDamage?.Invoke();
            isAttacked = true;
        }
        return true;
    }
}