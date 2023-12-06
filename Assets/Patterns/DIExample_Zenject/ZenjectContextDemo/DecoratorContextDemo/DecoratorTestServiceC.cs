using UnityEngine;

public class DecoratorTestServiceC : MonoBehaviour
{
    [SerializeField] private int value;

    public int Value { get => value; set => this.value = value; }
}
