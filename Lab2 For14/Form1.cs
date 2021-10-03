using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_For14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Восстанавливаем последние введённые данные
            strTextBox.Text = Properties.Settings.Default.strTextBox.ToString();
            nTextBox.Text = Properties.Settings.Default.nTextBox.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Дана последовательность натуральных чисел. Определить, есть ли в последовательности хотя бы одна n-ка одинаковых “соседних” чисел (n и элементы последовательности вводятся с клавиатуры). В случае положительного ответа определить порядковые номера чисел первой из таких пар.", "Формулировка задания");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] strMass = strTextBox.Text.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = new int[strMass.Length];
            int n = 0;
            bool excTrigger = false;

            //Сохраняем последние введённые данные
            Properties.Settings.Default.strTextBox = strTextBox.Text;
            Properties.Settings.Default.nTextBox = nTextBox.Text;
            Properties.Settings.Default.Save();

            //Переводим массив строк в массив чисел
            try
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = int.Parse(strMass[i]);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при конвертации строки в числа.", "Ахтунг!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                excTrigger = true;
            }

            //Переводим n текстовое в n числовое
            try
            {
                n = int.Parse(nTextBox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при конвертации строки n в число.", "Ахтунг!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                excTrigger = true;
            }

            //Вызов логики
            if (!excTrigger)
            {
                resultTextBox.Text = Logic.Execution(numbers, n);
                strTextBox.Text = "";
                nTextBox.Text = "";
            }
        }

        private void strTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==(char)Keys.Enter)
            {
                nTextBox.Focus();
            }
        }

        private void nTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                button2.PerformClick();
                strTextBox.Focus();
            }
        }
    }

    public static class Logic
    {
        //Основная логика
        public static string Execution(int[] numbers, int n)
        {
            bool trigger = false;
            int counter = 0, i = 0;
            string outMessage = "";
            while ((trigger != true) && (i < numbers.Length-1))
            {
                if (numbers[i] == numbers[i + 1])
                {
                    counter += 1;
                    if (counter == n - 1)
                    {
                        trigger = true;
                        outMessage = "Номера первой найденной " + n + "-ки: ";
                        for (int j = (i + 1) - (n - 1); j <= i + 1; j++)
                        {
                            outMessage += j+1 + " ";
                        }
                    }
                }
                else
                {
                    counter = 0;
                }
                i++;
            }
            if (!trigger)
            {
                outMessage = "Пары не найдены";
            }

            return outMessage;
        }
    }
}
