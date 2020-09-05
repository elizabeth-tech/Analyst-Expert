﻿using System;
using System.Windows.Forms;

namespace MyProject1
{
    public partial class GeneralLogin : Form
    {
        public GeneralLogin()
        {
            InitializeComponent();
        }

        // Закрытие основной формы входа
        private void buttonCloseLogin_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Сворачивание основной формы входа
        private void buttonTurnLogin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Вход как Эксперт
        private void buttonExpertLogin_Click(object sender, EventArgs e)
        {
            AuthorizationExpert f = new AuthorizationExpert();
            f.Show();
        }

        // Вход как Аналитик
        private void buttonAnalystLogin_Click(object sender, EventArgs e)
        {
            Analyst f = new Analyst();
            f.Show();
        }

        // Для перетаскивания формы
        private void GeneralLogin_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }
    }
}
