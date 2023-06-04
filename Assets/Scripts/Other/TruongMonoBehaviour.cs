using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public abstract class TruongMonoBehaviour : MonoBehaviour
{
    [Button]
    protected virtual void SetDefault()
    {
        LoadComponents();
        SetDefaultValue();
    }

    protected virtual void Awake()
    {
        LoadComponents();
    }

    protected virtual void LateUpdate()
    {
        //For override
    }

    protected virtual void LoadComponents()
    {
        //For override
    }

    protected virtual void SetDefaultValue()
    {
        //For override
    }

    protected T GetParentComponent<T>() where T : Component
    {
        T component = null;
        Transform parent = transform.parent;

        while (parent != null)
        {
            component = parent.GetComponent<T>();
            if (component != null)
            {
                // Tìm thấy thành phần, thoát khỏi vòng lặp
                break;
            }

            // Tiếp tục tìm trong đối tượng cha tiếp theo
            parent = parent.parent;
        }

        if (component != null)
        {
            // Đã tìm thấy thành phần trong đối tượng cha
            return component;
        }
        else
        {
            // Không tìm thấy thành phần trong các đối tượng cha
            return null;
        }
    }
}