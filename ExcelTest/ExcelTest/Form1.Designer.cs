
namespace ExcelTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ckbDebugInfo = new System.Windows.Forms.CheckBox();
            this.tbConfigFilePath = new System.Windows.Forms.TextBox();
            this.btSelectConfigFile = new System.Windows.Forms.Button();
            this.ckbUseConfigFile = new System.Windows.Forms.CheckBox();
            this.btTest = new System.Windows.Forms.Button();
            this.rtbTips = new System.Windows.Forms.RichTextBox();
            this.ckbUseDefault = new System.Windows.Forms.CheckBox();
            this.btStart = new System.Windows.Forms.Button();
            this.tbSheetName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbModuleName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbBitPosCol = new System.Windows.Forms.TextBox();
            this.tbRWCol = new System.Windows.Forms.TextBox();
            this.tbLogRegCol = new System.Windows.Forms.TextBox();
            this.tbPhyRegCol = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbOutputPath = new System.Windows.Forms.TextBox();
            this.tbInputPath = new System.Windows.Forms.TextBox();
            this.btSelectOutput = new System.Windows.Forms.Button();
            this.btSelectInput = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbStartRow = new System.Windows.Forms.TextBox();
            this.tbEndRow = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ckbDebugInfo
            // 
            this.ckbDebugInfo.AutoSize = true;
            this.ckbDebugInfo.Location = new System.Drawing.Point(12, 248);
            this.ckbDebugInfo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ckbDebugInfo.Name = "ckbDebugInfo";
            this.ckbDebugInfo.Size = new System.Drawing.Size(114, 21);
            this.ckbDebugInfo.TabIndex = 47;
            this.ckbDebugInfo.Text = "显示Debug信息";
            this.ckbDebugInfo.UseVisualStyleBackColor = true;
            // 
            // tbConfigFilePath
            // 
            this.tbConfigFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbConfigFilePath.Enabled = false;
            this.tbConfigFilePath.Location = new System.Drawing.Point(138, 73);
            this.tbConfigFilePath.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbConfigFilePath.Name = "tbConfigFilePath";
            this.tbConfigFilePath.Size = new System.Drawing.Size(532, 23);
            this.tbConfigFilePath.TabIndex = 46;
            // 
            // btSelectConfigFile
            // 
            this.btSelectConfigFile.Enabled = false;
            this.btSelectConfigFile.Location = new System.Drawing.Point(12, 72);
            this.btSelectConfigFile.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btSelectConfigFile.Name = "btSelectConfigFile";
            this.btSelectConfigFile.Size = new System.Drawing.Size(109, 25);
            this.btSelectConfigFile.TabIndex = 45;
            this.btSelectConfigFile.Text = "选择配置文件";
            this.btSelectConfigFile.UseVisualStyleBackColor = true;
            this.btSelectConfigFile.Click += new System.EventHandler(this.btSelectConfigFile_Click);
            // 
            // ckbUseConfigFile
            // 
            this.ckbUseConfigFile.AutoSize = true;
            this.ckbUseConfigFile.Location = new System.Drawing.Point(12, 223);
            this.ckbUseConfigFile.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ckbUseConfigFile.Name = "ckbUseConfigFile";
            this.ckbUseConfigFile.Size = new System.Drawing.Size(99, 21);
            this.ckbUseConfigFile.TabIndex = 44;
            this.ckbUseConfigFile.Text = "使用配置文件";
            this.ckbUseConfigFile.UseVisualStyleBackColor = true;
            this.ckbUseConfigFile.CheckedChanged += new System.EventHandler(this.ckbUseConfigFile_CheckedChanged);
            // 
            // btTest
            // 
            this.btTest.Location = new System.Drawing.Point(12, 356);
            this.btTest.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btTest.Name = "btTest";
            this.btTest.Size = new System.Drawing.Size(78, 37);
            this.btTest.TabIndex = 43;
            this.btTest.Text = "测试按钮";
            this.btTest.UseVisualStyleBackColor = true;
            this.btTest.Click += new System.EventHandler(this.btTest_Click);
            // 
            // rtbTips
            // 
            this.rtbTips.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbTips.Location = new System.Drawing.Point(138, 198);
            this.rtbTips.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rtbTips.Name = "rtbTips";
            this.rtbTips.ReadOnly = true;
            this.rtbTips.Size = new System.Drawing.Size(532, 193);
            this.rtbTips.TabIndex = 42;
            this.rtbTips.Text = "";
            this.rtbTips.TextChanged += new System.EventHandler(this.rtbTips_TextChanged);
            // 
            // ckbUseDefault
            // 
            this.ckbUseDefault.AutoSize = true;
            this.ckbUseDefault.Location = new System.Drawing.Point(12, 198);
            this.ckbUseDefault.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ckbUseDefault.Name = "ckbUseDefault";
            this.ckbUseDefault.Size = new System.Drawing.Size(111, 21);
            this.ckbUseDefault.TabIndex = 41;
            this.ckbUseDefault.Text = "使用默认文件名";
            this.ckbUseDefault.UseVisualStyleBackColor = true;
            this.ckbUseDefault.CheckedChanged += new System.EventHandler(this.ckbUseDefault_CheckedChanged);
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(12, 288);
            this.btStart.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(78, 64);
            this.btStart.TabIndex = 40;
            this.btStart.Text = "开始";
            this.btStart.UseVisualStyleBackColor = true;
            // 
            // tbSheetName
            // 
            this.tbSheetName.Location = new System.Drawing.Point(500, 131);
            this.tbSheetName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbSheetName.Name = "tbSheetName";
            this.tbSheetName.Size = new System.Drawing.Size(98, 23);
            this.tbSheetName.TabIndex = 39;
            this.tbSheetName.Text = "VIN1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(390, 104);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 17);
            this.label6.TabIndex = 38;
            this.label6.Text = "Module Name";
            // 
            // tbModuleName
            // 
            this.tbModuleName.Location = new System.Drawing.Point(500, 101);
            this.tbModuleName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbModuleName.Name = "tbModuleName";
            this.tbModuleName.Size = new System.Drawing.Size(98, 23);
            this.tbModuleName.TabIndex = 37;
            this.tbModuleName.Text = "VIN1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(390, 134);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 36;
            this.label5.Text = "Sheet Name";
            // 
            // tbBitPosCol
            // 
            this.tbBitPosCol.Location = new System.Drawing.Point(155, 161);
            this.tbBitPosCol.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbBitPosCol.Name = "tbBitPosCol";
            this.tbBitPosCol.Size = new System.Drawing.Size(50, 23);
            this.tbBitPosCol.TabIndex = 35;
            this.tbBitPosCol.Text = "H";
            // 
            // tbRWCol
            // 
            this.tbRWCol.Location = new System.Drawing.Point(310, 101);
            this.tbRWCol.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbRWCol.Name = "tbRWCol";
            this.tbRWCol.Size = new System.Drawing.Size(50, 23);
            this.tbRWCol.TabIndex = 34;
            this.tbRWCol.Text = "E";
            // 
            // tbLogRegCol
            // 
            this.tbLogRegCol.Location = new System.Drawing.Point(155, 131);
            this.tbLogRegCol.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbLogRegCol.Name = "tbLogRegCol";
            this.tbLogRegCol.Size = new System.Drawing.Size(50, 23);
            this.tbLogRegCol.TabIndex = 33;
            this.tbLogRegCol.Text = "D";
            // 
            // tbPhyRegCol
            // 
            this.tbPhyRegCol.Location = new System.Drawing.Point(155, 101);
            this.tbPhyRegCol.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbPhyRegCol.Name = "tbPhyRegCol";
            this.tbPhyRegCol.Size = new System.Drawing.Size(50, 23);
            this.tbPhyRegCol.TabIndex = 32;
            this.tbPhyRegCol.Text = "B";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 164);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 31;
            this.label4.Text = "Bit Position Col";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 104);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 30;
            this.label3.Text = "R/W Col";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 134);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 17);
            this.label2.TabIndex = 29;
            this.label2.Text = "Logical Register Col";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 104);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 17);
            this.label1.TabIndex = 28;
            this.label1.Text = "Physical Register Col";
            // 
            // tbOutputPath
            // 
            this.tbOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOutputPath.Location = new System.Drawing.Point(138, 43);
            this.tbOutputPath.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbOutputPath.Name = "tbOutputPath";
            this.tbOutputPath.Size = new System.Drawing.Size(532, 23);
            this.tbOutputPath.TabIndex = 27;
            // 
            // tbInputPath
            // 
            this.tbInputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInputPath.Location = new System.Drawing.Point(138, 13);
            this.tbInputPath.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbInputPath.Name = "tbInputPath";
            this.tbInputPath.Size = new System.Drawing.Size(532, 23);
            this.tbInputPath.TabIndex = 26;
            // 
            // btSelectOutput
            // 
            this.btSelectOutput.Location = new System.Drawing.Point(12, 42);
            this.btSelectOutput.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btSelectOutput.Name = "btSelectOutput";
            this.btSelectOutput.Size = new System.Drawing.Size(109, 25);
            this.btSelectOutput.TabIndex = 25;
            this.btSelectOutput.Text = "选择输出文件";
            this.btSelectOutput.UseVisualStyleBackColor = true;
            this.btSelectOutput.Click += new System.EventHandler(this.btSelectOutput_Click);
            // 
            // btSelectInput
            // 
            this.btSelectInput.Location = new System.Drawing.Point(12, 12);
            this.btSelectInput.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btSelectInput.Name = "btSelectInput";
            this.btSelectInput.Size = new System.Drawing.Size(109, 25);
            this.btSelectInput.TabIndex = 24;
            this.btSelectInput.Text = "选择输入文件";
            this.btSelectInput.UseVisualStyleBackColor = true;
            this.btSelectInput.Click += new System.EventHandler(this.btSelectInput_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(230, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 17);
            this.label7.TabIndex = 48;
            this.label7.Text = "Start Row";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(230, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 17);
            this.label8.TabIndex = 49;
            this.label8.Text = "End Row";
            // 
            // tbStartRow
            // 
            this.tbStartRow.Location = new System.Drawing.Point(310, 131);
            this.tbStartRow.Name = "tbStartRow";
            this.tbStartRow.Size = new System.Drawing.Size(50, 23);
            this.tbStartRow.TabIndex = 50;
            this.tbStartRow.Text = "3";
            // 
            // tbEndRow
            // 
            this.tbEndRow.Location = new System.Drawing.Point(310, 161);
            this.tbEndRow.Name = "tbEndRow";
            this.tbEndRow.Size = new System.Drawing.Size(50, 23);
            this.tbEndRow.TabIndex = 51;
            this.tbEndRow.Text = "100";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 401);
            this.Controls.Add(this.tbEndRow);
            this.Controls.Add(this.tbStartRow);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ckbDebugInfo);
            this.Controls.Add(this.tbConfigFilePath);
            this.Controls.Add(this.btSelectConfigFile);
            this.Controls.Add(this.ckbUseConfigFile);
            this.Controls.Add(this.btTest);
            this.Controls.Add(this.rtbTips);
            this.Controls.Add(this.ckbUseDefault);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.tbSheetName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbModuleName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbBitPosCol);
            this.Controls.Add(this.tbRWCol);
            this.Controls.Add(this.tbLogRegCol);
            this.Controls.Add(this.tbPhyRegCol);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbOutputPath);
            this.Controls.Add(this.tbInputPath);
            this.Controls.Add(this.btSelectOutput);
            this.Controls.Add(this.btSelectInput);
            this.MinimumSize = new System.Drawing.Size(700, 440);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckbDebugInfo;
        private System.Windows.Forms.TextBox tbConfigFilePath;
        private System.Windows.Forms.Button btSelectConfigFile;
        private System.Windows.Forms.CheckBox ckbUseConfigFile;
        private System.Windows.Forms.Button btTest;
        private System.Windows.Forms.RichTextBox rtbTips;
        private System.Windows.Forms.CheckBox ckbUseDefault;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.TextBox tbSheetName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbModuleName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbBitPosCol;
        private System.Windows.Forms.TextBox tbRWCol;
        private System.Windows.Forms.TextBox tbLogRegCol;
        private System.Windows.Forms.TextBox tbPhyRegCol;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbOutputPath;
        private System.Windows.Forms.TextBox tbInputPath;
        private System.Windows.Forms.Button btSelectOutput;
        private System.Windows.Forms.Button btSelectInput;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbStartRow;
        private System.Windows.Forms.TextBox tbEndRow;
    }
}

