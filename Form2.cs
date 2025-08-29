using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Net;
using Microsoft.VisualBasic;

namespace OBA
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void cbbCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen) serialPort1.Close();
            serialPort1.PortName = cbbCom.Text;
            try
            {
                serialPort1.Open();
            }
            catch (Exception exp)
            {
                MessageBox.Show("Can't open com port !!!\r\n" + exp.Message);
                //return;
            }
            if (serialPort1.IsOpen)
            {
                //btnStart.Enabled = false;
                lbCom.Text = "ON";
                lbCom.BackColor = Color.Green;
                lblsfis.Text = "SFIS ON";
                lblsfis.BackColor = Color.Green;
            }
            else
            {
                lbCom.Text = "OFF";
                lbCom.BackColor = Color.Red;
            }
        }

        private void lblStatus_TextChanged(object sender, EventArgs e)
        {
            switch (lblStatus.Text)
            {
                case "READY":
                    lblStatus.BackColor = Color.RoyalBlue;
                    lblStatus.ForeColor = Color.White;
                    break;
                case "RUN":
                    lblStatus.BackColor = Color.Gold;
                    lblStatus.ForeColor = Color.Green;
                    break;
                case "WAIT":
                    lblStatus.BackColor = Color.Orange;
                    lblStatus.ForeColor = Color.Green;
                    break;
                case "PASS":
                    lblStatus.BackColor = Color.Green;
                    lblStatus.ForeColor = Color.White;
                    break;
                case "FAIL":
                    lblStatus.BackColor = Color.Red;
                    lblStatus.ForeColor = Color.Yellow;
                    break;
                default: break;
            }
        }
        string path = ".\\Setting.ini";
        string machine_name = "";
        bool istesting = false;
        DateTime timestart;

        Double lower, upper;

        string Func1, Func2, Func3, Func4, Func5, Func6, Func7, Func8, Func9, Func10, Func11, Func12, Func13, Func14, Func15, Func16, Func17, Func18, Func19, Func20;

        private void FAIL1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"{Func1} FAIL?\r\n  ", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                addLogText($" {Func1} : FAIL\r\n");
                if (FailureDescription.Text != "")
                {
                    FailureDescription.Text += "; " + Interaction.InputBox("Mô tả lỗi xảy ra:", "Thông báo", "");
                }
                else
                {
                    FailureDescription.Text = Interaction.InputBox("Mô tả lỗi xảy ra:", "Thông báo", "");
                }

                if (Remark.Text != "")
                {
                    Remark.Text += "; " + Interaction.InputBox("Ghi chú thêm:", "Thông báo", "");
                }
                else
                {
                    Remark.Text = Interaction.InputBox("Ghi chú thêm:", "Thông báo", "");
                }
            }
            if (dr == DialogResult.No)
            {
                PASS1.Checked = true;
            }
        }

        private void FAIL2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"{Func2} FAIL?\r\n  ", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                addLogText($" {Func2} : FAIL\r\n");
                if (FailureDescription.Text != "")
                {
                    FailureDescription.Text += "; " + Interaction.InputBox("Mô tả lỗi xảy ra:", "Thông báo", "");
                }
                else
                {
                    FailureDescription.Text = Interaction.InputBox("Mô tả lỗi xảy ra:", "Thông báo", "");
                }

                if (Remark.Text != "")
                {
                    Remark.Text += "; " + Interaction.InputBox("Ghi chú thêm:", "Thông báo", "");
                }
                else
                {
                    Remark.Text = Interaction.InputBox("Ghi chú thêm:", "Thông báo", "");
                }
            }
            if (dr == DialogResult.No)
            {
                PASS2.Checked = true;
            }
        }

        private void FAIL3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"{Func3} FAIL?\r\n  ", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                addLogText($" {Func3} : FAIL\r\n");
                if (FailureDescription.Text != "")
                {
                    FailureDescription.Text += "; " + Interaction.InputBox("Mô tả lỗi xảy ra:", "Thông báo", "");
                }
                else
                {
                    FailureDescription.Text = Interaction.InputBox("Mô tả lỗi xảy ra:", "Thông báo", "");
                }

                if (Remark.Text != "")
                {
                    Remark.Text += "; " + Interaction.InputBox("Ghi chú thêm:", "Thông báo", "");
                }
                else
                {
                    Remark.Text = Interaction.InputBox("Ghi chú thêm:", "Thông báo", "");
                }
            }
            if (dr == DialogResult.No)
            {
                PASS3.Checked = true;
            }
        }

        private void FAIL4_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"{Func4} FAIL?\r\n  ", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                addLogText($" {Func4} : FAIL\r\n");
                if (FailureDescription.Text != "")
                {
                    FailureDescription.Text += "; " + Interaction.InputBox("Mô tả lỗi xảy ra:", "Thông báo", "");
                }
                else
                {
                    FailureDescription.Text = Interaction.InputBox("Mô tả lỗi xảy ra:", "Thông báo", "");
                }

                if (Remark.Text != "")
                {
                    Remark.Text += "; " + Interaction.InputBox("Ghi chú thêm:", "Thông báo", "");
                }
                else
                {
                    Remark.Text = Interaction.InputBox("Ghi chú thêm:", "Thông báo", "");
                }
            }
            if (dr == DialogResult.No)
            {
                PASS4.Checked = true;
            }
        }

        private void FAIL5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"{Func5} FAIL?\r\n  ", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                addLogText($" {Func5} : FAIL\r\n");
                if (FailureDescription.Text != "")
                {
                    FailureDescription.Text += "; " + Interaction.InputBox("Mô tả lỗi xảy ra:", "Thông báo", "");
                }
                else
                {
                    FailureDescription.Text = Interaction.InputBox("Mô tả lỗi xảy ra:", "Thông báo", "");
                }

                if (Remark.Text != "")
                {
                    Remark.Text += "; " + Interaction.InputBox("Ghi chú thêm:", "Thông báo", "");
                }
                else
                {
                    Remark.Text = Interaction.InputBox("Ghi chú thêm:", "Thông báo", "");
                }
            }
            if (dr == DialogResult.No)
            {
                PASS5.Checked = true;
            }
        }

        private void FAIL6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"{Func6} FAIL?\r\n  ", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                addLogText($" {Func6} : FAIL\r\n");
                if (FailureDescription.Text != "")
                {
                    FailureDescription.Text += "; " + Interaction.InputBox("Mô tả lỗi xảy ra:", "Thông báo", "");
                }
                else
                {
                    FailureDescription.Text = Interaction.InputBox("Mô tả lỗi xảy ra:", "Thông báo", "");
                }

                if (Remark.Text != "")
                {
                    Remark.Text += "; " + Interaction.InputBox("Ghi chú thêm:", "Thông báo", "");
                }
                else
                {
                    Remark.Text = Interaction.InputBox("Ghi chú thêm:", "Thông báo", "");
                }
            }
            if (dr == DialogResult.No)
            {
                PASS6.Checked = true;
            }
        }

        private void FAIL7_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"{Func7} FAIL?\r\n  ", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                addLogText($" {Func7} : FAIL\r\n");
                if (FailureDescription.Text != "")
                {
                    FailureDescription.Text += "; " + Interaction.InputBox("Mô tả lỗi xảy ra:", "Thông báo", "");
                }
                else
                {
                    FailureDescription.Text = Interaction.InputBox("Mô tả lỗi xảy ra:", "Thông báo", "");
                }

                if (Remark.Text != "")
                {
                    Remark.Text += "; " + Interaction.InputBox("Ghi chú thêm:", "Thông báo", "");
                }
                else
                {
                    Remark.Text = Interaction.InputBox("Ghi chú thêm:", "Thông báo", "");
                }
            }
            if (dr == DialogResult.No)
            {
                PASS7.Checked = true;
            }
        }

        private void FAIL8_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"{Func8} FAIL?\r\n  ", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                addLogText($" {Func8} : FAIL\r\n");
                if (FailureDescription.Text != "")
                {
                    FailureDescription.Text += "; " + Interaction.InputBox("Mô tả lỗi xảy ra:", "Thông báo", "");
                }
                else
                {
                    FailureDescription.Text = Interaction.InputBox("Mô tả lỗi xảy ra:", "Thông báo", "");
                }

                if (Remark.Text != "")
                {
                    Remark.Text += "; " + Interaction.InputBox("Ghi chú thêm:", "Thông báo", "");
                }
                else
                {
                    Remark.Text = Interaction.InputBox("Ghi chú thêm:", "Thông báo", "");
                }
            }
            if (dr == DialogResult.No)
            {
                PASS8.Checked = true;
            }
        }

        private void FAIL9_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"{Func9} FAIL?\r\n  ", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                addLogText($" {Func9} : FAIL\r\n");
                if (FailureDescription.Text != "")
                {
                    FailureDescription.Text += "; " + Interaction.InputBox("Mô tả lỗi xảy ra:", "Thông báo", "");
                }
                else
                {
                    FailureDescription.Text = Interaction.InputBox("Mô tả lỗi xảy ra:", "Thông báo", "");
                }

                if (Remark.Text != "")
                {
                    Remark.Text += "; " + Interaction.InputBox("Ghi chú thêm:", "Thông báo", "");
                }
                else
                {
                    Remark.Text = Interaction.InputBox("Ghi chú thêm:", "Thông báo", "");
                }
            }
            if (dr == DialogResult.No)
            {
                PASS9.Checked = true;
            }
        }

        private void FAIL10_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"{Func10} FAIL?\r\n  ", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                addLogText($" {Func10} : FAIL\r\n");
                if (FailureDescription.Text != "")
                {
                    FailureDescription.Text += "; " + Interaction.InputBox("Mô tả lỗi xảy ra:", "Thông báo", "");
                }
                else
                {
                    FailureDescription.Text = Interaction.InputBox("Mô tả lỗi xảy ra:", "Thông báo", "");
                }

                if (Remark.Text != "")
                {
                    Remark.Text += "; " + Interaction.InputBox("Ghi chú thêm:", "Thông báo", "");
                }
                else
                {
                    Remark.Text = Interaction.InputBox("Ghi chú thêm:", "Thông báo", "");
                }
            }
            if (dr == DialogResult.No)
            {
                PASS10.Checked = true;
            }
        }

        private void FAIL11_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"{Func11} FAIL?\r\n  ", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                addLogText($" {Func11} : FAIL\r\n");
                if (FailureDescription.Text != "")
                {
                    FailureDescription.Text += "; " + Interaction.InputBox("Mô tả lỗi xảy ra:", "Thông báo", "");
                }
                else
                {
                    FailureDescription.Text = Interaction.InputBox("Mô tả lỗi xảy ra:", "Thông báo", "");
                }

                if (Remark.Text != "")
                {
                    Remark.Text += "; " + Interaction.InputBox("Ghi chú thêm:", "Thông báo", "");
                }
                else
                {
                    Remark.Text = Interaction.InputBox("Ghi chú thêm:", "Thông báo", "");
                }
            }
            if (dr == DialogResult.No)
            {
                PASS11.Checked = true;
            }
        }

        private void FAIL12_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"{Func12} FAIL?\r\n  ", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                addLogText($" {Func12} : FAIL\r\n");
                if (FailureDescription.Text != "")
                {
                    FailureDescription.Text += "; " + Interaction.InputBox("Mô tả lỗi xảy ra:", "Thông báo", "");
                }
                else
                {
                    FailureDescription.Text = Interaction.InputBox("Mô tả lỗi xảy ra:", "Thông báo", "");
                }

                if (Remark.Text != "")
                {
                    Remark.Text += "; " + Interaction.InputBox("Ghi chú thêm:", "Thông báo", "");
                }
                else
                {
                    Remark.Text = Interaction.InputBox("Ghi chú thêm:", "Thông báo", "");
                }
            }
            if (dr == DialogResult.No)
            {
                PASS12.Checked = true;
            }
        }

        private void FAIL13_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"{Func13} FAIL?\r\n  ", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                addLogText($" {Func13} : FAIL\r\n");
                if (FailureDescription.Text != "")
                {
                    FailureDescription.Text += "; " + Interaction.InputBox("Mô tả lỗi xảy ra:", "Thông báo", "");
                }
                else
                {
                    FailureDescription.Text = Interaction.InputBox("Mô tả lỗi xảy ra:", "Thông báo", "");
                }

                if (Remark.Text != "")
                {
                    Remark.Text += "; " + Interaction.InputBox("Ghi chú thêm:", "Thông báo", "");
                }
                else
                {
                    Remark.Text = Interaction.InputBox("Ghi chú thêm:", "Thông báo", "");
                }
            }
            if (dr == DialogResult.No)
            {
                PASS13.Checked = true;
            }
        }

        private void FAIL14_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"{Func14} FAIL?\r\n  ", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                addLogText($" {Func14} : FAIL\r\n");
                if (FailureDescription.Text != "")
                {
                    FailureDescription.Text += "; " + Interaction.InputBox("Mô tả lỗi xảy ra:", "Thông báo", "");
                }
                else
                {
                    FailureDescription.Text = Interaction.InputBox("Mô tả lỗi xảy ra:", "Thông báo", "");
                }

                if (Remark.Text != "")
                {
                    Remark.Text += "; " + Interaction.InputBox("Ghi chú thêm:", "Thông báo", "");
                }
                else
                {
                    Remark.Text = Interaction.InputBox("Ghi chú thêm:", "Thông báo", "");
                }
            }
            if (dr == DialogResult.No)
            {
                PASS14.Checked = true;
            }
        }

        private void FAIL15_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"{Func15} FAIL?\r\n  ", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                addLogText($" {Func15} : FAIL\r\n");
                if (FailureDescription.Text != "")
                {
                    FailureDescription.Text += "; " + Interaction.InputBox("Mô tả lỗi xảy ra:", "Thông báo", "");
                }
                else
                {
                    FailureDescription.Text = Interaction.InputBox("Mô tả lỗi xảy ra:", "Thông báo", "");
                }

                if (Remark.Text != "")
                {
                    Remark.Text += "; " + Interaction.InputBox("Ghi chú thêm:", "Thông báo", "");
                }
                else
                {
                    Remark.Text = Interaction.InputBox("Ghi chú thêm:", "Thông báo", "");
                }
            }
            if (dr == DialogResult.No)
            {
                PASS15.Checked = true;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                return;
            }

            if (double.TryParse(textBox1.Text, out double value))
            {
                if (value > upper || value < lower)
                {
                    DialogResult result = MessageBox.Show($"Giá trị {value} trong {textBox1.Name} nằm ngoài định mức cho phép!\n" +
                        "Bạn có chắc chắn với giá trị được điền không \n" +
                        "Nhấn 'Yes' để giữ nguyên.\nNhấn 'No' để sửa giá trị.", "Cảnh báo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.No) // Nếu chọn "Nhập lại"
                    {
                        textBox1.Clear();
                        textBox1.Focus();
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show($"Giá trị trong {textBox1.Name} không hợp lệ! Vui lòng nhập số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
                textBox1.Focus();
                return;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                return;
            }
            if (double.TryParse(textBox2.Text, out double value))
            {
                if (value > upper || value < lower)
                {
                    DialogResult result = MessageBox.Show($"Giá trị {value} trong {textBox2.Name} nằm ngoài định mức cho phép!\n" +
                        "Bạn có chắc chắn với giá trị được điền không \n" +
                        "Nhấn 'Yes' để giữ nguyên.\nNhấn 'No' để sửa giá trị.", "Cảnh báo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.No) // Nếu chọn "Nhập lại"
                    {
                        textBox2.Clear();
                        textBox2.Focus();
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show($"Giá trị trong {textBox2.Name} không hợp lệ! Vui lòng nhập số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Clear();
                textBox2.Focus();
                return;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!istesting) timer1.Enabled = false;
            TimeSpan timeS = DateTime.Now.Subtract(timestart);
            txtTime.Text = string.Format("{0:00}:{1:00}", timeS.Minutes, timeS.Seconds);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "READY";
            // Add COM port
            cbbCom.Items.AddRange(SerialPort.GetPortNames());
            machine_name = Environment.MachineName;
            txtModel.Text = IO_ini.ReadIniFile("Item", "ModelName", "VMC4060", path);
            txtStation.Text = IO_ini.ReadIniFile("Item", "Station", "OBA", path);
            Func1 = IO_ini.ReadIniFile("Item", "Func1", "Function 1", path);
            Func2 = IO_ini.ReadIniFile("Item", "Func2", "Function 2", path);
            Func3 = IO_ini.ReadIniFile("Item", "Func3", "Function 3", path);
            Func4 = IO_ini.ReadIniFile("Item", "Func4", "Function 4", path);
            Func5 = IO_ini.ReadIniFile("Item", "Func5", "", path);
            Func6 = IO_ini.ReadIniFile("Item", "Func6", "", path);
            Func7 = IO_ini.ReadIniFile("Item", "Func7", "", path);
            Func8 = IO_ini.ReadIniFile("Item", "Func8", "", path);
            Func9 = IO_ini.ReadIniFile("Item", "Func9", "", path);
            Func10 = IO_ini.ReadIniFile("Item", "Func10", "", path);
            Func11 = IO_ini.ReadIniFile("Item", "Func11", "", path);
            Func12 = IO_ini.ReadIniFile("Item", "Func12", "", path);
            Func13 = IO_ini.ReadIniFile("Item", "Func13", "", path);
            Func14 = IO_ini.ReadIniFile("Item", "Func14", "", path);
            Func15 = IO_ini.ReadIniFile("Item", "Func15", "", path);

            lower = Double.Parse(IO_ini.ReadIniFile("Item", "lower", "5", path));
            upper = Double.Parse(IO_ini.ReadIniFile("Item", "upper", "7", path));
            label1.Text = lower.ToString() + "Kg~" + upper.ToString() + "Kg";

            labelF1.Text = Func1;
            labelF2.Text = Func2;
            labelF3.Text = Func3;
            labelF4.Text = Func4;

            if (Func5 == "")
            {
                panelF5.Visible = false;
            }
            else
            {
                labelF5.Text = Func5;
            }
            if (Func6 == "")
            {
                panelF6.Visible = false;
            }
            else labelF6.Text = Func6;

            if (Func7 == "")
            {
                panelF7.Visible = false;
            }
            else labelF7.Text = Func7;

            if (Func8 == "")
            {
                panelF8.Visible = false;
            }
            else labelF8.Text = Func8;

            if (Func9 == "")
            {
                panelF9.Visible = false;
            }
            else labelF9.Text = Func9;

            if (Func10 == "")
            {
                panelF10.Visible = false;
            }
            else labelF10.Text = Func10;

            if (Func11 == "")
            {
                panelF11.Visible = false;
            }
            else labelF11.Text = Func11;

            if (Func12 == "")
            {
                panelF12.Visible = false;
            }
            else labelF12.Text = Func12;

            if (Func13 == "")
            {
                panelF13.Visible = false;
            }
            else labelF13.Text = Func13;

            if (Func14 == "")
            {
                panelF14.Visible = false;
            }
            else labelF14.Text = Func14;

            if (Func15 == "")
            {
                panelF15.Visible = false;
            }
            else labelF15.Text = Func15;

        }

        private delegate void addText(string _text);
        public void addLogText(string _text)
        {
            if (this.InvokeRequired)
            {
                addText at = new addText(addLogText);
                this.Invoke(at, new object[] { _text });
            }
            else
            {
                richTextBox1.AppendText(_text);
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if(!istesting)
            {
                MessageBox.Show("Chưa ban đầu test, không thể kết thúc");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Đo cân nặng sau khi đóng lại hộp");
                return;
            }
            istesting = false;
            Maintest();
        }

        private void Maintest()
        {
            GC.Collect();
            Thread tMain = new Thread(Allcheck_OK);
            tMain.IsBackground = true;
            tMain.Start();
        }

        private void Allcheck_OK()
        {
            if (PASS1.Checked == true)
                addLogText($" {Func1} : PASS\r\n");
            if (PASS2.Checked == true)
                addLogText($" {Func2} : PASS\r\n");
            if (PASS3.Checked == true)
                addLogText($" {Func3} : PASS\r\n");
            if (PASS4.Checked == true)
                addLogText($" {Func4} : PASS\r\n");
            if (PASS5.Checked == true)
                addLogText($" {Func5} : PASS\r\n");
            if (PASS6.Checked == true)
                addLogText($" {Func6} : PASS\r\n");
            if (PASS7.Checked == true)
                addLogText($" {Func7} : PASS\r\n");
            if (PASS8.Checked == true)
                addLogText($" {Func8} : PASS\r\n");
            if (PASS9.Checked == true)
                addLogText($" {Func9} : PASS\r\n");
            if (PASS10.Checked == true)
                addLogText($" {Func10} : PASS\r\n");
            if (PASS11.Checked == true)
                addLogText($" {Func11} : PASS\r\n");
            if (PASS12.Checked == true)
                addLogText($" {Func12} : PASS\r\n");
            if (PASS13.Checked == true)
                addLogText($" {Func13} : PASS\r\n");
            if (PASS14.Checked == true)
                addLogText($" {Func14} : PASS\r\n");
            if (PASS15.Checked == true)
                addLogText($" {Func15} : PASS\r\n");

            this.Invoke((MethodInvoker)delegate
            {
                if (FAIL1.Checked == true || FAIL2.Checked == true || FAIL3.Checked == true || FAIL4.Checked == true || FAIL5.Checked == true || FAIL6.Checked == true || FAIL7.Checked == true || FAIL8.Checked == true || FAIL9.Checked == true || FAIL10.Checked == true || FAIL11.Checked == true || FAIL12.Checked == true || FAIL13.Checked == true || FAIL14.Checked == true || FAIL15.Checked == true)
                {
                    lblStatus.Text = "FAIL";
                }
                else
                    lblStatus.Text = "PASS";
            });

            if(FailureDescription.Text != "")
            {
                addLogText($"Failure Description : {FailureDescription.Text}\r\n");
            }
            
            if (Remark.Text != "")
            {
                addLogText($"Remark : {Remark.Text}\r\n");
            }

            addLogText($" The Weight after repack: {textBox2.Text}\r\n");

            addLogText("\r\n--Finish Test--\r\n");
            write_log("");

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is RadioButton rb && (rb.Name.StartsWith("PASS") || rb.Name.StartsWith("FAIL")))
                {
                    rb.Checked = false;
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if(txtMac.Text == "" || textBox1.Text =="")
            {
                MessageBox.Show("Chưa Scan MAC hoặc đo cân nặng ban đầu");
                return;
            }
            richTextBox1.Clear();
            istesting = true;
            lblStatus.Text = "RUN";
            timestart = DateTime.Now;
            this.Invoke((MethodInvoker)delegate
            {
                timer1.Enabled = true;
            });
            addLogText("\r\n--Start testing--\r\n");
            addLogText("Mac: " + txtMac.Text + "\r\n");
            addLogText($" Initial Weight: {textBox1.Text}\r\n");
        }

        public void write_log(string error)
        {
            string log_local_path = IO_ini.ReadIniFile("Item", "Local_Path", @"F:\\lsy\ID_LOCAL", ".\\Setting.ini") + "\\" + txtStation.Text + "\\" + txtModel.Text + "  " + DateTime.Now.ToString("dd-MM-yyyy");
            string log_server_path = IO_ini.ReadIniFile("Item", "Server_Path", @"F:\\lsy\ID", ".\\Setting.ini") + "\\" + txtStation.Text + "\\" + txtModel.Text + "  " + DateTime.Now.ToString("yyyy-MM-dd") + "\\" + txtMac.Text + ".txt";
            FileInfo fServerPath = new FileInfo(log_server_path);
            if (error.Length > 0)
            {
                log_local_path = log_local_path + "\\FAIL\\";
            }
            else
            {
                log_local_path = log_local_path + "\\PASS\\";
            }
            //log_local_path = log_local_path + DateTime.Now.ToString("yyyy-MM-dd");
            //make dir
            if (!Directory.Exists(log_local_path))
            {
                Directory.CreateDirectory(log_local_path);
            }
            if (!Directory.Exists(fServerPath.Directory.FullName))
            {
                Directory.CreateDirectory(fServerPath.Directory.FullName);
            }
            this.Invoke((MethodInvoker)delegate
            {
                //write log
                richTextBox1.AppendText("Local log: " + log_local_path + "\r\n");

                richTextBox1.SaveFile(log_local_path + "\\" + txtMac.Text + " - " + DateTime.Now.ToString("hh_mm") + ".txt", RichTextBoxStreamType.UnicodePlainText);
                // MessageBox.Show("1234");
                richTextBox1.AppendText("Server log: " + log_server_path + "\r\n");
                string serverLogContent = "";

                if (error.Length > 0)
                {

                    serverLogContent = string.Format("{0,-15}{1,-15}{2,-20}{3,-25}{4,-20}{5}{6}", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("HH:mm:ss"), Environment.MachineName, txtModel.Text, txtMac.Text, " ", error);
                }
                else
                {
                    serverLogContent = string.Format("{0,-15}{1,-15}{2,-20}{3,-25}{4,-20}{5}{6}", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("HH:mm:ss"), Environment.MachineName, txtModel.Text, txtMac.Text, " ", "PASS");
                }
                try
                {
                    using (StreamWriter wServer = new StreamWriter(log_server_path, true))
                    {
                        wServer.WriteLine(serverLogContent);
                        wServer.Close();
                    }
                }
                catch
                {
                    richTextBox1.AppendText("Can't write server log.\r\n");
                }
            });
            DialogResult dr = MessageBox.Show("upload file lên FTP hay không?\r\n", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                // upload file lên FTP
                this.Invoke((MethodInvoker)delegate
                {
                    string localFilePath = log_local_path + "\\" + txtMac.Text + " - " + DateTime.Now.ToString("hh_mm") + ".txt";

                    string ftpBasePath = "/logs"; // Thư mục gốc bạn muốn trên FTP
                    string ftpFullDirPath = ftpBasePath + "/" + txtStation.Text + "/" + txtModel.Text + "  " + DateTime.Now.ToString("dd-MM-yyyy") + (error.Length > 0 ? "/FAIL/" : "/PASS/");

                    string fullFtpDir = "ftp://10.220.136.83" + ftpFullDirPath;

                    // Tạo thư mục từng cấp nếu chưa tồn tại
                    EnsureFtpDirectoryExists(fullFtpDir, "qelog", "123!");

                    // Đường dẫn file FTP
                    string ftpFilePath = fullFtpDir + Path.GetFileName(localFilePath);

                    // Upload file
                    UploadFileToFtp(localFilePath, ftpFilePath, "qelog", "123!");
                });
            }
            else if (dr == DialogResult.No)
            {

            }

        }

        public bool FtpDirectoryExists(string directoryPath, string ftpUsername, string ftpPassword)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(directoryPath);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                request.UseBinary = true;
                request.UsePassive = true;
                request.KeepAlive = false;

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    return true;
                }
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response != null && response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public void CreateFtpDirectory(string directoryPath, string ftpUsername, string ftpPassword)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(directoryPath);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                request.UseBinary = true;
                request.UsePassive = true;
                request.KeepAlive = false;

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                }
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response != null && response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                }
                else
                {
                    throw;
                }
            }
        }

        public void EnsureFtpDirectoryExists(string fullPath, string ftpUsername, string ftpPassword)
        {
            string[] parts = fullPath.Replace("ftp://10.220.136.83", "").Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            string currentPath = "ftp://10.220.136.83";

            foreach (string part in parts)
            {
                currentPath += "/" + part;
                if (!FtpDirectoryExists(currentPath, ftpUsername, ftpPassword))
                {
                    CreateFtpDirectory(currentPath, ftpUsername, ftpPassword);
                }
            }
        }

        public void UploadFileToFtp(string localFile, string ftpFullPath, string ftpUsername, string ftpPassword)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpFullPath);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                request.UseBinary = true;
                request.UsePassive = true;
                request.KeepAlive = false;

                byte[] fileContents = File.ReadAllBytes(localFile);
                request.ContentLength = fileContents.Length;

                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(fileContents, 0, fileContents.Length);
                }

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    Console.WriteLine($"Upload File Complete, status {response.StatusDescription}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("FTP upload failed: " + ex.Message);
            }
        }
    }
}
