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
using MyService.Application.Model;

namespace MyService.ServerApp
{
    /// <summary>
    /// Interaction logic for AddForm.xaml
    /// </summary>
    public partial class AddForm : Window
    {
        public AddForm()
        {
            InitializeComponent();
        }

        public Promotion Model { get; set; }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            this.Model = new Promotion
            {
                Name = this.txbName.Text,
                MinimalCount = int.Parse(this.nudMinimalCount.Text)
            };
            this.DialogResult = true;
            this.Close();
        }
    }
}
