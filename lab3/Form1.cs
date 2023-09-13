using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class Form1 : Form
    {
        // Создаем Random object под названием randomizer
        // для генерации случайных чисел.
        Random randomizer = new Random();


        // Эти целочисленные переменные хранят числа
        // для задачи сложения.
        int addend1;
        int addend2;

        // Эти целочисленные переменные хранят числа
        // для задачи вычитания.
        int minuend;
        int subtrahend;

        // Эти целочисленные переменные хранят числа
        // для задачи умножения.
        int multiplicand;
        int multiplier;

        // Эти целочисленные переменные хранят числа
        // для задачи деления.
        int dividend;
        int divisor;

        // Эта целочисленная переменная отслеживает
        // оставшееся время.
        int timeLeft;

        /// <summary>
        /// начинаем тест заполняя все задачи
        /// и запускаем таймер.
        /// </summary>
        public void StartTheQuiz()
        {
            // Заполняем задачу сложения.
            // Генерируем два случайных числа для сложения.
            // Сохраняем значения в переменных addend1 и addend2.
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            // Преобразуем два случайно сгенерированных числа
            // в строки, чтобы их можно было отображать
            // в элементах управления меткой.
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            // «sum» — это имя элемента управления NumericUpDown.
            // Этот шаг гарантирует, что его значение равно нулю, прежде чем
            // добавляем в него любые значения.
            sum.Value = 0;

            // Заполняем задачу на вычитание.
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            // Заполняем задачу на умножение.
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            // Заполняем задачу на деление.
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            // Запускаем таймер.
            timeLeft = 30;
            timeLabel.Text = "30 секунд";
            timer1.Start();

        }

        public Form1()
        {
            
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        /// <summary>
        /// Проверка ответов, чтобы убедиться, что пользователь все правильно решил.
        /// </summary>
        /// <returns>True если ответ правильынй, false в другом случае.</returns>
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                // Если CheckTheAnswer() возвращает true, то пользователь 
                // получил правильный ответ. Отстанавливает время 
                // и показывает MessageBox.
                timer1.Stop();
                MessageBox.Show("Вы правильно ответили на все вопросы!",
                                "Поздравляем! =)");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                // Если CheckTheAnswer() возвращает false, продалжаем считать
                // вниз. Уменьшите оставшееся время на одну секунду и
                // отображаем новое оставшееся время, обновляя 
                // Time Left label.
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + "секунды";
            }
            else
            {
                // Если у пользователя закончилось время, остановить таймер, показать
                // MessageBox, и заполняем ответы.
                timer1.Stop();
                timeLabel.Text = "Время вышло!";
                MessageBox.Show("Вы не закончили вовремя.", "Извините!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            // Выбрать весь ответ в элементе управления NumericUpDown
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
    }
}
