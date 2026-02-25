# 🚀 Sem Espaços em Branco

## 📌 Descrição

Dada uma string **S** contendo apenas dígitos de `0 a 9`, o objetivo é
calcular o número de formas possíveis de dividir essa string em uma ou
mais partes, obedecendo às seguintes regras:

-   Cada número formado deve ser **menor ou igual a C**
-   Nenhum número pode conter **zero à esquerda**
-   O resultado deve ser retornado módulo **10\^K**

------------------------------------------------------------------------

## 📥 Entrada

A entrada deve seguir o formato:

    N C K
    S

Onde:

-   `N` → tamanho da string
-   `C` → valor máximo permitido para cada número formado
-   `K` → expoente do módulo (10\^K)
-   `S` → string numérica com N caracteres

------------------------------------------------------------------------

## 📤 Saída

Um único número representando a quantidade de formas válidas de dividir
a string, módulo `10^K`.

------------------------------------------------------------------------

## 🧠 Estratégia Utilizada

A solução foi implementada utilizando:

-   **Programação Dinâmica (DP)**
-   Complexidade **O(N × dígitos de C)**
-   Controle de estouro utilizando módulo `10^K`
-   Estrutura otimizada para suportar `N` até 100.000

------------------------------------------------------------------------

## 💻 Implementação (C# Console)

``` csharp
using System;

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

        for (int right = 0; right < N; right++)
        {
            long numero = 0;
            long multiplicador = 1;

            for (int i = right; i >= 0; i--)
            {
                if (S[i] == '0' && i != right)
                    break;

                numero = (S[i] - '0') * multiplicador + numero;

                if (numero > C)
                    break;

                dp[right + 1] = (dp[right + 1] + dp[i]) % mod;

                multiplicador *= 10;
            }
        }

        Console.WriteLine(dp[N]);
    }
}
```

------------------------------------------------------------------------

## 📊 Exemplo

### Entrada

    7 1234567 9
    1234567

### Saída

    64

------------------------------------------------------------------------

## ⚙️ Requisitos

-   .NET 6+ ou compatível
-   Execução via Console

------------------------------------------------------------------------

## 📄 Licença

Este projeto pode ser utilizado livremente para fins de estudo e prática
de algoritmos.
