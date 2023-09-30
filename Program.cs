// See https://aka.ms/new-console-template for more information
using System.Text;

static string GameofLifeStrings(string str)
{
    string[] splitted = str.Split("_");

    int N = splitted.Length;
    int M = splitted[0].Length;

    int[,] array = new int[N, M];
    int[,] newGen = new int[N, M];

    int index = 0;
    foreach (var splittedStr in splitted)
    {
        for (int j = 0; j < M; j++)
        {
            array[index, j] = splittedStr[j] - '0';
        }
        index++;
    }

    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < M; j++)
        {
            int neighCount = 0;

            if (array[i, j] == 0)
            {
                if (j - 1 >= 0)
                {
                    if (i - 1 > 0)
                    {
                        if (array[i, j] != array[i - 1, j - 1])
                        {
                            neighCount++;
                        }
                    }

                    if (array[i, j] != array[i, j - 1])
                    {
                        neighCount++;
                    }


                    if (i + 1 < N)
                    {
                        if (array[i, j] != array[i + 1, j - 1])
                        {
                            neighCount++;
                        }
                    }


                }

                if (j + 1 < M)
                {
                    if (i - 1 >= 0)
                    {
                        if (array[i, j] != array[i - 1, j + 1])
                        {
                            neighCount++;
                        }
                    }

                    if (array[i, j] != array[i, j + 1])
                    {
                        neighCount++;
                    }


                    if (i + 1 < N)
                    {
                        if (array[i, j] != array[i + 1, j + 1])
                        {
                            neighCount++;
                        }
                    }

                }

                if (i - 1 >= 0)
                    if (array[i, j] != array[i - 1, j])
                    {
                        neighCount++;
                    }

                if (i + 1 < N)
                    if (array[i, j] != array[i + 1, j])
                    {
                        neighCount++;
                    }
            }

            if (array[i, j] == 1)
            {
                if (j - 1 >= 0)
                {
                    if (i - 1 > 0)
                    {
                        if (array[i, j] == array[i - 1, j - 1])
                        {
                            neighCount++;
                        }
                    }

                    if (array[i, j] == array[i, j - 1])
                    {
                        neighCount++;
                    }


                    if (i + 1 < N)
                    {
                        if (array[i, j] == array[i + 1, j - 1])
                        {
                            neighCount++;
                        }
                    }


                }

                if (j + 1 < M)
                {
                    if (i - 1 >= 0)
                    {
                        if (array[i, j] == array[i - 1, j + 1])
                        {
                            neighCount++;
                        }
                    }

                    if (array[i, j] == array[i, j + 1])
                    {
                        neighCount++;
                    }


                    if (i + 1 < N)
                    {
                        if (array[i, j] == array[i + 1, j + 1])
                        {
                            neighCount++;
                        }
                    }

                }

                if (i - 1 >= 0)
                    if (array[i, j] == array[i - 1, j])
                    {
                        neighCount++;
                    }

                if (i + 1 < N)
                    if (array[i, j] == array[i + 1, j])
                    {
                        neighCount++;
                    }
            }

            if (array[i, j] == 0 && neighCount >= 3)
                newGen[i, j] = 1;
            else if (array[i, j] == 1 && neighCount >= 2)
                newGen[i, j] = 1;
            else
                newGen[i, j] = 0;


        }
    }

    var strBuilder = new StringBuilder();

    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < M; j++)
        {
            strBuilder.Append(newGen[i, j]);
        }
        if (i + 1 != N)
            strBuilder.Append("_");
    }

    return strBuilder.ToString();

}

string[] examples = new string[] { "000_111_000", "11", "0100_1010_1111_1100" };

foreach (var example in examples)
{

    Console.WriteLine(GameofLifeStrings(example));
}



