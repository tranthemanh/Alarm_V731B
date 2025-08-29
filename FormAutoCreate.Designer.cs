namespace OBA
{
    partial class TestOBA
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestOBA));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.pnlContent = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlLog = new System.Windows.Forms.RichTextBox();
            this.lblRemark = new System.Windows.Forms.Label();
            this.pnlFailure = new System.Windows.Forms.TextBox();
            this.lblFailure = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtModel = new System.Windows.Forms.Label();
            this.txtFWV = new System.Windows.Forms.TextBox();
            this.lblFWV = new System.Windows.Forms.Label();
            this.txtCartonWeigh = new System.Windows.Forms.TextBox();
            this.lblCartonWeigh = new System.Windows.Forms.Label();
            this.txtMac = new System.Windows.Forms.TextBox();
            this.labelVol = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlRemark = new System.Windows.Forms.TextBox();
            this.btnFinish = new System.Windows.Forms.Button();
            this.lblsfis = new System.Windows.Forms.Label();
            this.txtBattery = new System.Windows.Forms.TextBox();
            this.lblBattery = new System.Windows.Forms.Label();
            this.lblMAC = new System.Windows.Forms.Label();
            this.txtStation = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboCom = new System.Windows.Forms.ComboBox();
            this.lblCom = new System.Windows.Forms.Label();
            this.lbCom = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.btnOpenSOP = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // pnlContent
            // 
            this.pnlContent.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTabList;
            this.pnlContent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlContent.AutoScroll = true;
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Location = new System.Drawing.Point(404, 134);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(4);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(728, 584);
            this.pnlContent.TabIndex = 144;
            // 
            // pnlLog
            // 
            this.pnlLog.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlLog.BackColor = System.Drawing.Color.White;
            this.pnlLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlLog.ForeColor = System.Drawing.Color.Black;
            this.pnlLog.Location = new System.Drawing.Point(1161, 134);
            this.pnlLog.Margin = new System.Windows.Forms.Padding(4);
            this.pnlLog.Name = "pnlLog";
            this.pnlLog.ReadOnly = true;
            this.pnlLog.Size = new System.Drawing.Size(357, 584);
            this.pnlLog.TabIndex = 142;
            this.pnlLog.Text = "";
            // 
            // lblRemark
            // 
            this.lblRemark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRemark.AutoSize = true;
            this.lblRemark.BackColor = System.Drawing.Color.Transparent;
            this.lblRemark.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemark.ForeColor = System.Drawing.Color.Chocolate;
            this.lblRemark.Location = new System.Drawing.Point(20, 470);
            this.lblRemark.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(55, 17);
            this.lblRemark.TabIndex = 93;
            this.lblRemark.Text = "Remark";
            // 
            // pnlFailure
            // 
            this.pnlFailure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlFailure.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlFailure.Location = new System.Drawing.Point(17, 379);
            this.pnlFailure.Margin = new System.Windows.Forms.Padding(5);
            this.pnlFailure.Multiline = true;
            this.pnlFailure.Name = "pnlFailure";
            this.pnlFailure.Size = new System.Drawing.Size(330, 86);
            this.pnlFailure.TabIndex = 92;
            // 
            // lblFailure
            // 
            this.lblFailure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFailure.AutoSize = true;
            this.lblFailure.BackColor = System.Drawing.Color.Transparent;
            this.lblFailure.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFailure.ForeColor = System.Drawing.Color.Chocolate;
            this.lblFailure.Location = new System.Drawing.Point(20, 360);
            this.lblFailure.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFailure.Name = "lblFailure";
            this.lblFailure.Size = new System.Drawing.Size(119, 17);
            this.lblFailure.TabIndex = 91;
            this.lblFailure.Text = "Failure Description";
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.SteelBlue;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(0, 72);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(1533, 35);
            this.lblStatus.TabIndex = 90;
            this.lblStatus.Text = "READY";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatus.TextChanged += new System.EventHandler(this.lblStatus_TextChanged);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.BackColor = System.Drawing.Color.LightSalmon;
            this.btnStart.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(36, 285);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 46);
            this.btnStart.TabIndex = 89;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtModel
            // 
            this.txtModel.BackColor = System.Drawing.Color.SteelBlue;
            this.txtModel.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtModel.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModel.ForeColor = System.Drawing.Color.Snow;
            this.txtModel.Location = new System.Drawing.Point(0, 0);
            this.txtModel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(1533, 35);
            this.txtModel.TabIndex = 84;
            this.txtModel.Text = "MODEL NAME";
            this.txtModel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFWV
            // 
            this.txtFWV.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFWV.Location = new System.Drawing.Point(274, 226);
            this.txtFWV.Margin = new System.Windows.Forms.Padding(5);
            this.txtFWV.Name = "txtFWV";
            this.txtFWV.Size = new System.Drawing.Size(73, 27);
            this.txtFWV.TabIndex = 27;
            this.txtFWV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFWV.Visible = false;
            this.txtFWV.Leave += new System.EventHandler(this.textBox2_Leave);
            // 
            // lblFWV
            // 
            this.lblFWV.AutoSize = true;
            this.lblFWV.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFWV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFWV.Location = new System.Drawing.Point(14, 231);
            this.lblFWV.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblFWV.Name = "lblFWV";
            this.lblFWV.Size = new System.Drawing.Size(116, 17);
            this.lblFWV.TabIndex = 26;
            this.lblFWV.Text = "Firmware Version:";
            this.lblFWV.Visible = false;
            // 
            // txtCartonWeigh
            // 
            this.txtCartonWeigh.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCartonWeigh.Location = new System.Drawing.Point(274, 133);
            this.txtCartonWeigh.Margin = new System.Windows.Forms.Padding(5);
            this.txtCartonWeigh.Name = "txtCartonWeigh";
            this.txtCartonWeigh.Size = new System.Drawing.Size(73, 27);
            this.txtCartonWeigh.TabIndex = 27;
            this.txtCartonWeigh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCartonWeigh.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // lblCartonWeigh
            // 
            this.lblCartonWeigh.AutoSize = true;
            this.lblCartonWeigh.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCartonWeigh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCartonWeigh.Location = new System.Drawing.Point(13, 139);
            this.lblCartonWeigh.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCartonWeigh.Name = "lblCartonWeigh";
            this.lblCartonWeigh.Size = new System.Drawing.Size(92, 17);
            this.lblCartonWeigh.TabIndex = 26;
            this.lblCartonWeigh.Text = "Carton Weigh:";
            // 
            // txtMac
            // 
            this.txtMac.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMac.Location = new System.Drawing.Point(75, 82);
            this.txtMac.Margin = new System.Windows.Forms.Padding(5);
            this.txtMac.Name = "txtMac";
            this.txtMac.Size = new System.Drawing.Size(242, 27);
            this.txtMac.TabIndex = 27;
            // 
            // labelVol
            // 
            this.labelVol.AutoSize = true;
            this.labelVol.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelVol.Location = new System.Drawing.Point(129, 181);
            this.labelVol.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelVol.Name = "labelVol";
            this.labelVol.Size = new System.Drawing.Size(73, 17);
            this.labelVol.TabIndex = 95;
            this.labelVol.Text = "(3V~4.5V)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(114, 139);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 17);
            this.label1.TabIndex = 95;
            this.label1.Text = "(2500Kg~3500Kg)";
            // 
            // pnlRemark
            // 
            this.pnlRemark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlRemark.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlRemark.Location = new System.Drawing.Point(17, 489);
            this.pnlRemark.Margin = new System.Windows.Forms.Padding(5);
            this.pnlRemark.Multiline = true;
            this.pnlRemark.Name = "pnlRemark";
            this.pnlRemark.Size = new System.Drawing.Size(330, 82);
            this.pnlRemark.TabIndex = 94;
            // 
            // btnFinish
            // 
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFinish.BackColor = System.Drawing.Color.Teal;
            this.btnFinish.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinish.ForeColor = System.Drawing.Color.White;
            this.btnFinish.Location = new System.Drawing.Point(203, 285);
            this.btnFinish.Margin = new System.Windows.Forms.Padding(4);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(120, 46);
            this.btnFinish.TabIndex = 89;
            this.btnFinish.Text = "Finish Test";
            this.btnFinish.UseVisualStyleBackColor = false;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // lblsfis
            // 
            this.lblsfis.BackColor = System.Drawing.Color.Teal;
            this.lblsfis.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblsfis.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsfis.ForeColor = System.Drawing.Color.White;
            this.lblsfis.Location = new System.Drawing.Point(1048, 35);
            this.lblsfis.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblsfis.Name = "lblsfis";
            this.lblsfis.Size = new System.Drawing.Size(485, 37);
            this.lblsfis.TabIndex = 86;
            this.lblsfis.Text = "SFIS OFF";
            this.lblsfis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBattery
            // 
            this.txtBattery.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBattery.Location = new System.Drawing.Point(274, 177);
            this.txtBattery.Margin = new System.Windows.Forms.Padding(5);
            this.txtBattery.Name = "txtBattery";
            this.txtBattery.Size = new System.Drawing.Size(73, 27);
            this.txtBattery.TabIndex = 27;
            this.txtBattery.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBattery.Leave += new System.EventHandler(this.textBox3_Leave);
            // 
            // lblBattery
            // 
            this.lblBattery.AutoSize = true;
            this.lblBattery.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBattery.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBattery.Location = new System.Drawing.Point(14, 182);
            this.lblBattery.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblBattery.Name = "lblBattery";
            this.lblBattery.Size = new System.Drawing.Size(103, 17);
            this.lblBattery.TabIndex = 26;
            this.lblBattery.Text = "Battery Voltage:";
            // 
            // lblMAC
            // 
            this.lblMAC.AutoSize = true;
            this.lblMAC.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMAC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMAC.Location = new System.Drawing.Point(28, 86);
            this.lblMAC.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMAC.Name = "lblMAC";
            this.lblMAC.Size = new System.Drawing.Size(45, 17);
            this.lblMAC.TabIndex = 26;
            this.lblMAC.Text = "MAC:";
            // 
            // txtStation
            // 
            this.txtStation.BackColor = System.Drawing.Color.DarkOrange;
            this.txtStation.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtStation.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStation.ForeColor = System.Drawing.Color.White;
            this.txtStation.Location = new System.Drawing.Point(0, 35);
            this.txtStation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtStation.Name = "txtStation";
            this.txtStation.Size = new System.Drawing.Size(485, 37);
            this.txtStation.TabIndex = 88;
            this.txtStation.Text = "OBA1";
            this.txtStation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.cboCom);
            this.groupBox1.Controls.Add(this.lblCom);
            this.groupBox1.Controls.Add(this.lbCom);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(138, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(209, 55);
            this.groupBox1.TabIndex = 85;
            this.groupBox1.TabStop = false;
            // 
            // cboCom
            // 
            this.cboCom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCom.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCom.FormattingEnabled = true;
            this.cboCom.Location = new System.Drawing.Point(56, 19);
            this.cboCom.Margin = new System.Windows.Forms.Padding(4);
            this.cboCom.Name = "cboCom";
            this.cboCom.Size = new System.Drawing.Size(80, 26);
            this.cboCom.TabIndex = 3;
            this.cboCom.SelectedIndexChanged += new System.EventHandler(this.cbbCom_SelectedIndexChanged);
            // 
            // lblCom
            // 
            this.lblCom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCom.AutoSize = true;
            this.lblCom.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCom.Location = new System.Drawing.Point(8, 21);
            this.lblCom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCom.Name = "lblCom";
            this.lblCom.Size = new System.Drawing.Size(45, 21);
            this.lblCom.TabIndex = 4;
            this.lblCom.Text = "COM";
            // 
            // lbCom
            // 
            this.lbCom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbCom.BackColor = System.Drawing.Color.Red;
            this.lbCom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCom.ForeColor = System.Drawing.Color.White;
            this.lbCom.Location = new System.Drawing.Point(145, 19);
            this.lbCom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCom.Name = "lbCom";
            this.lbCom.Size = new System.Drawing.Size(52, 26);
            this.lbCom.TabIndex = 5;
            this.lbCom.Text = "OFF";
            this.lbCom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTime
            // 
            this.txtTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txtTime.AutoSize = true;
            this.txtTime.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTime.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime.ForeColor = System.Drawing.Color.Black;
            this.txtTime.Location = new System.Drawing.Point(735, 6);
            this.txtTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(69, 24);
            this.txtTime.TabIndex = 87;
            this.txtTime.Text = "00:00";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblsfis);
            this.pnlHeader.Controls.Add(this.txtStation);
            this.pnlHeader.Controls.Add(this.panel1);
            this.pnlHeader.Controls.Add(this.lblStatus);
            this.pnlHeader.Controls.Add(this.txtModel);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1533, 107);
            this.pnlHeader.TabIndex = 145;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtTime);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1533, 37);
            this.panel1.TabIndex = 91;
            // 
            // pnlControl
            // 
            this.pnlControl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlControl.BackColor = System.Drawing.SystemColors.Window;
            this.pnlControl.Controls.Add(this.btnOpenSOP);
            this.pnlControl.Controls.Add(this.groupBox1);
            this.pnlControl.Controls.Add(this.lblFWV);
            this.pnlControl.Controls.Add(this.txtBattery);
            this.pnlControl.Controls.Add(this.labelVol);
            this.pnlControl.Controls.Add(this.pnlRemark);
            this.pnlControl.Controls.Add(this.txtFWV);
            this.pnlControl.Controls.Add(this.lblRemark);
            this.pnlControl.Controls.Add(this.lblBattery);
            this.pnlControl.Controls.Add(this.pnlFailure);
            this.pnlControl.Controls.Add(this.lblFailure);
            this.pnlControl.Controls.Add(this.label1);
            this.pnlControl.Controls.Add(this.txtCartonWeigh);
            this.pnlControl.Controls.Add(this.btnStart);
            this.pnlControl.Controls.Add(this.btnFinish);
            this.pnlControl.Controls.Add(this.lblCartonWeigh);
            this.pnlControl.Controls.Add(this.txtMac);
            this.pnlControl.Controls.Add(this.lblMAC);
            this.pnlControl.Location = new System.Drawing.Point(12, 134);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(364, 584);
            this.pnlControl.TabIndex = 146;
            // 
            // btnOpenSOP
            // 
            this.btnOpenSOP.BackColor = System.Drawing.Color.SteelBlue;
            this.btnOpenSOP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenSOP.ForeColor = System.Drawing.Color.White;
            this.btnOpenSOP.Location = new System.Drawing.Point(16, 13);
            this.btnOpenSOP.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenSOP.Name = "btnOpenSOP";
            this.btnOpenSOP.Size = new System.Drawing.Size(100, 46);
            this.btnOpenSOP.TabIndex = 96;
            this.btnOpenSOP.Text = "SOP";
            this.btnOpenSOP.UseVisualStyleBackColor = false;
            this.btnOpenSOP.Click += new System.EventHandler(this.btnOpenSOP_Click);
            // 
            // TestOBA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1533, 743);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.pnlLog);
            this.Controls.Add(this.pnlHeader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TestOBA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TestOBA";
            this.Load += new System.EventHandler(this.FormAutoCreate_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.FlowLayoutPanel pnlContent;
        private System.Windows.Forms.RichTextBox pnlLog;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.TextBox pnlFailure;
        private System.Windows.Forms.Label lblFailure;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label txtModel;
        private System.Windows.Forms.TextBox txtFWV;
        private System.Windows.Forms.Label lblFWV;
        private System.Windows.Forms.TextBox txtCartonWeigh;
        private System.Windows.Forms.Label lblCartonWeigh;
        private System.Windows.Forms.TextBox txtMac;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pnlRemark;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Label lblsfis;
        private System.Windows.Forms.Label lblMAC;
        private System.Windows.Forms.Label txtStation;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbCom;
        private System.Windows.Forms.Label lblCom;
        private System.Windows.Forms.ComboBox cboCom;
        private System.Windows.Forms.Label txtTime;
        private System.Windows.Forms.Label labelVol;
        private System.Windows.Forms.TextBox txtBattery;
        private System.Windows.Forms.Label lblBattery;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOpenSOP;
    }
}