using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Globalization;

namespace OBA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string path = ".\\Setting.ini";
        string machine_name = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "READY";
            // Add COM port
            cbbCom.Items.AddRange(SerialPort.GetPortNames());
            machine_name = Environment.MachineName;
            txtModel.Text = IO_ini.ReadIniFile("Item", "ModelName", "VMC4060", path);
            txtStation.Text = IO_ini.ReadIniFile("Item", "Station", "OBA1", path);

            // Đặt Interval cho Timer (ví dụ: mỗi giây)
            timer2.Interval = 1000; // 1000 mili giây = 1 giây

            // Kích hoạt Timer
            timer2.Start();

            //Lấy giá trị tuần
            DateTime today = DateTime.Now;
            int week = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            lblWeek.Text = "Week :" + week;
        }

        DateTime timestart;
        bool istesting = false;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!istesting) timer1.Enabled = false;
            TimeSpan timeS = DateTime.Now.Subtract(timestart);
            txtTime.Text = string.Format("{0:00}:{1:00}", timeS.Minutes, timeS.Seconds);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            lblDate.Text = "Date : " + string.Format("{0:00}/{1:00}/{2:00}", currentTime.Day, currentTime.Month, currentTime.Year);

            // Lấy giờ hiện tại
            TimeSpan currentTimeOfDay = DateTime.Now.TimeOfDay;
            lblTi.Text = "Time : " + string.Format("{0:00}:{1:00}:{2:00}", currentTimeOfDay.Hours, currentTimeOfDay.Minutes, currentTimeOfDay.Seconds);

            int currentHour = currentTime.Hour;
            int currentMinute = currentTime.Minute;

            if ((currentHour > 19) || (currentHour == 19 && currentMinute >= 30) || (currentHour < 7) || (currentHour == 7 && currentMinute < 30))
            {
                // Chuyển sang màu tối
                this.BackColor = Color.DarkGray;
                lblShift.ForeColor = Color.DarkGray;
                lblShift.Text = "Work Shift: Night";
            }
            else
            {
                // Chuyển sang màu sáng
                this.BackColor = Color.Orange;
                lblShift.ForeColor = Color.Blue;
                lblShift.Text = "Work Shift: Day";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            istesting = true;
        }
    }
}
