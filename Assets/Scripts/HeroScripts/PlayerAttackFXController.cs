using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackFXController : MonoBehaviour
{

    [SerializeField] private GameObject normalAttack;
    [SerializeField] private GameObject specialAttackPrefab1, specialAttackPrefab2, specialAttackPrefab3;

    [SerializeField] private Transform specialAttackPos1, specialAttackPos2, specialAttackPos3, normalAttackPos;
    [SerializeField] private Transform specialAttackPos21, specialAttackPos22;

    [SerializeField] private bool isLeiZhengzi;
    [SerializeField] private bool isWhiteAngel;
    [SerializeField] private bool isLianYou;
    [SerializeField] private bool isSidatian;
    [SerializeField] private bool isDarkSourcerer;

    void ActivateNormalAttack()
    {
        normalAttack.SetActive(true);
    }

    void DeactivateNormalAttack()
    {
        normalAttack.SetActive(false);
    }

    void SpawnSpecialAttackFX1()
    {
        if (isWhiteAngel || isLeiZhengzi)
            Instantiate(specialAttackPrefab1, specialAttackPos1.position, Quaternion.identity);
        
        if (isLianYou || isSidatian || isDarkSourcerer)
            Instantiate(specialAttackPrefab1, specialAttackPos1.position, transform.rotation);
    }
    
    void SpawnSpecialAttackFX2()
    {
        if (isSidatian || isLeiZhengzi)
            Instantiate(specialAttackPrefab2, specialAttackPos2.position, transform.rotation);

        if (isWhiteAngel)
        {
            GameObject special2 = Instantiate(specialAttackPrefab2);
            special2.transform.position = specialAttackPos2.position;
            special2.transform.SetParent(specialAttackPos2);
            //Call angel script
        }
            
        if (isLianYou)
            Instantiate(specialAttackPrefab2, specialAttackPos2.position, Quaternion.identity);

        if (isDarkSourcerer)
        {
            Instantiate(specialAttackPrefab2, specialAttackPos2.position, transform.rotation);
            Instantiate(specialAttackPrefab2, specialAttackPos21.position, transform.rotation);
            Instantiate(specialAttackPrefab2, specialAttackPos22.position, transform.rotation);
        }
    }

    void SpawnSpecialAttackFX3()
    {
        if (isLeiZhengzi || isWhiteAngel || isLianYou || isSidatian)
            Instantiate(specialAttackPrefab3, specialAttackPos3.position, transform.rotation);

        if (isDarkSourcerer)
        {
            Instantiate(specialAttackPrefab3, specialAttackPos2.position, transform.rotation);
            Instantiate(specialAttackPrefab3, specialAttackPos21.position, transform.rotation);
            Instantiate(specialAttackPrefab3, specialAttackPos22.position, transform.rotation);
        }
    }

    void SpawnNormalAttackEffect()
    {
        Instantiate(normalAttack, normalAttackPos.position, transform.rotation);
    }
}
