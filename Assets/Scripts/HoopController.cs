using System.Collections;
using System.Collections.Generic;
using Pixelplacement;
using Sirenix.OdinInspector;
using UnityEngine;

public class HoopController : Singleton<HoopController>
{
    public int amount;
    public float spacing;
    public Hoop hoopPrefab;
    private readonly List<Hoop> hoops = new List<Hoop>();
    [SerializeField] public Hoop currentHoop;

    public void Init(GameConfig config)
    {
        amount = config.hoopAmount;
        spacing = config.hoopSpacing;
    }

    public void OnPlay()
    {
        hoops.ForEach(h => Destroy(h.gameObject));
        hoops.Clear();
        SpawnHoops();
    }

    [Button]
    public void SpawnHoops()
    {
        Hoop lastHoop = null;
        if (hoops.Count > 0)
            lastHoop = hoops[hoops.Count - 1];
        for (var i = 0; i < amount; i++)
        {
            var newHoop = Instantiate(hoopPrefab.gameObject, transform).GetComponent<Hoop>();
            newHoop.name = "Hoop" + i;
            if (lastHoop != null)
                newHoop.Init(lastHoop, i);
            lastHoop = newHoop;
            hoops.Add(newHoop);
            if (i == 0)
            {
                currentHoop = newHoop;
            }
        }
    }

    public void UpdateCurHoop()
    {
        currentHoop.spriteRenderer.color = Color.green;
        currentHoop.idText.gameObject.SetActive(false);
        var index = hoops.IndexOf(currentHoop);
        if (index + 1 == hoops.Count)
            SpawnHoops();
        else
        {
            currentHoop = hoops[index + 1];
            Debug.Log($"currentHoop = {currentHoop.name}");
        }
    }
}