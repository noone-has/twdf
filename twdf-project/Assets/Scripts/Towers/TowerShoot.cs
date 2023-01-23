using System.Collections;
using System.IO;
using Enemies;
using UnityEngine;
using UnityEngine.Serialization;

namespace Towers
{
    public class TowerShoot : MonoBehaviour
    {

        [FormerlySerializedAs("Damage")] [SerializeField]
        private float damage;
        [FormerlySerializedAs("Range")] [SerializeField]
        private float range;
        [SerializeField] private float fireRate;
        private float _armor; // temporary fix because there were too many errors because of this
        private GameObject[] _enemies;
        private float _distance;
        private float _smallestDistance;
        private GameObject _enemyToShoot;
        private float _health;
        private float _lowestHealth;
        private float _highestHealth;
        private float _biggestDistance;
        private bool _shootRunning;

        private IEnumerator Shoot()
        {
            _shootRunning = true;
            GameObject
                enemy = FindEnemy("findClosestEnemy",
                    0); //temporary, need to make something that picks the function according to the mode the tower is on
            Debug.Log(enemy);
            enemy.GetComponent<Damageable>().TakeDamage(damage);
            yield return new WaitForSeconds(fireRate);
            _shootRunning = false;
        }

        private void Start()
        {
            StartCoroutine("Shoot");
        }

        private void Update()
        {
            if (_shootRunning != true)
            {
                StartCoroutine("Shoot");
            }
        }


        private GameObject FindEnemy(string option, float arg = 1)
        {

            _enemyToShoot = null;
            _enemies = GameObject.FindGameObjectsWithTag("Enemy");

            switch (option)
            {
                case "findClosestEnemy":
                    foreach (var enemy in _enemies)
                    {
                        _distance = Vector2.Distance(enemy.transform.position, this.transform.position);
                        if (_distance < _smallestDistance && _distance <= range)
                        {
                            _smallestDistance = _distance;
                            _enemyToShoot = enemy;
                        }

                    }

                    return _enemyToShoot;

                case "findFurthestEnemy":
                    foreach (var enemy in _enemies)
                    {
                        _distance = Vector2.Distance(enemy.transform.position, this.transform.position);
                        if (_distance > _biggestDistance && _distance <= range)
                        {
                            _biggestDistance = _distance;
                            _enemyToShoot = enemy;
                        }

                    }

                    return _enemyToShoot;

                case "findLowestHPEnemy":
                    foreach (var enemy in _enemies)
                    {
                        _distance = Vector2.Distance(enemy.transform.position, this.transform.position);
                        if (_distance <= range && _health < _lowestHealth)
                        {
                            _lowestHealth = _health;
                            _enemyToShoot = enemy;
                        }

                    }

                    return _enemyToShoot;

                case "findHighestHPEnemy":
                    foreach (var enemy in _enemies)
                    {
                        _distance = Vector2.Distance(enemy.transform.position, this.transform.position);
                        if (_distance <= range && _health < _lowestHealth)
                        {
                            _lowestHealth = _health;
                            _enemyToShoot = enemy;
                        }

                    }

                    return _enemyToShoot;

                case "findLowestArmorEnemy":
                    float lowestArmor = arg;
                    foreach (var enemy in _enemies)
                    {
                        _distance = Vector2.Distance(enemy.transform.position, this.transform.position);
                        _armor = enemy.GetComponent<Damageable>().GetArmor();
                        if (_distance <= range && _armor < lowestArmor)
                        {
                            lowestArmor = _armor;
                            _enemyToShoot = enemy;
                        }

                    }

                    return _enemyToShoot;

                case "findHighestArmorEnemy":
                    float highestArmor = arg;
                    foreach (var enemy in _enemies)
                    {
                        _distance = Vector2.Distance(enemy.transform.position, this.transform.position);
                        _armor = enemy.GetComponent<Damageable>().GetArmor();
                        if (_distance <= range && _armor > highestArmor)
                        {
                            highestArmor = _armor;
                            _enemyToShoot = enemy;
                        }
                    }

                    return _enemyToShoot;
            }

            throw new InvalidDataException();
        }
    }
}