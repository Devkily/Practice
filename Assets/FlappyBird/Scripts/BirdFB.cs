using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BirdMoverFB))]
public class BirdFB : MonoBehaviour
{
    [SerializeField] GameObject _menu;
    private BirdMoverFB _mover;

    private void Start()
    {
        _mover = GetComponent<BirdMoverFB>();
    }
    public void ResetPlayer()
    {
        _mover.Restart();
    }
    public void Die()
    {
        Time.timeScale = 0;
        gameObject.SetActive(false);
        _menu.SetActive(true);
    }
}
