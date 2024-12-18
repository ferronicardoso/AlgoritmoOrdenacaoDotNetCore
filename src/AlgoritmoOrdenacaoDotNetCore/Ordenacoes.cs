﻿namespace AlgoritmoOrdenacaoDotNetCore;

public static class Ordenacoes
{
    #region Insertion Sort

    public static int[] InsertionSort(int[] vetor)
    {
        int i, j, atual;
        for (i = 1; i < vetor.Length; i++)
        {
            atual = vetor[i];
            j = i;
            while ((j > 0) && (vetor[j - 1] > atual))
            {
                vetor[j] = vetor[j - 1];
                j = j - 1;
            }
            vetor[j] = atual;
        }
        return vetor;
    }

    #endregion

    #region Shell Sort

    public static int[] ShellSort(int[] vetor)
    {
        int h = 1;
        int n = vetor.Length;

        while (h < n)
        {
            h = h * 3 + 1;
        }

        h = h / 3;
        int c, j;
        while (h > 0)
        {
            for (int i = h; i < n; i++)
            {
                c = vetor[i];
                j = i;
                while (j >= h && vetor[j - h] > c)
                {
                    vetor[j] = vetor[j - h];
                    j = j - h;
                }
                vetor[j] = c;
            }
            h = h / 2;
        }

        return vetor;
    }

    #endregion

    #region Selection Sort

    public static int[] SelectionSort(int[] vetor)
    {
        int min, aux;

        for (int i = 0; i < vetor.Length - 1; i++)
        {
            min = i;

            for (int j = i + 1; j < vetor.Length; j++)
                if (vetor[j] < vetor[min])
                    min = j;

            if (min != i)
            {
                aux = vetor[min];
                vetor[min] = vetor[i];
                vetor[i] = aux;
            }
        }

        return vetor;
    }

    #endregion

    #region Heap Sort

    public static int[] HeapSort(int[] vetor)
    {
        BuildMaxHeap(vetor);
        int n = vetor.Length;

        for (int i = vetor.Length - 1; i > 0; i--)
        {
            Swap(vetor, i, 0);
            MaxHeapify(vetor, 0, --n);
        }

        return vetor;
    }

    private static void BuildMaxHeap(int[] v)
    {
        for (int i = v.Length / 2 - 1; i >= 0; i--)
        {
            MaxHeapify(v, i, v.Length);
        }
    }

    private static void MaxHeapify(int[] v, int pos, int n)
    {
        int max = 2 * pos + 1, right = max + 1;
        if (max < n)
        {
            if (right < n && v[max] < v[right])
            {
                max = right;
            }
            if (v[max] > v[pos])
            {
                Swap(v, max, pos);
                MaxHeapify(v, max, n);
            }
        }
    }

    private static void Swap(int[] v, int j, int aposJ)
    {
        int aux = v[j];
        v[j] = v[aposJ];
        v[aposJ] = aux;
    }

    #endregion

    #region Bubble Sort

    public static int[] BubbleSort(int[] vetor)
    {
        int tamanho = vetor.Length;

        for (int i = tamanho - 1; i >= 1; i--)
        {
            for (int j = 0; j < i; j++)
            {
                if (vetor[j] > vetor[j + 1])
                {
                    int aux = vetor[j];
                    vetor[j] = vetor[j + 1];
                    vetor[j + 1] = aux;
                }
            }
        }

        return vetor;
    }

    #endregion

    #region Cocktails

    public static int[] CocktailSort(int[] vetor)
    {
        int tamanho, inicio, fim, swap, aux;
        tamanho = vetor.Length;
        inicio = 0;
        fim = tamanho - 1;
        swap = 0;
        while (swap == 0 && inicio < fim)
        {
            swap = 1;
            for (int i = inicio; i < fim; i = i + 1)
            {
                if (vetor[i] > vetor[i + 1])
                {
                    aux = vetor[i];
                    vetor[i] = vetor[i + 1];
                    vetor[i + 1] = aux;
                    swap = 0;
                }
            }

            fim = fim - 1;

            for (int i = fim; i > inicio; i = i - 1)
            {
                if (vetor[i] < vetor[i - 1])
                {
                    aux = vetor[i];
                    vetor[i] = vetor[i - 1];
                    vetor[i - 1] = aux;
                    swap = 0;
                }
            }

            inicio = inicio + 1;
        }

        return vetor;
    }

    #endregion

    #region Comb Sort

