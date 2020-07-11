using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Assets
{
    class BallType
    {
        private String name;
        private Color color;
        private float frictionMult;
        private float radius;
        private Dictionary<BallType,Relation> forces;

        public float Radius { get => radius; set => radius = value; }
        public float FrictionMult { get => frictionMult; set => frictionMult = value; }
        public Color Color { get => color; set => color = value; }
        public string Name { get => name; set => name = value; }
        internal Dictionary<BallType, Relation> Forces { get => forces; set => forces = value; }

        public BallType(string name, Color color, float frictionMult, Dictionary<BallType,Relation> forces, float radius = 0.2f)
        {
            this.name = name;
            this.color = color;
            this.frictionMult = frictionMult;
            this.forces = forces;
            this.radius = radius;
           
        }


        public override bool Equals(object obj)
        {
            return obj is BallType type &&
                   name == type.name;
        }

        public override int GetHashCode()
        {
            return 363513814 + EqualityComparer<string>.Default.GetHashCode(name);
        }
    }
}
