using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LCGtask4
{
	public static class HelperMethod
	{
		public static List<double> GenerateRandoms(double seed, double multiplier, double increment, double modulus, double iteration)
		{
			List<double> Randoms = new List<double>();
			double res = 0; // we use it to save a new value of seed after every iteration

			for (int i = 1; i <= iteration; i++)
			{
				if (i == 1)
				{
					//lcg function
					res = ((multiplier * seed) + increment) % modulus;
					Randoms.Add(res);
				}
				else
				{
					//lcg function
					res = ((multiplier * res) + increment) % modulus;
					Randoms.Add(res);
					
				}
			}
			return Randoms;
		}

		public static double CalcCycleLength(double seed, double multiplier, double increment, double modulus)
		{
			double k = modulus - 1;
			double CycleLength = -1;
			bool flag1= true;bool flag2= true; bool flag3= true;

			//case 1
			//modulus power of 2 , increment ≠ 0 
			//when: increment is relatively prime to modulus ( The only positive integer that divides both is 1)
			//and multiplier = 4k + 1
			//Longest period = modulus
			//k=modulus -1
			//modulus = 64,increment = 3,multiplier=253

			if (PowerOfTwo(modulus) && (increment != 0))
			{
				if (RelativelyPrime(increment, modulus) && (multiplier==4*k+1))
				{
					CycleLength = modulus;
					flag1= false;
				}

			}
			//case 2
			//modulus power of 2 and increment=0
			//Longest Period = modulus/4
			//Achieved when: seed is odd
			//and multiplier = 5 + 8k or multiplier = 3 + 8k
			//seed=3,multiplier=125,increment=0,modulus=16    //seed=9,multiplier=251,increment=0,modulus=32
			if (PowerOfTwo(modulus) && (increment == 0)) 
			{
				if (SeedOdd(seed) && ( (multiplier == (5 + 8 * k)) || (multiplier == (3 + 8 * k))))
				{
					CycleLength = modulus / 4;
					flag2= false;
				}
			}
			//case 3
			//modulus prime number , increment=0
			//Longest Period=m-1
			//Achieved when: multiplier ^ k -1 is divisible by modulus.
			//seed=10,multiplier=3,increment=0,modulus=7
			if (Prime(modulus) && (increment == 0))
			{
				if (Divisible((Math.Pow(multiplier, k) - 1), modulus))
				{
					CycleLength = modulus - 1;
					flag3=false;
				}
			}
			if(flag1==true&& flag2 == true&& flag3 == true)
			{
				CycleLength = CalcCycleLengthWihoutCond(multiplier, increment, modulus, seed);
			}

			return CycleLength;

		}
		public static bool PowerOfTwo(double num)
		{
			if (num == 0)
				return false;
			while (num != 1)
			{
				if (num % 2 != 0)
					return false;
				num = num / 2;
			}
			return true;
		}
		public static bool RelativelyPrime(double increment, double modulus)
		{
			double num = Math.Min(modulus, increment);
			for (int i = 2; i <= num; i++)
			{
				if (Divisible(increment, i) && Divisible(modulus, i))
					return false;
			}
			return true;
		}
		public static bool Divisible(double a, double b)
		{
			double cDouble = a / b;
			int cInteger = (int)cDouble;
			if (cInteger == cDouble)
				return true;
			return false;
		}
		public static bool SeedOdd(double seed)
		{
			if (seed % 2 != 0)
				return true;
			return false;
		}
		public static bool Prime(double modulus)
		{
			if (modulus <= 1)
				return false;

			for (int i = 2; i <= Math.Sqrt(modulus); i++)
			{
				if (modulus % i == 0)
					return false;

			}
			return true;
		}
		public static double CalcCycleLengthWihoutCond(double multiplier, double increment, double modulus, double x0)
		{
			double LongestPeriod = 0;
			double Fseed = 0;
			double res = 0;
			for (int i = 1; i <= modulus; i++)
			{
				if (i == 1)
				{
					res = ((multiplier * x0) + increment) % modulus;
					Fseed = res;
					LongestPeriod++;
				}
				else
				{
					res = ((multiplier * res) + increment) % modulus;
					if (Fseed != res )
					{
						LongestPeriod++;
					}
					else
					{
						break;
					}

				}
			}
			return LongestPeriod;
		}


	}
}
