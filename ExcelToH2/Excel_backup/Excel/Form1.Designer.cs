namespace Excel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Btn_SelectInput = new System.Windows.Forms.Button();
            this.Btn_SelectOutput = new System.Windows.Forms.Button();
            this.TxtBx_InputPath = new System.Windows.Forms.TextBox();
            this.TxtBx_OutputPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtBx_PhyRegCol = new System.Windows.Forms.TextBox();
            this.TxtBx_LogRegCol = new System.Windows.Forms.TextBox();
            this.TxtBx_RWCol = new System.Windows.Forms.TextBox();
            this.TxtBx_BitPosCol = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtBx_ModuleName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtBx_SheetName = new System.Windows.Forms.TextBox();
            this.Btn_Start = new System.Windows.Forms.Button();
            this.CkBx_UseDefault = new System.Windows.Forms.CheckBox();
            this.RTBx_Tips = new System.Windows.Forms.RichTextBox();
            this.Btn_Test = new System.Windows.Forms.Button();
            this.CkBx_UseNameFile = new System.Windows.Forms.CheckBox();
            this.Btn_SelectNameFile = new System.Windows.Forms.Button();
            this.TxtBx_NameFilePath = new System.Windows.Forms.TextBox();
            this.CkBx_DebugInfo = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Btn_SelectInput
            // 
            this.Btn_SelectInput.Location = new System.Drawing.Point(12, 12);
            this.Btn_SelectInput.Name = "Btn_SelectInput";
            this.Btn_SelectInput.Size = new System.Drawing.Size(140, 29);
            this.Btn_SelectInput.TabIndex = 0;
            this.Btn_SelectInput.Text = "选择输入文件";
            this.Btn_SelectInput.UseVisualStyleBackColor = true;
            this.Btn_SelectInput.Click += new System.EventHandler(this.Btn_SelectInput_Click);
            // 
            // Btn_SelectOutput
            // 
            this.Btn_SelectOutput.Location = new System.Drawing.Point(12, 47);
            this.Btn_SelectOutput.Name = "Btn_SelectOutput";
            this.Btn_SelectOutput.Size = new System.Drawing.Size(140, 29);
            this.Btn_SelectOutput.TabIndex = 1;
            this.Btn_SelectOutput.Text = "选择输出文件";
            this.Btn_SelectOutput.UseVisualStyleBackColor = true;
            this.Btn_SelectOutput.Click += new System.EventHandler(this.Btn_SelectOutput_Click);
            // 
            // TxtBx_InputPath
            // 
            this.TxtBx_InputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBx_InputPath.Location = new System.Drawing.Point(173, 13);
            this.TxtBx_InputPath.Name = "TxtBx_InputPath";
            this.TxtBx_InputPath.Size = new System.Drawing.Size(615, 27);
            this.TxtBx_InputPath.TabIndex = 2;
            // 
            // TxtBx_OutputPath
            // 
            this.TxtBx_OutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBx_OutputPath.Location = new System.Drawing.Point(173, 48);
            this.TxtBx_OutputPath.Name = "TxtBx_OutputPath";
            this.TxtBx_OutputPath.Size = new System.Drawing.Size(615, 27);
            this.TxtBx_OutputPath.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Physical Register Col";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Logical Register Col";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(400, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "R/W Col";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(400, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Bit Position Col";
            // 
            // TxtBx_PhyRegCol
            // 
            this.TxtBx_PhyRegCol.Location = new System.Drawing.Point(220, 117);
            this.TxtBx_PhyRegCol.Name = "TxtBx_PhyRegCol";
            this.TxtBx_PhyRegCol.Size = new System.Drawing.Size(125, 27);
            this.TxtBx_PhyRegCol.TabIndex = 8;
            this.TxtBx_PhyRegCol.Text = "B";
            // 
            // TxtBx_LogRegCol
            // 
            this.TxtBx_LogRegCol.Location = new System.Drawing.Point(220, 152);
            this.TxtBx_LogRegCol.Name = "TxtBx_LogRegCol";
            this.TxtBx_LogRegCol.Size = new System.Drawing.Size(125, 27);
            this.TxtBx_LogRegCol.TabIndex = 9;
            this.TxtBx_LogRegCol.Text = "D";
            // 
            // TxtBx_RWCol
            // 
            this.TxtBx_RWCol.Location = new System.Drawing.Point(560, 117);
            this.TxtBx_RWCol.Name = "TxtBx_RWCol";
            this.TxtBx_RWCol.Size = new System.Drawing.Size(125, 27);
            this.TxtBx_RWCol.TabIndex = 10;
            this.TxtBx_RWCol.Text = "E";
            // 
            // TxtBx_BitPosCol
            // 
            this.TxtBx_BitPosCol.Location = new System.Drawing.Point(560, 152);
            this.TxtBx_BitPosCol.Name = "TxtBx_BitPosCol";
            this.TxtBx_BitPosCol.Size = new System.Drawing.Size(125, 27);
            this.TxtBx_BitPosCol.TabIndex = 11;
            this.TxtBx_BitPosCol.Text = "H";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(400, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Sheet Name";
            // 
            // TxtBx_ModuleName
            // 
            this.TxtBx_ModuleName.Location = new System.Drawing.Point(220, 187);
            this.TxtBx_ModuleName.Name = "TxtBx_ModuleName";
            this.TxtBx_ModuleName.Size = new System.Drawing.Size(125, 27);
            this.TxtBx_ModuleName.TabIndex = 13;
            this.TxtBx_ModuleName.Text = "VIN1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Module Name";
            // 
            // TxtBx_SheetName
            // 
            this.TxtBx_SheetName.Location = new System.Drawing.Point(560, 187);
            this.TxtBx_SheetName.Name = "TxtBx_SheetName";
            this.TxtBx_SheetName.Size = new System.Drawing.Size(125, 27);
            this.TxtBx_SheetName.TabIndex = 15;
            this.TxtBx_SheetName.Text = "VIN1";
            // 
            // Btn_Start
            // 
            this.Btn_Start.Location = new System.Drawing.Point(12, 336);
            this.Btn_Start.Name = "Btn_Start";
            this.Btn_Start.Size = new System.Drawing.Size(100, 75);
            this.Btn_Start.TabIndex = 16;
            this.Btn_Start.Text = "开始";
            this.Btn_Start.UseVisualStyleBackColor = true;
            this.Btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // CkBx_UseDefault
            // 
            this.CkBx_UseDefault.AutoSize = true;
            this.CkBx_UseDefault.Checked = true;
            this.CkBx_UseDefault.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CkBx_UseDefault.Location = new System.Drawing.Point(12, 230);
            this.CkBx_UseDefault.Name = "CkBx_UseDefault";
            this.CkBx_UseDefault.Size = new System.Drawing.Size(136, 24);
            this.CkBx_UseDefault.TabIndex = 17;
            this.CkBx_UseDefault.Text = "使用默认文件名";
            this.CkBx_UseDefault.UseVisualStyleBackColor = true;
            // 
            // RTBx_Tips
            // 
            this.RTBx_Tips.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTBx_Tips.Location = new System.Drawing.Point(173, 230);
            this.RTBx_Tips.Name = "RTBx_Tips";
            this.RTBx_Tips.Size = new System.Drawing.Size(615, 231);
            this.RTBx_Tips.TabIndex = 18;
            this.RTBx_Tips.Text = "";
            this.RTBx_Tips.TextChanged += new System.EventHandler(this.RTBx_Tips_TextChanged);
            // 
            // Btn_Test
            // 
            this.Btn_Test.Enabled = false;
            this.Btn_Test.Location = new System.Drawing.Point(12, 417);
            this.Btn_Test.Name = "Btn_Test";
            this.Btn_Test.Size = new System.Drawing.Size(100, 44);
            this.Btn_Test.TabIndex = 19;
            this.Btn_Test.Text = "测试按钮";
            this.Btn_Test.UseVisualStyleBackColor = true;
            this.Btn_Test.Click += new System.EventHandler(this.Btn_Test_Click);
            // 
            // CkBx_UseNameFile
            // 
            this.CkBx_UseNameFile.AutoSize = true;
            this.CkBx_UseNameFile.Location = new System.Drawing.Point(12, 260);
            this.CkBx_UseNameFile.Name = "CkBx_UseNameFile";
            this.CkBx_UseNameFile.Size = new System.Drawing.Size(116, 24);
            this.CkBx_UseNameFile.TabIndex = 20;
            this.CkBx_UseNameFile.Text = "使用name表";
            this.CkBx_UseNameFile.UseVisualStyleBackColor = true;
            this.CkBx_UseNameFile.CheckedChanged += new System.EventHandler(this.CkBx_UseNameFile_CheckedChanged);
            // 
            // Btn_SelectNameFile
            // 
            this.Btn_SelectNameFile.Location = new System.Drawing.Point(12, 82);
            this.Btn_SelectNameFile.Name = "Btn_SelectNameFile";
            this.Btn_SelectNameFile.Size = new System.Drawing.Size(140, 29);
            this.Btn_SelectNameFile.TabIndex = 21;
            this.Btn_SelectNameFile.Text = "选择name文件";
            this.Btn_SelectNameFile.UseVisualStyleBackColor = true;
            this.Btn_SelectNameFile.Click += new System.EventHandler(this.Btn_SelectNameFile_Click);
            // 
            // TxtBx_NameFilePath
            // 
            this.TxtBx_NameFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBx_NameFilePath.Location = new System.Drawing.Point(173, 83);
            this.TxtBx_NameFilePath.Name = "TxtBx_NameFilePath";
            this.TxtBx_NameFilePath.Size = new System.Drawing.Size(615, 27);
            this.TxtBx_NameFilePath.TabIndex = 22;
            // 
            // CkBx_DebugInfo
            // 
            this.CkBx_DebugInfo.AutoSize = true;
            this.CkBx_DebugInfo.Location = new System.Drawing.Point(12, 290);
            this.CkBx_DebugInfo.Name = "CkBx_DebugInfo";
            this.CkBx_DebugInfo.Size = new System.Drawing.Size(140, 24);
            this.CkBx_DebugInfo.TabIndex = 23;
            this.CkBx_DebugInfo.Text = "显示Debug信息";
            this.CkBx_DebugInfo.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 473);
            this.Controls.Add(this.CkBx_DebugInfo);
            this.Controls.Add(this.TxtBx_NameFilePath);
            this.Controls.Add(this.Btn_SelectNameFile);
            this.Controls.Add(this.CkBx_UseNameFile);
            this.Controls.Add(this.Btn_Test);
            this.Controls.Add(this.RTBx_Tips);
            this.Controls.Add(this.CkBx_UseDefault);
            this.Controls.Add(this.Btn_Start);
            this.Controls.Add(this.TxtBx_SheetName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtBx_ModuleName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtBx_BitPosCol);
            this.Controls.Add(this.TxtBx_RWCol);
            this.Controls.Add(this.TxtBx_LogRegCol);
            this.Controls.Add(this.TxtBx_PhyRegCol);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtBx_OutputPath);
            this.Controls.Add(this.TxtBx_InputPath);
            this.Controls.Add(this.Btn_SelectOutput);
            this.Controls.Add(this.Btn_SelectInput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(818, 520);
            this.Name = "Form1";
            this.Text = "ExcelToH";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_SelectInput;
        private System.Windows.Forms.Button Btn_SelectOutput;
        private System.Windows.Forms.TextBox TxtBx_InputPath;
        private System.Windows.Forms.TextBox TxtBx_OutputPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtBx_PhyRegCol;
        private System.Windows.Forms.TextBox TxtBx_LogRegCol;
        private System.Windows.Forms.TextBox TxtBx_RWCol;
        private System.Windows.Forms.TextBox TxtBx_BitPosCol;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtBx_ModuleName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtBx_SheetName;
        private System.Windows.Forms.Button Btn_Start;
        private System.Windows.Forms.CheckBox CkBx_UseDefault;
        private System.Windows.Forms.RichTextBox RTBx_Tips;
        private System.Windows.Forms.Button Btn_Test;
        private System.Windows.Forms.CheckBox CkBx_UseNameFile;
        private System.Windows.Forms.Button Btn_SelectNameFile;
        private System.Windows.Forms.TextBox TxtBx_NameFilePath;
        private System.Windows.Forms.CheckBox CkBx_DebugInfo;
    }
}

