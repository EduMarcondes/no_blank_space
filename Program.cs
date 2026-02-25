using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        var primeiraLinha = Console.ReadLine().Split(' ');
        int N = int.Parse(primeiraLinha[0]);
        long C = long.Parse(primeiraLinha[1]);
        int K = int.Parse(primeiraLinha[2]);

        string S = Console.ReadLine().Trim();

        long mod = 1;
        for (int i = 0; i < K; i++)
            mod *= 10;

        long[] dp = new long[N + 1];
        dp[0] = 1;

        long janelaSoma = 0;
        int left = 0;

        for (int right = 0; right < N; right++)
        {
            // Se começar com zero, não pode formar número
            if (S[right] == '0')
            {
                dp[right + 1] = 0;
                continue;
            }

            long numero = 0;

            // Expandir para trás enquanto número <= C
            for (int i = right; i >= left; i--)
            {
                if (S[i] == '0' && i != right)
                    break;

                numero = long.Parse(S.Substring(i, right - i + 1));

                if (numero > C)
                {
                    left = i + 1;
                    break;
                }

                dp[right + 1] = (dp[right + 1] + dp[i]) % mod;
            }
        }

        Console.WriteLine(dp[N] % mod);
    }
}
