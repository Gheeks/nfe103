using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Models.Common
{
    public class Item : MonoBehaviour
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public Sprite Sprite { get; set; }
        public float CriticalDamage { get; set; }
        public int Damages { get; set; }
        public float AttackSpeed { get; set; }
        public int Armor { get; set; }
        public float MovementSpeed { get; set; }
        public int MaxHealth { get; set; }
        public int Health { get; set; }

        public Item(string _name, int _price, string _description, Sprite _sprite, float _criticalDamage = 0, int _damages = 0, float _attackSpeed = 0, int _armor = 0, float _movementSpeed = 0, int _maxHealth = 0, int _health = 0)
        {
            Name = _name;
            Price = _price;
            Description = _description;
            Sprite = _sprite;
            Damages = _damages;
            CriticalDamage = _criticalDamage;
            AttackSpeed = _attackSpeed;
            Armor = _armor;
            MovementSpeed = _movementSpeed;
            MaxHealth = _maxHealth;
            Health = _health;
        }

        public void FillGameObjectModel(Item objectToFill)
        {
            /*PropertyInfo[] srcProps = this.GetType().GetProperties();
            foreach (PropertyInfo srcProp in srcProps)
            {
                PropertyInfo targetProperty = this.GetType().GetProperty(srcProp.Name);
                targetProperty.SetValue(objectToFill, srcProp.GetValue(this, null), null);
            }*/
            objectToFill.Name = this.Name;
            objectToFill.Price = this.Price;
            objectToFill.Description = this.Description;
            objectToFill.Sprite = this.Sprite;

        }
    }
}
