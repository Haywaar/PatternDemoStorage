using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoratorTestServiceA : MonoBehaviour
{
    [SerializeField] private int value;

    public int Value { get => value; set => this.value = value; }
}
