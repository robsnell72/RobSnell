using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hn
{
    public class HappyNumber
    {
        public int StartingNumber { get; private set; }
        public IList<int> Series { get; private set; }

        bool? isHappyBf;
        public bool isHappy
        {
            get
            {
                if (!isHappyBf.HasValue)
                {
                    isHappyBf = isHappyImplementation();
                }

                return isHappyBf.Value;
            }
            private set
            {
                isHappyBf = value;
            }
        }

        public HappyNumber(int startingNumber)
        {
            //https://en.wikipedia.org/wiki/Happy_number
            StartingNumber = startingNumber;
            Series = new List<int>();
        }

        bool isHappyImplementation()
        {
            //first run through
            int iterationStartingNumber = StartingNumber;

            do
            {
                //split starting number into digits
                char[] digits = iterationStartingNumber.ToString().ToCharArray();
                int[] digitsI = digits.Select(x => int.Parse(x.ToString())).ToArray<int>();

                //get sum of square of digits
                iterationStartingNumber = digitsI.Sum(x => (int)(Math.Pow((double)x, (double)2)));

                //if 1 return true
                if (1 == iterationStartingNumber)
                {
                    return true;
                }

                //if already present in series return false
                if (Series.Contains(iterationStartingNumber))
                {
                    return false;
                }
                //else add to series and continue
                else
                {
                    Series.Add(iterationStartingNumber);
                }
            } while (true);
        }
    }
}
