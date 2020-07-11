using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    class Relation
    {
        private BallType giver; //this relation says  how much force to apply on giver
        private BallType receiver;
        private bool attract; //if false then repulsion happens
        private float minEffectiveRange;
        private float maxEffectiveRange;
        private float peakValue;
        private float peakDistance;

        public float PeakDistance { get => peakDistance; set => peakDistance = value; }
        public float PeakValue { get => peakValue; set => peakValue = value; }
        public float MaxEffectiveRange { get => maxEffectiveRange; set => maxEffectiveRange = value; }
        public float MinEffectiveRange { get => minEffectiveRange; set => minEffectiveRange = value; }
        public bool Attract { get => attract; set => attract = value; }
        internal BallType Receiver { get => receiver; set => receiver = value; }
        internal BallType Giver { get => giver; set => giver = value; }
        private static System.Random R = new System.Random();
        static public Relation GetRandomRelation(BallType giver, BallType receiver, float maxPeak, float maxMaxDist)
        {

            
            return new Relation(receiver, giver, Convert.ToBoolean(R.Next(0, 2)), (float)R.NextDouble() * maxMaxDist, (float)R.NextDouble() * maxPeak);


        }

        public Relation(BallType giver, BallType receiver, bool attract, float maxEffectiveRange, float peak, float minEffectiveRange = 0f, float peakDistance = 0f)
        {
            this.giver = giver;
            this.receiver = receiver;
            this.attract = attract;
            this.minEffectiveRange = minEffectiveRange;
            this.maxEffectiveRange = maxEffectiveRange;
            this.peakValue = peak;
            this.peakDistance = Mathf.Clamp(peakDistance, minEffectiveRange,maxEffectiveRange);
        }
        public float interpolateForce(float distance)
        {
            distance -= giver.Radius+receiver.Radius;
            if (distance < minEffectiveRange || distance > maxEffectiveRange)
                return 0;
            if (distance > peakDistance)
            {
                float distToPeak = distance - peakDistance;
                float maxDistOffset = maxEffectiveRange - peakDistance;
                if (maxDistOffset == 0)
                    return peakValue;
                //y=maxValue*x^2/maxDist^2  -2maxVal*x/maxDist +maxVal
                return peakValue * distToPeak * distToPeak / (maxDistOffset * maxDistOffset) - 2 * peakValue * distToPeak / maxDistOffset + peakValue;



            }
            else
            {
                
                float distToStart = distance - minEffectiveRange;
                float maxDistOffset = peakDistance - minEffectiveRange; //distance between start and max
                if (maxDistOffset == 0)
                    return peakValue;
                //y=maxVal x^2/maxDist^2
                return peakValue * distToStart * distToStart / (maxDistOffset * maxDistOffset);
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Relation relation &&
                   EqualityComparer<BallType>.Default.Equals(giver, relation.giver) &&
                   EqualityComparer<BallType>.Default.Equals(receiver, relation.receiver) &&
                   attract == relation.attract &&
                   minEffectiveRange == relation.minEffectiveRange &&
                   maxEffectiveRange == relation.maxEffectiveRange &&
                   peakValue == relation.peakValue &&
                   peakDistance == relation.peakDistance;
        }

        public override int GetHashCode()
        {
            int hashCode = 2000192298;
            hashCode = hashCode * -1521134295 + EqualityComparer<BallType>.Default.GetHashCode(giver);
            hashCode = hashCode * -1521134295 + EqualityComparer<BallType>.Default.GetHashCode(receiver);
            return hashCode;
        }
    }
}