    public static int[] CombSort(int[] vetor)
    {
        int gap = vetor.Length;
        bool swapped = true;
        while (gap > 1 || swapped)
        {
            if (gap > 1)
            {
                gap = (int)(gap / 1.247330950103979);
            }

            int i = 0;
            swapped = false;
            while (i + gap < vetor.Length)
            {
                if (vetor[i].CompareTo(vetor[i + gap]) > 0)
                {
                    int t = vetor[i];
                    vetor[i] = vetor[i + gap];
                    vetor[i + gap] = t;
                    swapped = true;
                }
                i++;
            }
        }

        return vetor;
    }

    #endregion

    #region Gnome Sort

    public static int[] GnomeSort(int[] vetor)
    {
        int p = 0;
        int aux;
        while (p < (vetor.Length - 1))
        {
            if (vetor[p] > vetor[p + 1])
            {
                aux = vetor[p];
                vetor[p] = vetor[p + 1];
                vetor[p + 1] = aux;
                if (p > 0)
                {
                    p -= 2;
                }
            }
            p++;
        }

        return vetor;
    }

    #endregion

    #region Odd-Even Sort

    public static int[] OddEvenSort(int[] vetor)
    {
        bool sorted = false;
        while (!sorted)
        {
            sorted = true;
            // odd-even
            for (int x = 1; x < vetor.Length - 1; x += 2)
            {
                if (vetor[x] > vetor[x + 1])
                {
                    int tmp = vetor[x];
                    vetor[x] = vetor[x + 1];
                    vetor[x + 1] = tmp;

                    sorted = false;
                }
            }

            // even-odd
            for (int x = 0; x < vetor.Length - 1; x += 2)
            {
                if (vetor[x] > vetor[x + 1])
                {
                    int tmp = vetor[x];
                    vetor[x] = vetor[x + 1];
                    vetor[x + 1] = tmp;

                    sorted = false;
                }
            }
        }
        return vetor;
    }

    #endregion

    #region Quick Sort

    public static int[] QuickSort(int[] vetor)
    {
        int inicio = 0;
        int fim = vetor.Length - 1;

        QuickSort(vetor, inicio, fim);

        return vetor;
    }

    private static void QuickSort(int[] vetor, int inicio, int fim)
    {
        if (inicio < fim)
        {
            int p = vetor[inicio];
            int i = inicio + 1;
            int f = fim;

            while (i <= f)
            {
                if (vetor[i] <= p)
                {
                    i++;
                }
                else if (p < vetor[f])
                {
                    f--;
                }
                else
                {
                    int troca = vetor[i];
                    vetor[i] = vetor[f];
                    vetor[f] = troca;
                    i++;
                    f--;
                }
            }

            vetor[inicio] = vetor[f];
            vetor[f] = p;

            QuickSort(vetor, inicio, f - 1);
            QuickSort(vetor, f + 1, fim);
        }
    }

    #endregion

    #region Merge Sort

    public static int[] MergeSort(int[] vetor)
    {
        var inicio = 0;
        var fim = vetor.Length - 1;
        return MergeSort(vetor, inicio, fim);
    }
    
    private static int[] MergeSort(int[] vetor, int inicio, int fim)
    {
        if (inicio < fim)
        {
            var meio = (inicio + fim) / 2;
            vetor = MergeSort(vetor, inicio, meio);
            vetor = MergeSort(vetor, meio + 1, fim);
            vetor = MergeSort(vetor, inicio, meio, fim);
        }
        return vetor;
    }

    private static int[] MergeSort(int[] vetor, int inicio, int meio, int fim)
    {
        var n1 = meio - inicio + 1;
        var n2 = fim - meio;
        var a1 = new int[n1];
        var a2 = new int[n2];

        for (int i = 0; i < n1; i++) a1[i] = vetor[inicio + i];
        for (int j = 0; j < n2; j++) a2[j] = vetor[meio + 1 + j];

        int a = 0, b = 0, c = inicio;

        while (a < n1 && b < n2)
        {
            if (a1[a] <= a2[b])
            {
                vetor[c] = a1[a];
                a++;
            }
            else
            {
                vetor[c] = a2[b];
                b++;
            }
            c++;
        }

        while (a < n1)
        {
            vetor[c] = a1[a];
            a++;
            c++;
        }

        while (b < n2)
        {
            vetor[c] = a2[b];
            b++;
            c++;
        }
        return vetor;
    }

    #endregion
}
