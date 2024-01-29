using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SheriffCharacter : MonoBehaviour
{
    public PlayerInputs _playerInputs;
    [System.NonSerialized]
    public CameraShake _cameraShake;

    [Header("References")]
    [SerializeField]
    private Animator _gunAnimator;

    [Space(20)]
    [SerializeField]
    private Transform _projectileSpawner;
    [SerializeField]
    private ProjectileBehavior _projectilePrefab;

    [Header("Parameters")]
    public int maxAmmo;

    public float fireRate;



    //Input variables

    private bool _canShoot;

    private void Awake()
    {
        _playerInputs = new PlayerInputs();
        _cameraShake = Camera.main.GetComponent<CameraShake>();
        Debug.Log(_cameraShake);
    }

    private void OnEnable()
    {
        _playerInputs.Enable();
    }

    private void OnDisable()
    {
        _playerInputs.Disable();
    }

    private void Start()
    {
        _playerInputs.Player.Fire.started += Fire;

        _canShoot = true;
    }


    public void Fire(InputAction.CallbackContext obj)
    {
        if (_canShoot)
        {
            _gunAnimator.SetTrigger("Fire");
            _canShoot = false;

            //Spawn orijectile

            ProjectileBehavior newProjectile = Instantiate(_projectilePrefab, _projectileSpawner);
            newProjectile.transform.parent = null;

            //Play effects
            StartCoroutine(_cameraShake.Shake(.2f, .5f));

            StartCoroutine(FireDelay());
        }
        
    }

    private IEnumerator FireDelay()
    {
        yield return new WaitForSeconds(fireRate);
        _canShoot = true;
    }

}
