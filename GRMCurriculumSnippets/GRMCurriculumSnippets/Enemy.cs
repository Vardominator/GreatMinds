using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRMCurriculumSnippets
{
    abstract class Enemy
    {
        abstract public void FollowCharacter(Vector2 characterPosition);
    }

    class Boss : Enemy
    {
        public override void FollowCharacter(Vector2 characterPosition)
        {
            // ... Details
        }
    }

    interface Automobile
    {
        void Accelerate(int power, TimeSpan time);
        void Stop(TimeSpan time);
        string Make();
        string DriveTrain();
    }

    class Porsche : Automobile, IComparable<Automobile>
    {
        //... Fields
        //... Constructor

        public void Accelerate(int power, TimeSpan time)
        {
            //... Details
        }
        public void Stop(TimeSpan time)
        {
            //...
        }
        public string Make()
        {
            //...
        }
        public string DriveTrain()
        {
            //...
        }

        public int CompareTo(Automobile other)
        {
            //...
        }
    }



}
