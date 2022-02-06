using System;
using System.Collections.Generic;
using System.Text;

namespace E08.Threeuple
{
    public class Threeuple<TFirst, TSecond, TThird>
    {
        private TFirst first;
        private TSecond second;
        private TThird third;

        public Threeuple(TFirst first, TSecond second, TThird third)
        {
            this.first = first;
            this.second = second;
            this.third = third;
        }

        public override string ToString()
        {
            return $"{first} -> {second} -> {third}";
        }
    }
}
