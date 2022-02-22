using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace Task_6_2
{
    public static class Mining
    {
        public static List<BigInteger> Factorization(BigInteger n)
        {
            if (n < 2)
            {
                throw new ArgumentException("Must be greater than 1");
            }

            var result = new List<BigInteger>();

            while (n % 2 == 0)
            {
                result.Add(2);
                n /= 2;
            }

            BigInteger factor = 3;
            while (factor * factor <= n)
            {
                if (n % factor == 0)
                {
                    result.Add(factor);
                    n /= factor;
                }
                else
                {
                    factor += 2;
                }
            }

            if (n > 1)
            {
                result.Add(n);
            }

            return result;
        }

        public static Task<List<BigInteger>> FactorizationAsync(BigInteger n)
        {
            var tcs = new TaskCompletionSource<List<BigInteger>>();
            new Thread(Calculation).Start();
            return tcs.Task;

            void Calculation()
            {
                try
                {
                    var result = Factorization(n);
                    tcs.SetResult(result);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }
        }

        public static Task<BigInteger> GcdAsync(BigInteger a, BigInteger b)
        {
            var task = Task.WhenAll(FactorizationAsync(a), FactorizationAsync(b))
                .ContinueWith(t =>
                {
                    var r = t.Result;
                    var factors = r[0];
                    var list = r[1];

                    var result = BigInteger.One;
                    foreach (var factor in factors)
                    {
                        if (list.Contains(factor))
                        {
                            list.Remove(factor);
                            result *= factor;
                        }
                    }

                    return result;
                });

            return task;
        }
    }
}