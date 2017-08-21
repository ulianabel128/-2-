using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace задача_2_практика
{
    class Program
    {
        static void Main(string[] args)
        {
            int n=-1;
            int k=-1;
            int kolvo = 0;
            string conclusion ="";
            int razn = 0;
            FileStream file1 = new FileStream("d://INPUT.TXT", FileMode.Open); //создаем файловый поток 
            FileStream file2 = new FileStream("d://OUTPUT.TXT", FileMode.Open);

            StreamReader reader = new StreamReader(file1); // создаем «потоковый читатель» и связываем его с файловым потоком

            string n_str = reader.ReadLine();
            int.TryParse(n_str, out n);

            string i_str = reader.ReadLine();
            char[] i_ch = i_str.ToCharArray();


            for (int i=0; i<i_ch.Length; i++)
            {
                if (i_ch[i] == ' ') kolvo++;
            }

            int[] mas = new int[kolvo];
            string symbol = "";
            int gl = 0;

            for (int i=0; i<i_ch.Length;i++)
            {
                if (i_ch[i] != ' ') symbol = symbol + i_ch[i];
                else
                {
                    int.TryParse(symbol, out mas[gl]);
                    symbol = "";
                    gl++;

                }
            }

            string k_str = reader.ReadLine();
            int.TryParse(n_str, out k);

            //if (n - k == 0) conclusion = k;
            //else
                razn = n - k;

            int[] aas = new int[2 * razn];

            for (int i = 0; i < aas.Length; i++)
                aas[i] = -1;

            int number = 0;
            int x = -1;
            int y = -1;
            int min= 32767;
            bool ok = false;

            while (razn != 0)
            {
                min = 32767;
                for (int i = 0; i < mas.Length-1; i++)
                {
                    if ((mas[i] + mas[i + 1]) < min)
                    {
                        for (int j = 0; j < aas.Length-1; j++)
                        {
                            if ((i != aas[j]) && ((i + 1) != aas[j + 1])) ok = true;
                            else ok = false;
                        }
                        if (ok)
                        {
                            min = mas[i] + mas[i - 1];
                            aas[number] = i;
                            aas[number + 1] = i + 1;
                            number = +2;    
                        }
                    }
                }
                razn = -1;
            }

            int[] k_mas = new int[k];

            for (int j=0; j<aas.Length; j++)
            {
                mas[aas[j]] = mas[aas[j]] + mas[aas[j + 1]];
                number = aas[j + 1];
                for (int arr= aas[j + 1]; arr<mas.Length; arr++ )
                {
                    mas[arr] = mas[arr++];
                }
                j++;
            }

            for (int i=0; i<k; i++)
            {
                k_mas[i] = mas[i];
            }

            for (int i = 0; i < k; i++)
            {
                conclusion = conclusion + k_mas[i]+" ";
            }

            StreamWriter writer = new StreamWriter(file2); //создаем «потоковый писатель» и связываем его с файловым потоком 
            writer.Write(conclusion); //записываем в файл
            writer.Close(); //закрываем поток
            reader.Close();
        }
    }
}
