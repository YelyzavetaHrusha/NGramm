using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace NGramStatistics
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
            button1 = new Button();
            dgv_Texts = new DataGridView();
            cPP = new DataGridViewTextBoxColumn();
            cNameText = new DataGridViewTextBoxColumn();
            cCharsCount = new DataGridViewTextBoxColumn();
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            groupBox1 = new GroupBox();
            cbIgnoreCase = new ComboBox();
            cbSpaceDisable = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            ngram_len = new NumericUpDown();
            label2 = new Label();
            cbTextEncoding = new ComboBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            rtManualInput = new RichTextBox();
            cbLanguage = new ComboBox();
            button2 = new Button();
            btnRefreshDiagram = new Button();
            btnBuildNGram = new Button();
            groupBox3 = new GroupBox();
            cbStatistic = new ComboBox();
            dgv_CharStat = new DataGridView();
            cLetter = new DataGridViewTextBoxColumn();
            cFreq = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgv_Texts).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ngram_len).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_CharStat).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button1.Location = new Point(10, 11);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(123, 127);
            button1.TabIndex = 0;
            button1.Text = "Вибір папки з текстами";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dgv_Texts
            // 
            dgv_Texts.AllowUserToAddRows = false;
            dgv_Texts.AllowUserToDeleteRows = false;
            dgv_Texts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgv_Texts.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgv_Texts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Texts.Columns.AddRange(new DataGridViewColumn[] { cPP, cNameText, cCharsCount });
            dgv_Texts.Location = new Point(10, 142);
            dgv_Texts.Margin = new Padding(3, 2, 3, 2);
            dgv_Texts.MultiSelect = false;
            dgv_Texts.Name = "dgv_Texts";
            dgv_Texts.ReadOnly = true;
            dgv_Texts.RowHeadersVisible = false;
            dgv_Texts.RowHeadersWidth = 51;
            dgv_Texts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Texts.Size = new Size(252, 402);
            dgv_Texts.TabIndex = 3;
            // 
            // cPP
            // 
            cPP.HeaderText = "№ п/п";
            cPP.MinimumWidth = 6;
            cPP.Name = "cPP";
            cPP.ReadOnly = true;
            cPP.Width = 62;
            // 
            // cNameText
            // 
            cNameText.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            cNameText.HeaderText = "Назва текстового файлу";
            cNameText.MinimumWidth = 6;
            cNameText.Name = "cNameText";
            cNameText.ReadOnly = true;
            // 
            // cCharsCount
            // 
            cCharsCount.HeaderText = "Розмір  файлу";
            cCharsCount.MinimumWidth = 10;
            cCharsCount.Name = "cCharsCount";
            cCharsCount.ReadOnly = true;
            cCharsCount.Width = 70;
            // 
            // formsPlot1
            // 
            formsPlot1.DisplayScale = 1.25F;
            formsPlot1.Location = new Point(268, 142);
            formsPlot1.Margin = new Padding(3, 2, 3, 2);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(518, 402);
            formsPlot1.TabIndex = 4;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbIgnoreCase);
            groupBox1.Controls.Add(cbSpaceDisable);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(ngram_len);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cbTextEncoding);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            groupBox1.Location = new Point(139, 10);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(261, 129);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Параметри";
            // 
            // cbIgnoreCase
            // 
            cbIgnoreCase.DropDownStyle = ComboBoxStyle.DropDownList;
            cbIgnoreCase.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold);
            cbIgnoreCase.FormattingEnabled = true;
            cbIgnoreCase.Items.AddRange(new object[] { "Так", "Ні" });
            cbIgnoreCase.Location = new Point(147, 103);
            cbIgnoreCase.Margin = new Padding(4, 3, 4, 3);
            cbIgnoreCase.Name = "cbIgnoreCase";
            cbIgnoreCase.Size = new Size(106, 21);
            cbIgnoreCase.TabIndex = 19;
            cbIgnoreCase.SelectedIndexChanged += cbIgnoreCase_SelectedIndexChanged;
            // 
            // cbSpaceDisable
            // 
            cbSpaceDisable.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSpaceDisable.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold);
            cbSpaceDisable.FormattingEnabled = true;
            cbSpaceDisable.Items.AddRange(new object[] { "Так", "Ні" });
            cbSpaceDisable.Location = new Point(147, 79);
            cbSpaceDisable.Margin = new Padding(4, 3, 4, 3);
            cbSpaceDisable.Name = "cbSpaceDisable";
            cbSpaceDisable.Size = new Size(106, 21);
            cbSpaceDisable.TabIndex = 13;
            cbSpaceDisable.SelectedIndexChanged += CbSpaceDisable_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(5, 80);
            label4.Name = "label4";
            label4.Size = new Size(118, 15);
            label4.TabIndex = 18;
            label4.Text = "Ігнорувати пробіли";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(5, 104);
            label3.Name = "label3";
            label3.Size = new Size(112, 15);
            label3.TabIndex = 17;
            label3.Text = "Ігнорувати регістр";
            // 
            // ngram_len
            // 
            ngram_len.BackColor = SystemColors.ControlLight;
            ngram_len.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ngram_len.Location = new Point(147, 54);
            ngram_len.Margin = new Padding(3, 2, 3, 2);
            ngram_len.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            ngram_len.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ngram_len.Name = "ngram_len";
            ngram_len.ReadOnly = true;
            ngram_len.Size = new Size(106, 23);
            ngram_len.TabIndex = 1;
            ngram_len.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(5, 56);
            label2.Name = "label2";
            label2.Size = new Size(109, 15);
            label2.TabIndex = 16;
            label2.Text = "Довжина N-Gram";
            // 
            // cbTextEncoding
            // 
            cbTextEncoding.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTextEncoding.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold);
            cbTextEncoding.FormattingEnabled = true;
            cbTextEncoding.Items.AddRange(new object[] { "UTF-8", "Win-1251" });
            cbTextEncoding.Location = new Point(147, 30);
            cbTextEncoding.Margin = new Padding(4, 3, 4, 3);
            cbTextEncoding.Name = "cbTextEncoding";
            cbTextEncoding.Size = new Size(106, 21);
            cbTextEncoding.TabIndex = 15;
            cbTextEncoding.SelectedIndexChanged += CbTextEncoding_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(5, 31);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 0;
            label1.Text = "Кодування";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rtManualInput);
            groupBox2.Controls.Add(cbLanguage);
            groupBox2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            groupBox2.Location = new Point(406, 9);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(168, 131);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Символи";
            // 
            // rtManualInput
            // 
            rtManualInput.Font = new Font("Segoe UI", 9F);
            rtManualInput.Location = new Point(6, 53);
            rtManualInput.Margin = new Padding(3, 2, 3, 2);
            rtManualInput.Name = "rtManualInput";
            rtManualInput.Size = new Size(147, 72);
            rtManualInput.TabIndex = 2;
            rtManualInput.Text = "";
            rtManualInput.Visible = false;
            rtManualInput.TextChanged += rtManualInput_TextChanged;
            // 
            // cbLanguage
            // 
            cbLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLanguage.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold);
            cbLanguage.FormattingEnabled = true;
            cbLanguage.Items.AddRange(new object[] { "Латиниця", "Кирилиця", "Цифри", "Ручний ввід" });
            cbLanguage.Location = new Point(6, 28);
            cbLanguage.Margin = new Padding(4, 3, 4, 3);
            cbLanguage.Name = "cbLanguage";
            cbLanguage.Size = new Size(147, 21);
            cbLanguage.TabIndex = 1;
            cbLanguage.SelectedIndexChanged += cbLanguage_SelectedIndexChanged;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button2.Location = new Point(793, 8);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(158, 128);
            button2.TabIndex = 8;
            button2.Text = "Порахувати";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // btnRefreshDiagram
            // 
            btnRefreshDiagram.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefreshDiagram.Location = new Point(5, 86);
            btnRefreshDiagram.Margin = new Padding(3, 2, 3, 2);
            btnRefreshDiagram.Name = "btnRefreshDiagram";
            btnRefreshDiagram.Size = new Size(69, 39);
            btnRefreshDiagram.TabIndex = 9;
            btnRefreshDiagram.Text = "Діаграма";
            btnRefreshDiagram.UseVisualStyleBackColor = true;
            btnRefreshDiagram.Click += btnRefreshDiagram_Click;
            // 
            // btnBuildNGram
            // 
            btnBuildNGram.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBuildNGram.Location = new Point(80, 86);
            btnBuildNGram.Margin = new Padding(3, 2, 3, 2);
            btnBuildNGram.Name = "btnBuildNGram";
            btnBuildNGram.Size = new Size(105, 39);
            btnBuildNGram.TabIndex = 10;
            btnBuildNGram.Text = "Зберегти в Exel";
            btnBuildNGram.UseVisualStyleBackColor = true;
            btnBuildNGram.Click += btnBuildNGram_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(cbStatistic);
            groupBox3.Controls.Add(btnBuildNGram);
            groupBox3.Controls.Add(btnRefreshDiagram);
            groupBox3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            groupBox3.Location = new Point(580, 11);
            groupBox3.Margin = new Padding(3, 2, 3, 2);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 2, 3, 2);
            groupBox3.Size = new Size(197, 130);
            groupBox3.TabIndex = 10;
            groupBox3.TabStop = false;
            groupBox3.Text = "Статистика";
            // 
            // cbStatistic
            // 
            cbStatistic.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatistic.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold);
            cbStatistic.FormattingEnabled = true;
            cbStatistic.Items.AddRange(new object[] { "Абсолютні величини", "Відносні величини" });
            cbStatistic.Location = new Point(6, 28);
            cbStatistic.Margin = new Padding(4, 3, 4, 3);
            cbStatistic.Name = "cbStatistic";
            cbStatistic.Size = new Size(179, 21);
            cbStatistic.TabIndex = 11;
            cbStatistic.SelectedIndexChanged += cbStatistic_SelectedIndexChanged;
            // 
            // dgv_CharStat
            // 
            dgv_CharStat.AllowUserToAddRows = false;
            dgv_CharStat.AllowUserToDeleteRows = false;
            dgv_CharStat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgv_CharStat.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgv_CharStat.ColumnHeadersHeight = 29;
            dgv_CharStat.Columns.AddRange(new DataGridViewColumn[] { cLetter, cFreq });
            dgv_CharStat.Location = new Point(793, 144);
            dgv_CharStat.Margin = new Padding(4, 3, 4, 3);
            dgv_CharStat.MultiSelect = false;
            dgv_CharStat.Name = "dgv_CharStat";
            dgv_CharStat.RightToLeft = RightToLeft.No;
            dgv_CharStat.RowHeadersVisible = false;
            dgv_CharStat.RowHeadersWidth = 51;
            dgv_CharStat.Size = new Size(158, 401);
            dgv_CharStat.TabIndex = 6;
            dgv_CharStat.VirtualMode = true;
            dgv_CharStat.CellValueNeeded += dgv_CharStat_CellValueNeeded;
            // 
            // cLetter
            // 
            cLetter.HeaderText = "Символ";
            cLetter.MinimumWidth = 6;
            cLetter.Name = "cLetter";
            cLetter.ReadOnly = true;
            cLetter.Width = 76;
            // 
            // cFreq
            // 
            cFreq.HeaderText = "Кількість";
            cFreq.MinimumWidth = 6;
            cFreq.Name = "cFreq";
            cFreq.ReadOnly = true;
            cFreq.Width = 81;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(965, 556);
            Controls.Add(dgv_CharStat);
            Controls.Add(groupBox3);
            Controls.Add(button2);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(formsPlot1);
            Controls.Add(dgv_Texts);
            Controls.Add(button1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgv_Texts).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ngram_len).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_CharStat).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private DataGridView dgv_Texts;
        private DataGridViewTextBoxColumn cPP;
        private DataGridViewTextBoxColumn cNameText;
        private DataGridViewTextBoxColumn cCharsCount;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private GroupBox groupBox1;
        private Label label1;
        private ComboBox cbTextEncoding;
        private Label label2;
        private NumericUpDown ngram_len;
        private Label label4;
        private Label label3;
        private ComboBox cbIgnoreCase;
        private ComboBox cbSpaceDisable;
        private GroupBox groupBox2;
        private ComboBox cbLanguage;
        private RichTextBox rtManualInput;
        private Button button2;
        private Button btnRefreshDiagram;
        private Button btnBuildNGram;
        private GroupBox groupBox3;
        private ComboBox comboBox1;
        private ComboBox cbStatistic;
        private DataGridView dgv_CharStat;
        private DataGridViewTextBoxColumn cLetter;
        private DataGridViewTextBoxColumn cFreq;
    }
}
