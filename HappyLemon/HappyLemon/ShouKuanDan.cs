﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HappyLemon.model;
using HappyLemon.dao;
using System.IO;
namespace HappyLemon
{
    public partial class ShoukuanDan : Form
    {
        public string[] number1;
        public ShoukuanDan(string []number)
        {
            InitializeComponent();
            number1 = number;
        }
        public ShoukuanDan()
        {
            InitializeComponent();
          
        }
        private void button1_Click(object sender, EventArgs e)
        {
            client_suoyin1 su = new client_suoyin1();
            su.shoukuan = this;
            Console.Write("lalallaal");
            su.type = "收款单";
            su.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          

        }

        private void ShoukuanDan_Load(object sender, EventArgs e)
        {
            ZijinDao p = new ZijinDao();
            int P_Int_newBillCode = p.selectMaxget_moneyid() + 1;//记录收款表中的数字码
            textBox3.Text = DateTime.Now.ToString("yyyyMMdd") + P_Int_newBillCode + "HappyLemon";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            employee_zijin su = new employee_zijin();
            su.shoukuan = this;
            Console.Write("lalallaal");
            su.type = "收款单";
            su.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool b = true;
            if(dataGridView1.Rows.Count==1)
            {
                MessageBox.Show("请填写信息");
                b = false;
            }
            else
            {
                for (int i=0;i<dataGridView1.Rows.Count-1;i++)
                {
                   if(dataGridView1.Rows[i].Cells[0].Value==null)
                    {
                        MessageBox.Show("结算账户不能为空");
                        b = false;
                    }
                    else if(dataGridView1.Rows[i].Cells[1].Value==null)
                    {
                        MessageBox.Show("收款金额不能为空");
                        b = false;
                    }
                    else if(dataGridView1.Rows[i].Cells[2].Value==null)
                    {
                        MessageBox.Show("结算方式不能为空");
                        b = false;
                    }
                    else if(textBox1.Text==null)
                    {
                        MessageBox.Show("供应商不能为空");
                        b = false;
                    }
                    else if(textBox2.Text==null)
                    {
                        MessageBox.Show("操作人不能为空");
                        b = false;
                    }
                }
            }
            if(b==false)
            {

            }
            else
            {
                MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("是否确认保存？", "提交", messButton);
                if(dr==DialogResult.OK)
                {
                    string[] supplier1 = textBox1.Text.Split(' ');
                    string[] employer = textBox2.Text.Split(' ');
                    try
                    {
                        ZijinDao dao = new ZijinDao();
                        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                        {
                            Shoukuan p = new Shoukuan();
                            Console.Write(dataGridView1.Rows[i].Cells[0].Value + "lallalalaalalalalalalla");
                            p.Get_zhanghu = dataGridView1.Rows[i].Cells[0].Value.ToString();
                            p.Get_money = dataGridView1.Rows[i].Cells[1].Value.ToString();
                            p.Get_way = dataGridView1.Rows[i].Cells[2].Value.ToString();
                            if (dataGridView1.Rows[i].Cells[3].Value == null)
                            {
                                p.Mark = "";
                            }
                            else
                            {
                                p.Mark = dataGridView1.Rows[i].Cells[3].Value.ToString();
                            }
                            p.Get_suppliernumber = supplier1[0];
                            p.Employee_number = employer[0];
                            p.Date = Convert.ToDateTime(dateTimePicker1.Text);
                            p.Get_danjuid = textBox3.Text;
                            dao.addShoukuandan(p);
                        }
                        MessageBox.Show("保存成功");
                    }
                    catch (SystemException)
                    {
                        MessageBox.Show("操作有误");
                    }
                }
                else { }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
