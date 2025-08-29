using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OBA
{
    public partial class TestOBA : Form
    {
        
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
        int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        // --- Khai báo panel wrapper là biến thành viên ---
        private Panel panelContentWrapper;
        private Panel panelLogWrapper;

        public TestOBA()
        {
            InitializeComponent();

            // ----- Khởi tạo panelContentWrapper (bọc pnlContent) -----
            panelContentWrapper = new Panel();
            panelContentWrapper.Name = "panelContentWrapper";
            panelContentWrapper.BackColor = Color.White;
            panelContentWrapper.Padding = new Padding(10);
            panelContentWrapper.Location = pnlContent.Location;
            panelContentWrapper.Size = pnlContent.Size;
            panelContentWrapper.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelContentWrapper.BorderStyle = BorderStyle.None;
            panelContentWrapper.Paint += panelWrapper_Paint;

            // Thêm pnlContent vào panelContentWrapper
            pnlContent.Parent = panelContentWrapper;
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Margin = new Padding(0);

            // ----- Khởi tạo panelLogWrapper (bọc pnlLog) -----
            panelLogWrapper = new Panel();
            panelLogWrapper.Name = "panelLogWrapper";
            panelLogWrapper.BackColor = Color.White;
            panelLogWrapper.Padding = new Padding(10);
            panelLogWrapper.Location = pnlLog.Location;
            panelLogWrapper.Size = pnlLog.Size;
            panelLogWrapper.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panelLogWrapper.BorderStyle = BorderStyle.None;
            panelLogWrapper.Paint += panelWrapper_Paint;

            // Thêm pnlLog vào panelLogWrapper
            pnlLog.Parent = panelLogWrapper;
            pnlLog.Dock = DockStyle.Fill;
            pnlLog.Margin = new Padding(0);

            // ----- Đưa các wrapper panel vào Form -----
            // (Lưu ý: KHÔNG add pnlContent, pnlLog trực tiếp vào form Controls nữa)
            this.Controls.Add(panelContentWrapper);
            this.Controls.Add(panelLogWrapper);

            // ----- Điều chỉnh vị trí hiển thị các panel -----
            pnlControl.BringToFront();
            panelContentWrapper.BringToFront();
            panelLogWrapper.BringToFront();

            // ----- Style cho Control Panel -----
            pnlControl.Paint += pnlControl_Paint;
            pnlControl.BackColor = Color.White;
            pnlControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;

            // ----- Chỉ để lại wrapper trên Form -----
            pnlContent.Visible = true;
            pnlLog.Visible = true;

            // Set font toàn bộ form cho hiện đại
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            // Bo góc và border cho pnlControl
            pnlControl.Paint += pnlControl_Paint;
            pnlControl.BackColor = Color.White;

            // === pnlContent ===
            //pnlContent.Paint += pnlContent_Paint;
            //pnlContent.BackColor = Color.FromArgb(245, 250, 255); // Xanh nhạt
            //pnlContent.Padding = new Padding(8);
            pnlContent.FlowDirection = FlowDirection.TopDown;
            pnlContent.WrapContents = false;
            pnlContent.AutoScroll = true;
            pnlContent.Padding = new Padding(8, 10, 8, 10);

            // === pnlLog ===
            pnlLog.BorderStyle = BorderStyle.None;
            pnlLog.BackColor = Color.White;
            pnlLog.Font = new Font("Consolas", 10, FontStyle.Regular);
            pnlLog.ForeColor = Color.FromArgb(33, 37, 41);
            pnlLog.Margin = new Padding(5);
            pnlLog.Padding = new Padding(8);
            pnlLog.ReadOnly = true;
            pnlLog.Paint += pnlLog_Paint;

            // Chỉnh style nút START
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.BackColor = Color.FromArgb(255, 123, 85); // Cam pastel
            btnStart.ForeColor = Color.White;
            btnStart.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnStart.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnStart.Width, btnStart.Height, 12, 12));

            // Chỉnh style nút FINISH
            btnFinish.FlatStyle = FlatStyle.Flat;
            btnFinish.FlatAppearance.BorderSize = 0;
            btnFinish.BackColor = Color.FromArgb(56, 182, 255); // Xanh dương sáng
            btnFinish.ForeColor = Color.White;
            btnFinish.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnFinish.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnFinish.Width, btnFinish.Height, 12, 12));

            // Màu nền form hiện đại
            this.BackColor = Color.FromArgb(246, 248, 250); // WhiteSmoke

            lblStatus.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblStatus.ForeColor = Color.White;

            txtModel.Font = new Font("Segoe UI", 16, FontStyle.Bold);

            pnlLog.BackColor = Color.White;
            pnlLog.Font = new Font("Consolas", 10, FontStyle.Regular);

            // Thiết lập cho pnlContent hiển thị đẹp
            pnlContent.FlowDirection = FlowDirection.TopDown;
            pnlContent.WrapContents = false;
            pnlContent.AutoScroll = true;
            pnlContent.Padding = new Padding(8, 10, 8, 10);

            // Đảm bảo mỗi lần cuộn là các panel function vẽ lại border/bo góc ngay
            pnlContent.Scroll += (s, e) =>
            {
                foreach (Control ctrl in pnlContent.Controls)
                    ctrl.Invalidate();
            };

            // Đăng ký sự kiện resize để tự động chỉnh lại chiều rộng các panel function
            pnlContent.Resize += pnlContent_Resize;

        }

        // Hàm vẽ bo góc cho panel wrapper
        // Hàm vẽ bo góc cho panel wrapper
        private void panelWrapper_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            int radius = 18;
            Rectangle rect = new Rectangle(0, 0, p.Width - 1, p.Height - 1);
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                path.CloseAllFigures();
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(Color.LightGray, 2))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        // Hàm vẽ bo góc cho pnlControl nếu muốn đồng bộ
        private void pnlControl_Paint(object sender, PaintEventArgs e)
        {
            int radius = 18;
            Rectangle bounds = new Rectangle(0, 0, pnlControl.Width - 1, pnlControl.Height - 1);
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
                path.AddArc(bounds.Right - radius, bounds.Y, radius, radius, 270, 90);
                path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(bounds.X, bounds.Bottom - radius, radius, radius, 90, 90);
                path.CloseAllFigures();
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(Color.LightGray, 2))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {
            int radius = 18;
            Rectangle bounds = new Rectangle(0, 0, pnlContent.Width - 1, pnlContent.Height - 1);
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
                path.AddArc(bounds.Right - radius, bounds.Y, radius, radius, 270, 90);
                path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(bounds.X, bounds.Bottom - radius, radius, radius, 90, 90);
                path.CloseAllFigures();

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(Color.LightGray, 2))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        private void pnlLog_Paint(object sender, PaintEventArgs e)
        {
            int radius = 18;
            Rectangle bounds = new Rectangle(0, 0, pnlLog.Width - 1, pnlLog.Height - 1);
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
                path.AddArc(bounds.Right - radius, bounds.Y, radius, radius, 270, 90);
                path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(bounds.X, bounds.Bottom - radius, radius, radius, 90, 90);
                path.CloseAllFigures();

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(Color.LightGray, 2))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        //private void pnlContent_Resize(object sender, EventArgs e)
        //{
        //    int scrollbarWidth = SystemInformation.VerticalScrollBarWidth;
        //    int padding = 18; // Tổng padding 2 bên
        //    int newWidth = pnlContent.ClientSize.Width - padding - scrollbarWidth;

        //    foreach (Control ctrl in pnlContent.Controls)
        //    {
        //        if (ctrl is Panel p)
        //            p.Width = newWidth > 0 ? newWidth : 100; // Đảm bảo không bị âm
        //    }
        //}


        string path = ".\\Setting.ini";
        string machine_name = "";
        bool istesting = false;
        DateTime timestart;
        int lower, upper;
        //Double lower, upper;
        Double Vlower, Vupper;
        string checkWeight;
        bool SFISON = true;

        private void FormAutoCreate_Load(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"SFIS ON?\r\n", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                SFISON = true;
            }
            else 
            {
                SFISON = false;
            }

            // Luôn hiện FWV
            lblFWV.Visible = false;
            txtFWV.Visible = false;

            // Lấy giá trị FWV từ Setting.ini và set vào txtFWV (có thể để trống nếu muốn người dùng nhập)
            string fwvExpected = IO_ini.ReadIniFile("Item", "FWV", "", path);
            //txtFWV.Text = fwvExpected;

            lblStatus.Text = "READY";
            // Add COM port
            cboCom.Items.AddRange(SerialPort.GetPortNames());
            machine_name = Environment.MachineName;
            txtModel.Text = IO_ini.ReadIniFile("Item", "ModelName", "VMC4060", path);
            txtStation.Text = IO_ini.ReadIniFile("Item", "Station", "OBA", path);
            checkWeight = IO_ini.ReadIniFile("Item", "checkWeight", "0", path);
            checkVol = IO_ini.ReadIniFile("Item", "checkVol", "0", path);

            // Đổi màu txtStation theo giá trị
            if (txtStation.Text.Trim().ToUpper() == "OBA")
            {
                txtStation.BackColor = Color.DarkOrange; 
                txtStation.ForeColor = Color.White;
            }
            else if (txtStation.Text.Trim().ToUpper() == "OQC1")
            {
                txtStation.BackColor = Color.FromArgb(0, 183, 74);   // Màu xanh lá
                txtStation.ForeColor = Color.White;
            }
            else if (txtStation.Text.Trim().ToUpper() == "OQC2")
            {
                txtStation.BackColor = Color.FromArgb(56, 182, 255);   // Màu xanh lá
                txtStation.ForeColor = Color.White;
            }
            else
            {
                txtStation.BackColor = Color.Gray;
                txtStation.ForeColor = Color.White;
            }

            if (checkWeight == "0")
            {
                lblCartonWeigh.Visible = false;
                //lblFWV.Visible = false;
                label1.Visible = false;
                txtCartonWeigh.Visible = false;
                //txtFWV.Visible = false;
            }
            else
            {
                //string a = IO_ini.ReadIniFile("Item", "lower", "500", path);
                //MessageBox.Show(a);
                //lower = int.Parse(a);
                lower = int.Parse(IO_ini.ReadIniFile("Item", "lower", "500", path));
                upper = int.Parse(IO_ini.ReadIniFile("Item", "upper", "700", path));
                label1.Text = lower.ToString() + "gram~" + upper.ToString() + "gram";
            }

            if (checkVol == "0")
            {
                lblBattery.Visible = false;
                labelVol.Visible = false;
                txtBattery.Visible = false;
            }
            else
            {
                Vlower = Double.Parse(IO_ini.ReadIniFile("Item", "Vol_lower", "5", path));
                Vupper = Double.Parse(IO_ini.ReadIniFile("Item", "Vol_upper", "7", path));
                labelVol.Text = Vlower.ToString() + "V~" + Vupper.ToString() + "V";
            }

            GeneratePanelsFromIni(path);
            AddFailRadioButtonHandlers();
            AddNARadioButtonHandlers();
        }

        //[DllImport("kernel32")]
        //private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        //Add đọc tiếng việt
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        private string ReadIni(string section, string key, string path)
        {
            StringBuilder temp = new StringBuilder(255);
            GetPrivateProfileString(section, key, "", temp, 255, path);
            return temp.ToString();
        }

        private void GeneratePanelsFromIni(string iniPath)
        {
            pnlContent.Controls.Clear();

            string countStr = ReadIni("Item", "Count", iniPath);
            if (!int.TryParse(countStr, out int panelCount)) return;

            int itemMargin = 10;
            int paddingLR = pnlContent.Padding.Left + pnlContent.Padding.Right;
            int scrollbarWidth = SystemInformation.VerticalScrollBarWidth;
            int itemWidth = pnlContent.ClientSize.Width - paddingLR - 2 * itemMargin - scrollbarWidth;
            if (itemWidth < 200) itemWidth = 200;

            for (int i = 1; i <= panelCount; i++)
            {
                string section = $"Func{i}";
                string labelText = ReadIni("Item", section, iniPath);
                string Sub = ReadIni("Item", $"Sub{i}", iniPath);

                if (string.IsNullOrWhiteSpace(labelText)) continue;

                // Panel function
                Panel panel = new Panel
                {
                    Name = $"panelF{i}",
                    Height = 66,
                    Width = itemWidth,
                    Margin = new Padding(itemMargin, 8, itemMargin, 8),
                    BackColor = Color.Linen,
                    BorderStyle = BorderStyle.None // Để custom vẽ border bo góc
                };
                // Vẽ border bo góc
                panel.Paint += FunctionPanel_Paint;

                // Label phụ
                Label labelSub = new Label
                {
                    Name = $"labelSub{i}",
                    Text = Sub,
                    Location = new Point(10, 7),
                    AutoSize = true,
                    Font = new Font("Arial", 10, FontStyle.Regular),
                    ForeColor = Color.Black
                };

                // Label chính
                Label label = new Label
                {
                    Name = $"labelF{i}",
                    Text = labelText,
                    Location = new Point(10, 27),
                    AutoSize = false,
                    Width = itemWidth - 220,
                    MaximumSize = new Size(itemWidth - 220, 0),
                    Font = new Font("Arial", 10, FontStyle.Regular),
                    ForeColor = Color.Black,
                    AutoEllipsis = true,
                    TextAlign = ContentAlignment.MiddleLeft
                };
                label.Height = TextRenderer.MeasureText(label.Text, label.Font, label.MaximumSize, TextFormatFlags.WordBreak).Height;

                // Radio buttons
                int radioY = 20;
                RadioButton pass = new RadioButton
                {
                    Name = $"PASS{i}",
                    Text = "PASS",
                    Location = new Point(itemWidth - 185, radioY),
                    AutoSize = true,
                    ForeColor = Color.ForestGreen
                };
                RadioButton fail = new RadioButton
                {
                    Name = $"FAIL{i}",
                    Text = "FAIL",
                    Location = new Point(itemWidth - 120, radioY),
                    AutoSize = true,
                    ForeColor = Color.Red
                };
                RadioButton na = new RadioButton
                {
                    Name = $"NA{i}",
                    Text = "NA",
                    Location = new Point(itemWidth - 60, radioY),
                    AutoSize = true,
                    ForeColor = Color.DarkBlue
                };

                fail.Click += (s, e) =>
                {
                    MessageBox.Show($"Bạn chọn FAIL tại mục: {labelText}");
                };

                panel.Controls.Add(labelSub);
                panel.Controls.Add(label);
                panel.Controls.Add(pass);
                panel.Controls.Add(fail);
                panel.Controls.Add(na);

                pnlContent.Controls.Add(panel);
            }

            pnlContent_Resize(null, null); // Đảm bảo fit lại khi load
        }


        // Sự kiện resize của pnlContent (gọi một lần trong constructor)
        private void pnlContent_Resize(object sender, EventArgs e)
        {
            int itemMargin = 10;
            int paddingLR = pnlContent.Padding.Left + pnlContent.Padding.Right;
            int scrollbarWidth = SystemInformation.VerticalScrollBarWidth;
            int itemWidth = pnlContent.ClientSize.Width - paddingLR - 2 * itemMargin - scrollbarWidth;
            if (itemWidth < 200) itemWidth = 200;

            foreach (Control ctrl in pnlContent.Controls)
            {
                if (ctrl is Panel p)
                {
                    p.Width = itemWidth;

                    int radioY = 20;
                    var pass = p.Controls.OfType<RadioButton>().FirstOrDefault(x => x.Name.StartsWith("PASS"));
                    var fail = p.Controls.OfType<RadioButton>().FirstOrDefault(x => x.Name.StartsWith("FAIL"));
                    var na = p.Controls.OfType<RadioButton>().FirstOrDefault(x => x.Name.StartsWith("NA"));
                    if (pass != null) pass.Location = new Point(itemWidth - 185, radioY);
                    if (fail != null) fail.Location = new Point(itemWidth - 120, radioY);
                    if (na != null) na.Location = new Point(itemWidth - 60, radioY);
                }
            }
        }


        private void FunctionPanel_Paint(object sender, PaintEventArgs e)
        {
            var p = sender as Panel;
            int radius = 12;
            Rectangle rect = new Rectangle(0, 0, p.Width - 1, p.Height - 1);
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                path.CloseAllFigures();
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(Color.LightGray, 2))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }




        private void AddNARadioButtonHandlers()
        {
            foreach (Control ctrl in pnlContent.Controls)
            {
                if (ctrl is Panel panel)
                {
                    foreach (Control subCtrl in panel.Controls)
                    {
                        if (subCtrl is RadioButton rdo && rdo.Name.StartsWith("NA"))
                        {
                            rdo.Click += NARadioButton_Click;
                        }
                    }
                }
            }
        }

        private void NARadioButton_Click(object sender, EventArgs e)
        {
            RadioButton clicked = sender as RadioButton;
            if (clicked == null) return;

            string radioName = clicked.Name; // Ví dụ: FAIL3
            string indexStr = radioName.Substring(2); // "3"

            // Tìm label tương ứng
            Label label = this.Controls.Find($"labelF{indexStr}", true).FirstOrDefault() as Label;
            // Tìm PASS radio tương ứng
            RadioButton passRadio = this.Controls.Find($"PASS{indexStr}", true).FirstOrDefault() as RadioButton;

            if (label == null || passRadio == null)
            {
                MessageBox.Show("Không tìm thấy Label hoặc PASS tương ứng.", "Lỗi");
                return;
            }

            DialogResult dr = MessageBox.Show($"{label.Text} : NA?\r\n", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                addLogText($" {label.Text} : NA\r\n");

                string remarkInput = Interaction.InputBox("Ghi chú thêm:", "Thông báo", "");
                if (!string.IsNullOrEmpty(remarkInput))
                {
                    pnlRemark.Text = string.IsNullOrEmpty(pnlRemark.Text)
                        ? remarkInput
                        : pnlRemark.Text + "; " + remarkInput;
                }
            }
            else // Nếu chọn No thì chuyển sang PASS
            {
                passRadio.Checked = true;
            }

        }

        private void AddFailRadioButtonHandlers()
        {
            foreach (Control ctrl in pnlContent.Controls)
            {
                if (ctrl is Panel panel)
                {
                    foreach (Control subCtrl in panel.Controls)
                    {
                        if (subCtrl is RadioButton rdo && rdo.Name.StartsWith("FAIL"))
                        {
                            rdo.Click += FailRadioButton_Click;
                        }
                    }
                }
            }
        }

        private void FailRadioButton_Click(object sender, EventArgs e)
        {
            RadioButton clicked = sender as RadioButton;
            if (clicked == null) return;

            string radioName = clicked.Name; // Ví dụ: FAIL3
            string indexStr = radioName.Substring(4); // "3"

            // Tìm label tương ứng
            Label label = this.Controls.Find($"labelF{indexStr}", true).FirstOrDefault() as Label;
            // Tìm PASS radio tương ứng
            RadioButton passRadio = this.Controls.Find($"PASS{indexStr}", true).FirstOrDefault() as RadioButton;

            if (label == null || passRadio == null)
            {
                MessageBox.Show("Không tìm thấy Label hoặc PASS tương ứng.", "Lỗi");
                return;
            }

            DialogResult dr = MessageBox.Show($"{label.Text} FAIL?\r\n", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                addLogText($" {label.Text} : FAIL\r\n");

                string failureInput = Interaction.InputBox("Mô tả lỗi xảy ra:", "Thông báo", "");
                if (!string.IsNullOrEmpty(failureInput))
                {
                    pnlFailure.Text = string.IsNullOrEmpty(pnlFailure.Text)
                        ? failureInput
                        : pnlFailure.Text + "; " + failureInput;
                }

                string remarkInput = Interaction.InputBox("Ghi chú thêm:", "Thông báo", "");
                if (!string.IsNullOrEmpty(remarkInput))
                {
                    pnlRemark.Text = string.IsNullOrEmpty(pnlRemark.Text)
                        ? remarkInput
                        : pnlRemark.Text + "; " + remarkInput;
                }
            }
            else // Nếu chọn No thì chuyển sang PASS
            {
                passRadio.Checked = true;
            }

        }


        private void cbbCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen) serialPort1.Close();
            serialPort1.PortName = cboCom.Text;
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

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (txtCartonWeigh.Text == "")
            {
                return;
            }

            if (double.TryParse(txtCartonWeigh.Text, out double value))
            {
                if (value > upper || value < lower)
                {
                    DialogResult result = MessageBox.Show(
    $"Giá trị {value} trong {txtCartonWeigh.Name} nằm ngoài định mức cho phép!\nValue {value} is out of allowed range in {txtCartonWeigh.Name}!\n" +
    "Bạn có chắc chắn với giá trị được điền không?\nAre you sure with this value?\n" +
    "Nhấn 'Yes' để giữ nguyên. Nhấn 'No' để sửa giá trị.\nPress 'Yes' to keep, 'No' to edit.",
    "Cảnh báo | Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning
);


                    if (result == DialogResult.No) // Nếu chọn "Nhập lại"
                    {
                        txtCartonWeigh.Clear();
                        txtCartonWeigh.Focus();
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
                MessageBox.Show(
    $"Giá trị trong {txtCartonWeigh.Name} không hợp lệ!\nInvalid value in {txtCartonWeigh.Name}!\nVui lòng nhập số.\nPlease input a number.",
    "Lỗi | Error", MessageBoxButtons.OK, MessageBoxIcon.Error
);
                txtCartonWeigh.Clear();
                txtCartonWeigh.Focus();
                return;
            }
        }

        //private void textBox2_Leave(object sender, EventArgs e)
        //{
        //    if (txtFWV.Text == "")
        //    {
        //        return;
        //    }
        //    if (double.TryParse(txtFWV.Text, out double value))
        //    {
        //        if (value > upper || value < lower)
        //        {
        //            DialogResult result = MessageBox.Show($"Giá trị {value} trong {txtFWV.Name} nằm ngoài định mức cho phép!\n" +
        //                "Bạn có chắc chắn với giá trị được điền không \n" +
        //                "Nhấn 'Yes' để giữ nguyên.\nNhấn 'No' để sửa giá trị.", "Cảnh báo",
        //                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

        //            if (result == DialogResult.No) // Nếu chọn "Nhập lại"
        //            {
        //                txtFWV.Clear();
        //                txtFWV.Focus();
        //                return;
        //            }
        //            else
        //            {
        //                return;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show($"Giá trị trong {txtFWV.Name} không hợp lệ! Vui lòng nhập số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        txtFWV.Clear();
        //        txtFWV.Focus();
        //        return;
        //    }
        //}

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (txtFWV.Text == "")
            {
                return;
            }
            // Lấy giá trị FWV chuẩn từ Setting.ini
            string expectedFWV = IO_ini.ReadIniFile("Item", "FWV", "", path).Trim();
            string userFWV = txtFWV.Text.Trim();

            if (!string.Equals(userFWV, expectedFWV, StringComparison.InvariantCultureIgnoreCase))
            {
                MessageBox.Show("Firmware Version sai!\nKiểm tra lại trên Web hoặc liên hệ QE!\nWrong FWV! Check on website or contact QE!", "Sai FWV | Wrong FWV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFWV.Clear();
                txtFWV.Focus();
                return;
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!istesting) timer1.Enabled = false;
            TimeSpan timeS = DateTime.Now.Subtract(timestart);
            txtTime.Text = string.Format("{0:00}:{1:00}", timeS.Minutes, timeS.Seconds);
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
                pnlLog.AppendText(_text);
            }
        }
        string checkVol;
        private void btnFinish_Click(object sender, EventArgs e)
        {
            if(txtStation.Text == "OBA")
            {
                if (txtFWV.Visible && string.IsNullOrWhiteSpace(txtFWV.Text))
                {
                    MessageBox.Show("Vui lòng nhập đúng Firmware Version!\nPlease input correct Firmware Version!",
                        "Thiếu Firmware Version | Missing Firmware Version", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFWV.Focus();
                    return;
                }
                addLogText($"Firmware Version: {txtFWV.Text}\r\n"); // Thêm ngay khi bắt đầu log
            }
            
            if (!istesting)
            {
                MessageBox.Show("Chưa bắt đầu test, không thể kết thúc");
                return;
            }

            // Kiểm tra các panel đã được chọn PASS hoặc FAIL chưa
            foreach (Control panel in pnlContent.Controls)
            {
                if (panel is Panel)
                {
                    RadioButton rbPass = panel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Name.StartsWith("PASS"));
                    RadioButton rbFail = panel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Name.StartsWith("FAIL"));
                    RadioButton rbNA = panel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Name.StartsWith("NA"));
                    Label label = panel.Controls.OfType<Label>().FirstOrDefault();

                    if (rbPass != null && rbFail != null && rbNA != null && !rbPass.Checked && !rbFail.Checked && !rbNA.Checked)
                    {
                        MessageBox.Show(
     (label != null ? $"Vui lòng đánh giá mục: {label.Text}\nPlease rate item: {label.Text}" : "Vui lòng đánh giá đầy đủ các mục.\nPlease complete all items."),
     "Thiếu đánh giá | Missing review", MessageBoxButtons.OK, MessageBoxIcon.Warning
 );
                        return;
                    }
                }
            }

       

            if (checkVol == "1")
            {
                if (txtBattery.Text == "")
                {
                    MessageBox.Show("Vui lòng đo Voltage của pin!\nPlease measure battery voltage!", "Thông báo | Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            istesting = false;
            Maintest();

            // Ẩn Firmware Version khi kết thúc test
            lblFWV.Visible = false;
            txtFWV.Visible = false;
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
            // Cân nặng sau đóng gói
            if (checkVol == "1")
            {
                addLogText($"Battery Voltage: {txtBattery.Text} V\r\n");
            }

            // Duyệt các PASS1 → PASS20
            for (int i = 1; i <= 20; i++)
            {
                RadioButton passRadio = this.Controls.Find($"PASS{i}", true).FirstOrDefault() as RadioButton;
                Label label = this.Controls.Find($"labelF{i}", true).FirstOrDefault() as Label;

                if (passRadio != null && passRadio.Checked && label != null)
                {
                    addLogText($" {label.Text} : PASS\r\n");
                }
            }

            for (int i = 1; i <= 20; i++)
            {
                RadioButton naRadio = this.Controls.Find($"NA{i}", true).FirstOrDefault() as RadioButton;
                Label label = this.Controls.Find($"labelF{i}", true).FirstOrDefault() as Label;

                if (naRadio != null && naRadio.Checked && label != null)
                {
                    addLogText($" {label.Text} : NA\r\n");
                }
            }

            // Ghi chú mô tả lỗi
            if (!string.IsNullOrWhiteSpace(pnlFailure.Text))
            {
                addLogText($"Failure Description : {pnlFailure.Text}\r\n");
            }

            // Ghi chú thêm
            if (!string.IsNullOrWhiteSpace(pnlRemark.Text))
            {
                addLogText($"Remark : {pnlRemark.Text}\r\n");
            }

            // Cân nặng sau đóng gói
            //if (checkWeight == "1")
            //{
            //    addLogText($"The Weight after repack: {textBox2.Text} Kg\r\n");
            //}

            addLogText("\r\n--Finish Test--\r\n");
            //write_log("");

            // Kiểm tra nếu có bất kỳ FAIL nào được chọn thì báo FAIL
            this.Invoke((MethodInvoker)delegate
            {
                bool isAnyFail = false;
                for (int i = 1; i <= 20; i++)
                {
                    RadioButton failRadio = this.Controls.Find($"FAIL{i}", true).FirstOrDefault() as RadioButton;
                    if (failRadio != null && failRadio.Checked)
                    {
                        isAnyFail = true;
                        break;
                    }
                }

                lblStatus.Text = isAnyFail ? "FAIL" : "PASS";
                if (isAnyFail == true)
                {
                    MessageBox.Show("-----FAIL----");
                    Application.Exit();
                }
                else
                {
                    
                }

            });

            if (SFISON == true)
            {
                test_pass1();
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    lblStatus.Text = "PASS";
                    write_log("");
                    istesting = false;
                    txtMac.Text = "";
                    txtCartonWeigh.Text = "";
                    txtFWV.Text = "";

                    this.Invoke((MethodInvoker)delegate
                    {
                        ClearAllRadioButtons(this);
                    });
                });
                
            }
            

            //if (checkBox1.Checked == true)
            //{
            //    test_fail("SEN1 - Maple sensor fail motion ");
            //}

            //else if (checkBox2.Checked == true)
            //{
            //    test_fail("SEN2 - Maple Sensor fail Water Leak ");
            //}

            //else if (checkBox3.Checked == true)
            //{
            //    test_fail("SEN3 - Maple Sensor fail LED, LED donot light ");
            //}

            //else if (checkBox4.Checked == true)
            //{
            //    test_fail("SEN4 - Maple Sensor fail CO alarm detect ");
            //}

            //else if (checkBox5.Checked == true)
            //{
            //    test_fail("SEN5 - Maple Sensor fail Smoke alarm detect ");
            //}

            //else if (checkBox6.Checked == true)
            //{
            //    test_fail("SEN6 - Maple Sensor fail Access Open/Closed the door ");
            //}
            //else test_pass1();
        }

        private void ClearAllRadioButtons(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is RadioButton rb)
                {
                    rb.Checked = false;
                }

                // Nếu control này có con, duyệt tiếp
                if (ctrl.HasChildren)
                {
                    ClearAllRadioButtons(ctrl);
                }
            }
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtMac.Text == "")
            {
                MessageBox.Show("Chưa Scan MAC!\nPlease scan MAC!", "Thông báo | Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (checkWeight == "1")
            {
                if (txtCartonWeigh.Text == "")
                {
                    MessageBox.Show("Chưa đo cân nặng ban đầu!\nPlease input initial weight!", "Thông báo | Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (txtStation.Text == "OQC1")
            {
                lblFWV.Visible = false;
                txtFWV.Visible = false;
            }
            else if ( txtStation.Text == "OBA")
            {
                lblFWV.Visible = true;
                txtFWV.Visible = true;
                txtFWV.Text = ""; // Xóa trắng mỗi lần Start
                txtFWV.Focus();
            }
            

            pnlLog.Clear();
            istesting = true;
            lblStatus.Text = "RUN";
            timestart = DateTime.Now;
            this.Invoke((MethodInvoker)delegate
            {
                timer1.Enabled = true;
            });
            addLogText("\r\n--Start testing--\r\n");
            addLogText("Model Name: " + txtModel.Text + "\r\n");
            addLogText("Mac: " + txtMac.Text + "\r\n");
            //addLogText($"FWV: {txtFWV.Text}\r\n"); // Thêm ngay khi bắt đầu log


            if (checkWeight == "1")
            {
                addLogText($"Check Carton Weight: {txtCartonWeigh.Text} gram\r\n");
            }
        }

        //public void write_log(string error)
        //{
        //    string log_local_path = IO_ini.ReadIniFile("Item", "Local_Path", @"F:\\lsy\ID_LOCAL", ".\\Setting.ini") + "\\" + txtStation.Text + "\\" + txtModel.Text + "  " + DateTime.Now.ToString("dd-MM-yyyy");
        //    string log_server_path = IO_ini.ReadIniFile("Item", "Server_Path", @"F:\\lsy\ID", ".\\Setting.ini") + "\\" + txtStation.Text + "\\" + txtModel.Text + "  " + DateTime.Now.ToString("yyyy-MM-dd") + "\\" + txtMac.Text + ".txt";
        //    FileInfo fServerPath = new FileInfo(log_server_path);
        //    if (error.Length > 0)
        //    {
        //        log_local_path = log_local_path + "\\FAIL\\";
        //    }
        //    else
        //    {
        //        log_local_path = log_local_path + "\\PASS\\";
        //    }
        //    //log_local_path = log_local_path + DateTime.Now.ToString("yyyy-MM-dd");
        //    //make dir
        //    if (!Directory.Exists(log_local_path))
        //    {
        //        Directory.CreateDirectory(log_local_path);
        //    }
        //    if (!Directory.Exists(fServerPath.Directory.FullName))
        //    {
        //        Directory.CreateDirectory(fServerPath.Directory.FullName);
        //    }
        //    this.Invoke((MethodInvoker)delegate
        //    {
        //        //write log
        //        pnlLog.AppendText("Local log: " + log_local_path + "\r\n");

        //        pnlLog.SaveFile(log_local_path + "\\" + txtMac.Text + " - " + DateTime.Now.ToString("hh_mm") + ".txt", RichTextBoxStreamType.UnicodePlainText);
        //        // MessageBox.Show("1234");
        //        pnlLog.AppendText("Server log: " + log_server_path + "\r\n");
        //        string serverLogContent = "";

        //        if (error.Length > 0)
        //        {

        //            serverLogContent = string.Format("{0,-15}{1,-15}{2,-20}{3,-25}{4,-20}{5}{6}", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("HH:mm:ss"), Environment.MachineName, txtModel.Text, txtMac.Text, " ", error);
        //        }
        //        else
        //        {
        //            serverLogContent = string.Format("{0,-15}{1,-15}{2,-20}{3,-25}{4,-20}{5}{6}", DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("HH:mm:ss"), Environment.MachineName, txtModel.Text, txtMac.Text, " ", "PASS");
        //        }
        //        try
        //        {
        //            using (StreamWriter wServer = new StreamWriter(log_server_path, true))
        //            {
        //                wServer.WriteLine(serverLogContent);
        //                wServer.Close();
        //            }
        //        }
        //        catch
        //        {
        //            pnlLog.AppendText("Can't write server log.\r\n");
        //        }
        //    });
        //    DialogResult dr = MessageBox.Show("upload file lên FTP hay không?\r\n", "Thông báo", MessageBoxButtons.YesNo);
        //    if (dr == DialogResult.Yes)
        //    {
        //        // upload file lên FTP
        //        this.Invoke((MethodInvoker)delegate
        //        {
        //            string localFilePath = log_local_path + "\\" + txtMac.Text + " - " + DateTime.Now.ToString("hh_mm") + ".txt";

        //            string ftpBasePath = "/logs"; // Thư mục gốc bạn muốn trên FTP
        //            string ftpFullDirPath = ftpBasePath + "/" + txtStation.Text + "/" + txtModel.Text + "  " + DateTime.Now.ToString("dd-MM-yyyy") + (error.Length > 0 ? "/FAIL/" : "/PASS/");

        //            string fullFtpDir = "ftp://10.220.136.83" + ftpFullDirPath;

        //            // Tạo thư mục từng cấp nếu chưa tồn tại
        //            EnsureFtpDirectoryExists(fullFtpDir, "qelog", "123!");

        //            // Đường dẫn file FTP
        //            string ftpFilePath = fullFtpDir + Path.GetFileName(localFilePath);

        //            // Upload file
        //            UploadFileToFtp(localFilePath, ftpFilePath, "qelog", "123!");
        //        });
        //    }
        //    else if (dr == DialogResult.No)
        //    {

        //    }

        //}

        public void write_log(string error)
        {
            string log_local_path = IO_ini.ReadIniFile("Item", "Local_Path", @"F:\\lsy\ID_LOCAL", ".\\Setting.ini") + "\\" + txtStation.Text + "\\" + txtModel.Text + "  " + DateTime.Now.ToString("HH-mm_dd-MM-yyyy");
            string log_server_path = IO_ini.ReadIniFile("Item", "Server_Path", @"F:\\lsy\ID", ".\\Setting.ini") + "\\" + txtStation.Text + "\\" + txtModel.Text + "  " + DateTime.Now.ToString("yyyy-MM-dd") + "\\" + txtMac.Text + ".txt";
            FileInfo fServerPath = new FileInfo(log_server_path);
            if (error.Length > 0)
                log_local_path = log_local_path + "\\FAIL\\";
            else
                log_local_path = log_local_path + "\\PASS\\";

            if (!Directory.Exists(log_local_path))
                Directory.CreateDirectory(log_local_path);
            if (!Directory.Exists(fServerPath.Directory.FullName))
                Directory.CreateDirectory(fServerPath.Directory.FullName);

            this.Invoke((MethodInvoker)delegate
            {
                pnlLog.AppendText("Local log: " + log_local_path + "\r\n");
                //pnlLog.AppendText($"FWV: {txtFWV.Text}\r\n");  // Ghi FWV vào file log

                pnlLog.SaveFile(log_local_path + "\\" + txtMac.Text + " - " + DateTime.Now.ToString("hh_mm") + ".txt", RichTextBoxStreamType.UnicodePlainText);
                pnlLog.AppendText("Server log: " + log_server_path + "\r\n");

                // Thêm trường FWV vào server log
                string serverLogContent = string.Format("{0,-15}{1,-15}{2,-20}{3,-25}{4,-20}{5,-12}{6}{7}",
                    DateTime.Now.ToString("yyyy-MM-dd"),
                    DateTime.Now.ToString("HH:mm:ss"),
                    Environment.MachineName,
                    txtModel.Text,
                    txtMac.Text,
                    txtFWV.Text,      // FWV được log lại
                    " ",
                    error.Length > 0 ? error : "PASS"
                );

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
                    pnlLog.AppendText("Can't write server log.\r\n");
                }
            });
            DialogResult dr = MessageBox.Show("upload file lên FTP hay không?\r\n", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    string localFilePath = log_local_path + "\\" + txtMac.Text + " - " + DateTime.Now.ToString("hh_mm") + ".txt";
                    string ftpBasePath = "/logs";
                    string ftpFullDirPath = ftpBasePath + "/" + txtStation.Text + "/" + txtModel.Text + "  " + DateTime.Now.ToString("dd-MM-yyyy") + (error.Length > 0 ? "/FAIL/" : "/PASS/");
                    string fullFtpDir = "ftp://10.220.136.83" + ftpFullDirPath;
                    EnsureFtpDirectoryExists(fullFtpDir, "qelog", "123!");
                    string ftpFilePath = fullFtpDir + Path.GetFileName(localFilePath);
                    UploadFileToFtp(localFilePath, ftpFilePath, "qelog", "123!");
                });
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
        string model_name = "";
        bool sfis_ok = false;
        string sfis_tmp = "";
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                Control.CheckForIllegalCrossThreadCalls = false;
                string sfis_recei = serialPort1.ReadExisting().Trim();
                // richTextBox1.AppendText(sfis_recei + "\r\n");
                sfis_tmp = sfis_recei;
                // MessageBox.Show(sfis_recei);
                if (sfis_recei.Contains("PASS"))
                {
                    sfis_ok = true;
                    pnlLog.AppendText("SFIS[" + sfis_recei.Length + "]" + sfis_recei + "\r\n");
                }

                if (sfis_recei.Length == 54 || sfis_recei.Length == 79)
                {
                    //MACHUB(25)+SSNHUB(25)+ModelName(25)+SN_Sensor1(25)+SN_Sensor2(25)+SN_Sensor3(25)+SN_Sensor4(25)+SN_Sensor5(25)+PASS(4)
                    if (istesting)
                    {
                        pnlLog.AppendText(":Still Testing:\r\n");
                        return;
                    }

                    this.Invoke((MethodInvoker)delegate
                    {
                        istesting = false;

                        //lblError.Text = "";
                        txtMac.Text = sfis_recei.Substring(0, 25).Trim();
                        model_name = sfis_recei.Substring(25, 25).Trim();
                        txtModel.Text = model_name;
                        lblStatus.Text = "RUN";
                        lblStatus.Text = "RUN";
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void test_pass1()
        {
            if (lbCom.Text.Equals("OFF"))
            {
                this.Invoke((MethodInvoker)delegate
                {
                    lblStatus.Text = "PASS";
                });
            }
            else
                //send to sfis
                if (lbCom.Text.Equals("ON"))
            {
                //MACHUB(25)+ TesterName(12)
                string sendSFIS = String.Format("{0,-25}{1,-25}{2,-12}", txtMac.Text, txtModel.Text, machine_name);//3. Station[12]

                addLogText("Send SFIS:[" + sendSFIS.Length + "]" + sendSFIS + "\r\n");

                sfis_ok = false;
                serialPort1.Write(sendSFIS + "\r\n");
                for (int i = 0; i < 21; i++)
                {
                    if (sfis_ok) break;
                    Thread.Sleep(1000);
                    if (i == 20)
                    {
                        lblStatus.Text = "FAIL";
                        //lblError.Text = "SFIS00 Send sfis error !";
                        lblStatus.BackColor = Color.Red;
                        break;
                    }
                }
                this.Invoke((MethodInvoker)delegate
                {
                    lblStatus.Text = "PASS";
                });

            }
            write_log("");
            istesting = false;
            txtMac.Text = "";
            txtFWV.Text = "";
            txtBattery.Text = "";
            pnlFailure.Text = "";
            pnlRemark.Text = "";

            this.Invoke((MethodInvoker)delegate
            {
                ClearAllRadioButtons(this);
            });
            // Reset tất cả PASS/FAIL
        }

        public void test_fail(string error)
        {
            //flag = false;
            this.Invoke((MethodInvoker)delegate
            {
                pnlLog.AppendText(error + "\r\n");
                lblStatus.Text = "FAIL";
                //lblError.Text = error;
            });
            write_log(error);
            //send to sfis
            if (lbCom.Text.Equals("ON"))
            {
                string error_code = error.Substring(0, 4);
                //string sendSFIS = String.Format("{0,-25}{1,-12}{2, -4}", txtMAC.Text, machine_name, error_code);//3. Station[12]
                //string sendSFIS = String.Format("{0,-25}{1,-25}{2,-12}{3, -4}", HH, txtSN.Text, machine_name, error_code);
                //string sendSFIS = String.Format("{0,-50}{1,-25}{2,-24}{3, -64}{4,-64}{5,-94}{6,-12}{7,-4}", HH, model_name, txtSN.Text, txtCamera1.Text, txtCamera2.Text, txtCamera3.Text, machine_name, error_code);

                string sendSFIS = String.Format("{0,-25}{1,-25}{2,-12}{3, -4}", txtMac.Text, txtModel.Text, machine_name, error_code.PadRight(4, ' '));               //4. Error

                addLogText("Send SFIS:" + sendSFIS + "\r\n");
                sfis_ok = false;
                //SFIS.Write(sendSFIS + "\r\n");
            }

            istesting = false;
        }

        private string DocModelNameTuINI(string path)
        {
            StringBuilder buffer = new StringBuilder(255);
            GetPrivateProfileString("Item", "ModelName", "", buffer, 255, path);
            return buffer.ToString().Trim();
        }

        // ===== FTP config =====
        private const string FtpHost = "ftp://10.220.136.83";
        private static readonly NetworkCredential FtpCred = new NetworkCredential("sopal", "123!");

        // Tạo request FTP chuẩn
        private FtpWebRequest MakeFtpRequest(string url, string method)
        {
            var req = (FtpWebRequest)WebRequest.Create(url);
            req.Method = method;
            req.Credentials = FtpCred;
            req.UseBinary = true;
            req.UsePassive = true;
            req.KeepAlive = false;
            req.ReadWriteTimeout = 30000;
            req.Timeout = 30000;
            req.Proxy = null;
            return req;
        }

        // Ghép URL FTP an toàn (tránh // thừa)
        private string JoinFtp(params string[] parts)
        {
            string result = null;
            foreach (var raw in parts)
            {
                if (string.IsNullOrWhiteSpace(raw)) continue;
                var p = raw.Trim().Trim('/');
                if (result == null)
                {
                    result = p.StartsWith("ftp://", StringComparison.OrdinalIgnoreCase)
                        ? p.TrimEnd('/')
                        : p;
                }
                else
                {
                    result += "/" + Uri.EscapeDataString(p);
                }
            }
            return result ?? "";
        }

        // Kiểm tra file có tồn tại trên FTP không (dùng GetFileSize)
        private bool FtpFileExists(string ftpFileUrl)
        {
            try
            {
                var req = MakeFtpRequest(ftpFileUrl, WebRequestMethods.Ftp.GetFileSize);
                using (var resp = (FtpWebResponse)req.GetResponse()) { }
                return true;
            }
            catch (WebException ex)
            {
                var resp = ex.Response as FtpWebResponse;
                if (resp != null &&
                    (resp.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable ||
                     resp.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailableOrBusy))
                    return false;
                throw; // lỗi khác: ném lên để biết mà xử lý
            }
        }

        // Tải file FTP về đường dẫn local
        private void DownloadFtpFile(string ftpFileUrl, string localPath)
        {
            var req = MakeFtpRequest(ftpFileUrl, WebRequestMethods.Ftp.DownloadFile);
            using (var resp = (FtpWebResponse)req.GetResponse())
            using (var src = resp.GetResponseStream())
            using (var dst = File.Create(localPath))
            {
                src.CopyTo(dst);
            }
        }

        private async Task OpenSopFromFtpAsync()
        {
            // 1) Lấy model từ INI
            string iniPath = ".\\Setting.ini";
            string modelName = DocModelNameTuINI(iniPath).Trim().ToUpper();
            if (string.IsNullOrEmpty(modelName))
            {
                MessageBox.Show("Không đọc được ModelName từ Setting.ini");
                return;
            }

            string fileName = $"SOP_{modelName}.pdf";

            // 2) Các thư mục ứng viên thường gặp trên server
            string[] candidateDirs =
            {
        "",                 // root FTP
        "SOPs",             // /SOPs
        "F/SOPs",           // /F/SOPs
        "Shared/SOPs",      // /Shared/SOPs
        "F/Shared/SOPs"     // /F/Shared/SOPs
    };

            // 3) Tìm file tồn tại
            string foundUrl = null;
            foreach (var dir in candidateDirs)
            {
                string url = string.IsNullOrEmpty(dir)
                    ? JoinFtp(FtpHost, fileName)
                    : JoinFtp(FtpHost, dir, fileName);

                try
                {
                    if (FtpFileExists(url))
                    {
                        foundUrl = url;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    // Nếu muốn im lặng: bỏ qua; hoặc log vào pnlLog:
                    addLogText($"[FTP check] {url} -> {ex.Message}\r\n");
                }
            }

            if (foundUrl == null)
            {
                MessageBox.Show($"Không tìm thấy {fileName} trên FTP server.");
                return;
            }

            // 4) Tải về thư mục tạm rồi mở ngay
            string tempDir = Path.Combine(Path.GetTempPath(), "SOP_OpenTemp");
            Directory.CreateDirectory(tempDir);
            string localTempFile = Path.Combine(tempDir, fileName);

            try
            {
                // chạy tải về trên thread pool để không đơ UI
                await Task.Run(() => DownloadFtpFile(foundUrl, localTempFile));

                Process.Start(new ProcessStartInfo
                {
                    FileName = localTempFile,
                    UseShellExecute = true
                });

                lblStatus.Text = $"Đã mở: {fileName}";
            }
            catch (WebException wex)
            {
                MessageBox.Show("Lỗi FTP khi tải file: " + wex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không mở được file: " + ex.Message + "\nCó thể bạn chưa cài phần mềm đọc PDF.");
            }
        }


        private async void btnOpenSOP_Click(object sender, EventArgs e)
        {
            await OpenSopFromFtpAsync();
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (txtBattery.Text == "")
            {
                return;
            }

            if (double.TryParse(txtBattery.Text, out double value))
            {
                if (value > Vupper || value < Vlower)
                {
                    DialogResult result = MessageBox.Show($"Giá trị {value} trong {txtBattery.Name} nằm ngoài định mức cho phép!\n" +
                        "Bạn có chắc chắn với giá trị được điền không \n" +
                        "Nhấn 'Yes' để giữ nguyên.\nNhấn 'No' để sửa giá trị.", "Cảnh báo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.No) // Nếu chọn "Nhập lại"
                    {
                        txtBattery.Clear();
                        txtBattery.Focus();
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
                MessageBox.Show($"Giá trị trong {txtBattery.Name} không hợp lệ! Vui lòng nhập số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBattery.Clear();
                txtBattery.Focus();
                return;
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
