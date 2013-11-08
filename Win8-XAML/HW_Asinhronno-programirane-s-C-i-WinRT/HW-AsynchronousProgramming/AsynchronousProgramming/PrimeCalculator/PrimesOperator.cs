using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeCalculator
{
    public class PrimesOperator
    {
        public async Task<string> FindPrimeOrNotInPrimesConcatenationsAsync(long rangeFirst, long rangeLast, bool findPrimes)
        {
            List<long> concatenatedPrimes = await MakePrimesConcatenationsAsync(rangeFirst, rangeLast);

            List<long> resultList = new List<long>();
            if (findPrimes)
            {
                await AddPrimesToListAsync(concatenatedPrimes, resultList);
            }
            else
            {
                await AddNotPrimesToListAsync(concatenatedPrimes, resultList);
            }

            string resultString = ConcatenatePrimes(resultList);

            return resultString;
        }

        private void AddNotPrimesToList(List<long> concatenatedPrimes, List<long> resultList)
        {
            foreach (var concatenatedNumber in concatenatedPrimes)
            {
                bool isNotPrime = FindIfIsNotPrime(concatenatedNumber);
                if (isNotPrime)
                {
                    resultList.Add(concatenatedNumber);
                }
            }
        }

        private Task AddNotPrimesToListAsync(List<long> concatenatedPrimes, List<long> resultList)
        {
            return Task.Run(() => AddNotPrimesToList(concatenatedPrimes, resultList));
        }

        private void AddPrimesToList(List<long> concatenatedPrimes, List<long> resultList)
        {
            foreach (var concatenatedNumber in concatenatedPrimes)
            {
                bool isPrime = FindIfPrime(concatenatedNumber);
                if (isPrime)
                {
                    resultList.Add(concatenatedNumber);
                }
            }
        }

        private Task AddPrimesToListAsync(List<long> concatenatedPrimes, List<long> resultList)
        {
            return Task.Run(() => AddPrimesToList(concatenatedPrimes, resultList));
        }

        private bool FindIfPrime(long number)
        {
            bool isPrime = true;
            for (long divider = 2; divider < number; divider++)
            {
                if (number % divider == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            return isPrime;
        }


        private bool FindIfIsNotPrime(long number)
        {
            bool isNotPrime = true;
            for (long divider = 2; divider < number; divider++)
            {
                if (number % divider != 0)
                {
                    isNotPrime = false;
                    break;
                }
            }
            return isNotPrime;
        }

        private Task<List<long>> GetPrimesInRangeAsync(long rangeFirst, long rangeLast)
        {
            return Task.Run(
                () => GetPrimesInRange(rangeFirst, rangeLast)
                    );
        }

        private List<long> GetPrimesInRange(long rangeFirst, long rangeLast)
        {
            List<long> primes = new List<long>();

            for (long number = rangeFirst; number < rangeLast; number++)
            {
                bool isPrime = FindIfPrime(number);
                if (isPrime)
                {
                    primes.Add(number);
                }
            }

            return primes;
        }

        private async Task<List<long>> MakePrimesConcatenationsAsync(long rangeFirst, long rangeLast)
        {
            List<long> primesList = await GetPrimesInRangeAsync(rangeFirst, rangeLast);

            List<long> primesConcatenations = new List<long>();

            foreach (var primeNumber in primesList)
            {
                string primeStr = primeNumber.ToString();
                char firstDigit = primeStr[0];

                foreach (var primeNumberInner in primesList)
                {
                    string primeInnerStr = primeNumberInner.ToString();
                    char secondDigit = primeInnerStr[primeInnerStr.Length - 1];

                    if (firstDigit == secondDigit)
                    {
                        int newNumber = int.Parse(primeStr + primeInnerStr);
                        primesConcatenations.Add(newNumber);
                    }
                }
            }

            return primesConcatenations;
        }

        private string ConcatenatePrimes(List<long> resultList)
        {
            string result = JoinList(resultList);

            return result;
        }

        private string JoinList(List<long> resultList)
        {
            return string.Join(", ", resultList);
        }
    }
}
