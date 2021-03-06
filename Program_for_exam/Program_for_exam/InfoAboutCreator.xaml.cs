﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Program_for_exam
{
    /// <summary>
    /// Логика взаимодействия для InfoAboutCreator.xaml
    /// </summary>
    public partial class InfoAboutCreator : Window
    {
        public InfoAboutCreator()
        {
            InitializeComponent();

            string info = "\nПрограмму подготовил студент 2 курса Кубанского Государственного университета" +
                ", обучающийся на факультет компьютерных технологии и прикладной математики на направлении " +
                "\"фундаментальная информатика и информационные технологии\":\nТолстиков Илья Вадимович." +
                "\n\nО программе:\n\nДанная программа реализует АРМ продавца магазина офисной техники.\n" +
                "В нею включены такие функция как оформление новой покупки, возврат покупки, удаление покупки, " +
                "добавление нового сотрудника, добавление и удаление скидок, добавление нового товара" +
                " и изменение статуса покупки (с \"доставляется\" на \"получено\")" +
                "\n\nОсобенности работы некоторых функций:\n\nОформление новой покупки:\nПосле того, как все поля будут заполнены" +
                " и будет нажата кнопка \"оформить покупку\", пользователь увидит окно сохранения файла. Если не сохранить файл, тогда" +
                " в дальнейшем нельзя будет выполнить возврат купленного товара." +
                "\n\nУдаление покупки:\nЕсли удалить непоследнюю покупку, тогда номера покупок не будут сдвигаться. Всё дело в том, что" +
                "в таком случае все чеки станут недействительными, ибо их номер не будет совпадать с тем, что стоит в бд, однако при " +
                "удалении последней покупки (обычная ситуация: кассир мог ошибиться в каких-то данных) номер удаленной покупки может быть " +
                "переприсвоен следующей покупке." +
                "\n\nВозврат товара:\nДля того, чтобы оформить возврат необходимо в окне открытия файла выбрать тот, в котором находится " +
                "информация о покупке, подлежащей возврату. Мы суровый магазин, поэтому оформить возврат можно только в тот день, в который" +
                " была совершена покупка, иначе пользователь получит сообщение об ошибке возврата." +
                "\n\nРабота со скидками:\nРабота со скидками осуществляется так же, как в обычных магазинах: если на выбранный товар действует скидка," +
                " тогда и в чек, и в бд запишется цена с учётом этой скидки, если же скидки нет - запишется цена, указанная производителем.";

            infoTextBlock.Text = info;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void newBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
