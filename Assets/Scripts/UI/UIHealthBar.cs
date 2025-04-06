using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIHealthBar : MonoBehaviour
{
    public Image bar;

    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    public void Update()
    {
        var lifePercentage = playerHealth.currentHealth / playerHealth.GetMaxHealth();

        currentHealthBar.rectTransform.SetSizeWithCurrentAnchors(
            RectTransform.Axis.Horizontal,
            totalHealthBar.rectTransform.rect.width * lifePercentage);
    }
}
