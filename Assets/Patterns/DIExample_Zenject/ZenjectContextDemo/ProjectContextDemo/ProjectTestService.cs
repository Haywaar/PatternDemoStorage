using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectTestService : MonoBehaviour
{
   [SerializeField] private string str;

    public string Value { get => str; set => this.str = value; }
}
