using System.Data;
using System.Text;
using NGramStatistics.Models;
using NGramStatistics.Properties;
using NGramStatistics.Utill;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using ScottPlot;

namespace NGramStatistics
{
    public partial class Form1 : Form
    {
        private static List<FileDetails> _fileDetails = new List<FileDetails>();
        private static string _lastSelectedFolder;
        private static Encoding _textEncoding = Encoding.GetEncoding("UTF-8");
        private static bool _ignoreSpaces = true;
        private static bool _ignoreCase = true;
        private static Symbols _symbols = Symbols.Latin;
        private static List<string> _manualInputSymbols = new List<string>();
        private static Statistic _statistic = Statistic.Absolute;
        private NGramStatistic _nGramStatistic;
        private DataTable table = new DataTable();
        private DataTable _dataTableWithAbsoluteData = new DataTable();
        private DataTable _dataTableWithRelativeData = new DataTable();

        public Form1()
        {
            this.StartPosition = FormStartPosition.Manual; // Allow manual setting of form position
            this.Load += MainForm_Load;
            this.Resize += MainForm_Resize;
            InitializeComponent();
            LoadLastSelectedFolder();
            LoadInitialPlot();
            cbIgnoreCase.SelectedIndex = 0;
            cbSpaceDisable.SelectedIndex = 0;
            cbTextEncoding.SelectedIndex = 0;
            cbLanguage.SelectedIndex = 0;
            cbStatistic.SelectedIndex = 0;
            table.Columns.Add("Cимволи", typeof(string));
            table.Columns.Add("Кількість", typeof(string));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CenterForm();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            // Handle form resize if needed
        }

        private void CenterForm()
        {
            // Center the form on the screen
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            int x = (screen.Width - this.Width) / 2;
            int y = (screen.Height - this.Height) / 2;
            this.Location = new Point(x, y);
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            // Ensure form stays within screen bounds
            EnsureFormWithinScreenBounds();
        }

        private void EnsureFormWithinScreenBounds()
        {
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;

            if (this.Left < screen.Left)
                this.Left = screen.Left;

            if (this.Top < screen.Top)
                this.Top = screen.Top;

            if (this.Right > screen.Right)
                this.Left = screen.Right - this.Width;

            if (this.Bottom > screen.Bottom)
                this.Top = screen.Bottom - this.Height;
        }

        // Вибір папки з текстами
        private void button1_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                if (!string.IsNullOrEmpty(_lastSelectedFolder))
                {
                    folderBrowserDialog.SelectedPath = _lastSelectedFolder;
                }

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    _lastSelectedFolder = folderBrowserDialog.SelectedPath;
                    Settings.Default.LastSelectedFolder = _lastSelectedFolder;
                    Settings.Default.Save();

                    _fileDetails = Directory.GetFiles(_lastSelectedFolder, "*.txt")
                        .Select(file => new FileDetails
                        {
                            FileName = Path.GetFileName(file),
                            FileLocation = file,
                            FileSize = new FileInfo(file).Length
                        })
                        .ToList();

                    LoadFileDetailsTable();
                }
            }
        }

        // Збереження останньої вибраної локації Settings
        private void SaveLastSelectedFolder()
        {
            Settings.Default.LastSelectedFolder = _lastSelectedFolder;
            Settings.Default.Save();
        }

        // Ініціалізація локації з Settings
        private void LoadLastSelectedFolder()
        {
            _lastSelectedFolder = Settings.Default.LastSelectedFolder;
        }

        // Ініціалізація таблиці з назвами файлів
        private void LoadFileDetailsTable()
        {
            dgv_Texts.Rows.Clear();
            foreach (var fileDetails in _fileDetails)
            {
                dgv_Texts.Rows.Add(dgv_Texts.Rows.Count + 1, fileDetails.FileName, $"{fileDetails.FileSize} байт");
            }
        }

        // Ініціалізація початкового графіку
        private void LoadInitialPlot()
        {
            Plot plot = formsPlot1.Plot;

            double[] values = { 10, 20, 30, 40, 50, 60 };

            plot.Add.Bars(values);

            Tick[] ticks =
            {
                new Tick(0, "A"),
                new Tick(1, "B"),
                new Tick(2, "C"),
                new Tick(3, "D"),
                new Tick(4, "E"),
                new Tick(5, "F")
            };

            plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);

            formsPlot1.Refresh();
        }

        // Кодування файлів
        private void CbTextEncoding_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTextEncoding.SelectedIndex == 1)
            {
                _textEncoding = Encoding.GetEncoding("Win-1251");
            }
            else
            {
                _textEncoding = Encoding.GetEncoding("UTF-8");
            }
        }

        // Ігнорувати пробіли
        private void CbSpaceDisable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSpaceDisable.SelectedIndex == 1)
            {
                _ignoreSpaces = false;
            }
            else
            {
                _ignoreSpaces = true;
            }
        }

        // Ігнорувати регістр
        private void cbIgnoreCase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIgnoreCase.SelectedIndex == 0)
            {
                _ignoreCase = true;
            }
            else
            {
                _ignoreCase = false;
            }
        }

        // Вибір символів
        private void cbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            _symbols = cbLanguage.SelectedIndex switch
            {
                0 => Symbols.Latin,
                1 => Symbols.Cyrillic,
                2 => Symbols.Digits,
                3 => Symbols.ManualInput,
                _ => Symbols.Latin
            };

            if (_symbols == Symbols.ManualInput)
            {
                ShowManualTextInput();
            }
            else
            {
                HideManualTextInput();
            }
        }

        private void ShowManualTextInput()
        {
            if (!String.IsNullOrWhiteSpace(Settings.Default.UserSymbols))
            {
                rtManualInput.Text = Settings.Default.UserSymbols;
                Settings.Default.Save();
                _manualInputSymbols = ParseTextToList(rtManualInput.Text);
            }

            rtManualInput.Visible = true;
        }

        private void HideManualTextInput()
        {
            if (!String.IsNullOrWhiteSpace(rtManualInput.Text))
            {
                Settings.Default.UserSymbols = rtManualInput.Text;
                Settings.Default.Save();
                _manualInputSymbols = ParseTextToList(rtManualInput.Text);
            }

            rtManualInput.Visible = false;
        }

        private void rtManualInput_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(rtManualInput.Text))
            {
                Settings.Default.UserSymbols = rtManualInput.Text;
                Settings.Default.Save();
                _manualInputSymbols = ParseTextToList(rtManualInput.Text);
            }
        }

        // Парсинг символів які ввів користувач
        private List<string> ParseTextToList(string text)
        {
            string cleanedText = text.Replace("\r", "").Replace("\n", "").Replace(" ", "");

            string[] splitText = cleanedText.Split(',');

            return splitText.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _nGramStatistic = new NGramStatistic(_fileDetails.Select(x => x.FileLocation).ToArray(), (int)ngram_len.Value, _ignoreCase, _ignoreSpaces);

            _nGramStatistic.ProcessFile();
            _nGramStatistic.CalculateRelativeStatistic();
        }

        // Вибір статистики
        private void cbStatistic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStatistic.SelectedIndex == 0)
            {
                _statistic = Statistic.Absolute;
            }
            else
            {
                _statistic = Statistic.Relative;
            }
        }

        private void btnRefreshDiagram_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> filteredStatsAbsolute = new Dictionary<string, int>();
            Dictionary<string, double> filteredStatsRelative = new Dictionary<string, double>();

            switch (_symbols, _statistic)
            {
                case (Symbols.Cyrillic, Statistic.Absolute):
                    filteredStatsAbsolute = _nGramStatistic.totalAbsoluteStatistic
                        .Where(kvp => IsCyrillicWord(kvp.Key))
                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                    break;
                case (Symbols.Latin, Statistic.Absolute):
                    filteredStatsAbsolute = _nGramStatistic.totalAbsoluteStatistic
                        .Where(kvp => IsLatinWord(kvp.Key))
                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                    break;
                case (Symbols.Digits, Statistic.Absolute):
                    filteredStatsAbsolute = _nGramStatistic.totalAbsoluteStatistic
                        .Where(kvp => IsDigit(kvp.Key))
                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                    break;
                case (Symbols.ManualInput, Statistic.Absolute):
                    filteredStatsAbsolute = _nGramStatistic.totalAbsoluteStatistic
                        .Where(kvp => _manualInputSymbols.Contains(kvp.Key))
                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                    break;
                case (Symbols.Cyrillic, Statistic.Relative):
                    filteredStatsRelative = _nGramStatistic.MX
                        .Where(kvp => IsCyrillicWord(kvp.Key))
                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                    break;
                case (Symbols.Latin, Statistic.Relative):
                    filteredStatsRelative = _nGramStatistic.MX
                        .Where(kvp => IsLatinWord(kvp.Key))
                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                    break;
                case (Symbols.Digits, Statistic.Relative):
                    filteredStatsRelative = _nGramStatistic.MX
                        .Where(kvp => IsDigit(kvp.Key))
                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                    break;
                case (Symbols.ManualInput, Statistic.Relative):
                    filteredStatsRelative = _nGramStatistic.MX
                        .Where(kvp => _manualInputSymbols.Contains(kvp.Key))
                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                    break;
            }

            List<double> values = new List<double>();
            List<Tick> ticks = new List<Tick>();

            table.Rows.Clear();

            int i = 0;
            if (_statistic == Statistic.Absolute)
            {
                foreach (var ch in filteredStatsAbsolute.OrderByDescending(v => v.Value))
                {
                    table.Rows.Add(ch.Key, ch.Value.ToString());

                    values.Add(ch.Value);
                    ticks.Add(new Tick(i, ch.Key));
                    i++;
                }
            }
            else
            {
                foreach (var ch in filteredStatsRelative.OrderByDescending(v => v.Value))
                {
                    table.Rows.Add(ch.Key, ch.Value.ToString());

                    values.Add(ch.Value);
                    ticks.Add(new Tick(i, ch.Key));
                    i++;
                }
            }

            dgv_CharStat.Rows.Clear();
            dgv_CharStat.RowCount = table.Rows.Count;

            Plot plot = formsPlot1.Plot;

            plot.Clear();
            var bar = plot.Add.Bars(values.ToArray());
            if (values.Count > 1000)
            {
                ticks.Clear();
            }

            plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks.ToArray());


            plot.Axes.AutoScale();
            formsPlot1.Refresh();
        }


        private bool IsCyrillicWord(string s)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(s, @"^[\p{IsCyrillic}\s]+$");
        }

        private bool IsLatinWord(string s)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(s, @"^[A-Za-z\s]+$");
        }

        private bool IsSymbol(string s)
        {
            return s.Length == 1 && (char.IsSymbol(s[0]) || char.IsPunctuation(s[0]));
        }

        private bool IsDigit(string s)
        {
            return s.Length == 1 && char.IsDigit(s[0]);
        }

        private void dgv_CharStat_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < table.Rows.Count)
            {
                DataRow row = table.Rows[e.RowIndex];
                switch (e.ColumnIndex)
                {
                    case 0:
                        e.Value = row["Cимволи"];
                        break;
                    case 1:
                        e.Value = row["Кількість"];
                        break;
                }
            }
        }

        private void btnBuildNGram_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Save an Excel File";
                saveFileDialog.FileName = _statistic == Statistic.Absolute ? "AbsoluteDataTableExport.xlsx" : "RelativeDataTableExport.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (_statistic == Statistic.Absolute)
                    {
                        GenerateAbsoluteDataTable();
                        SaveDataTableToExcel(_dataTableWithAbsoluteData, saveFileDialog.FileName, true);
                    }
                    else
                    {
                        GenerateRelativeDataTable();
                        SaveDataTableToExcel(_dataTableWithRelativeData, saveFileDialog.FileName, false);
                    }

                    MessageBox.Show("Excel file saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void GenerateAbsoluteDataTable()
        {
            _dataTableWithAbsoluteData = new DataTable();

            _dataTableWithAbsoluteData.Columns.Add("Назва файлу", typeof(string));

            Dictionary<string, int> filteredStatsRelative = new Dictionary<string, int>();

            switch (_symbols)
            {
                case (Symbols.Cyrillic):
                    filteredStatsRelative = _nGramStatistic.totalAbsoluteStatistic
                        .Where(kvp => IsCyrillicWord(kvp.Key))
                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                    break;
                case (Symbols.Latin):
                    filteredStatsRelative = _nGramStatistic.totalAbsoluteStatistic
                        .Where(kvp => IsLatinWord(kvp.Key))
                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                    break;
                case (Symbols.Digits):
                    filteredStatsRelative = _nGramStatistic.totalAbsoluteStatistic
                        .Where(kvp => IsDigit(kvp.Key))
                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                    break;
                case (Symbols.ManualInput):
                    filteredStatsRelative = _nGramStatistic.totalAbsoluteStatistic
                        .Where(kvp => _manualInputSymbols.Contains(kvp.Key))
                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                    break;
            }

            var sortedNGram = filteredStatsRelative.DistinctBy(x => x.Key).OrderBy(x => x.Key).ToList();


            foreach (var nGram in sortedNGram)
            {
                _dataTableWithAbsoluteData.Columns.Add(nGram.Key, typeof(string));
            }


            foreach (var stat in _nGramStatistic.filesAbsoluteStatistic)
            {
                DataRow row = _dataTableWithAbsoluteData.NewRow();
                row["Назва файлу"] = stat.Key;

                foreach (var ngram in sortedNGram)
                {
                    row[ngram.Key] = stat.Value.TryGetValue(ngram.Key, out int value) ? value : 0;
                }

                _dataTableWithAbsoluteData.Rows.Add(row);
            }

            DataRow mxRow = _dataTableWithAbsoluteData.NewRow();
            mxRow["Назва файлу"] = "MX";
            foreach (var ngram in sortedNGram)
            {
                mxRow[ngram.Key] = _nGramStatistic.MX.TryGetValue(ngram.Key, out double value) ? value : 0;
            }
            _dataTableWithAbsoluteData.Rows.Add(mxRow);


            DataRow sigmaRow = _dataTableWithAbsoluteData.NewRow();
            sigmaRow["Назва файлу"] = "Sigma";
            foreach (var ngram in sortedNGram)
            {
                sigmaRow[ngram.Key] = _nGramStatistic.Sigma.TryGetValue(ngram.Key, out double value) ? value : 0;
            }
            _dataTableWithAbsoluteData.Rows.Add(sigmaRow);
        }

        private void GenerateRelativeDataTable()
        {
            _dataTableWithRelativeData = new DataTable();

            _dataTableWithRelativeData.Columns.Add("Назва файлу", typeof(string));

            Dictionary<string, int> filteredStatsRelative = new Dictionary<string, int>();

            switch (_symbols)
            {
                case (Symbols.Cyrillic):
                    filteredStatsRelative = _nGramStatistic.totalAbsoluteStatistic
                        .Where(kvp => IsCyrillicWord(kvp.Key))
                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                    break;
                case (Symbols.Latin):
                    filteredStatsRelative = _nGramStatistic.totalAbsoluteStatistic
                        .Where(kvp => IsLatinWord(kvp.Key))
                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                    break;
                case (Symbols.Digits):
                    filteredStatsRelative = _nGramStatistic.totalAbsoluteStatistic
                        .Where(kvp => IsDigit(kvp.Key))
                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                    break;
                case (Symbols.ManualInput):
                    filteredStatsRelative = _nGramStatistic.totalAbsoluteStatistic
                        .Where(kvp => _manualInputSymbols.Contains(kvp.Key))
                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
                    break;
            }

            var sortedNGram = filteredStatsRelative.DistinctBy(x => x.Key).OrderBy(x => x.Key).ToList();


            foreach (var nGram in sortedNGram)
            {
                _dataTableWithRelativeData.Columns.Add(nGram.Key, typeof(string));
            }


            foreach (var stat in _nGramStatistic.filesRelativeStatistic)
            {
                DataRow row = _dataTableWithRelativeData.NewRow();
                row["Назва файлу"] = stat.Key;

                foreach (var ngram in sortedNGram)
                {
                    row[ngram.Key] = stat.Value.TryGetValue(ngram.Key, out double value) ? Math.Round(value, 9, MidpointRounding.AwayFromZero) : 0;
                }

                _dataTableWithRelativeData.Rows.Add(row);
            }


            DataRow mxRow = _dataTableWithRelativeData.NewRow();
            mxRow["Назва файлу"] = "MX";
            foreach (var ngram in sortedNGram)
            {
                mxRow[ngram.Key] = _nGramStatistic.MX.TryGetValue(ngram.Key, out double value) ? Math.Round(value, 9, MidpointRounding.AwayFromZero) : 0;
            }
            _dataTableWithRelativeData.Rows.Add(mxRow);


            DataRow sigmaRow = _dataTableWithRelativeData.NewRow();
            sigmaRow["Назва файлу"] = "Sigma";
            foreach (var ngram in sortedNGram)
            {
                sigmaRow[ngram.Key] = _nGramStatistic.Sigma.TryGetValue(ngram.Key, out double value) ? Math.Round(value, 9, MidpointRounding.AwayFromZero) : 0;
            }
            _dataTableWithRelativeData.Rows.Add(sigmaRow);
        }

        private void SaveDataTableToExcel(DataTable dt, string filePath, bool intValue)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            int maxColumnsPerSheet = 16384;

            using (ExcelPackage pck = new ExcelPackage())
            {
                int sheetCount = (dt.Columns.Count + maxColumnsPerSheet - 1) / maxColumnsPerSheet;

                for (int sheetIndex = 0; sheetIndex < sheetCount; sheetIndex++)
                {
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Sheet" + (sheetIndex + 1));
                    int startColumn = sheetIndex * maxColumnsPerSheet;
                    int endColumn = Math.Min(startColumn + maxColumnsPerSheet, dt.Columns.Count);

                    DataTable subset = new DataTable();
                    for (int colIndex = startColumn; colIndex < endColumn; colIndex++)
                    {
                        string columnName = dt.Columns[colIndex].ColumnName;
                        if (subset.Columns.Contains(columnName))
                        {
                            columnName += "_" + sheetIndex;
                        }
                        subset.Columns.Add(columnName, dt.Columns[colIndex].DataType);
                    }

                    foreach (DataRow row in dt.Rows)
                    {
                        DataRow newRow = subset.NewRow();
                        for (int colIndex = startColumn; colIndex < endColumn; colIndex++)
                        {
                            newRow[colIndex - startColumn] = row[colIndex];
                        }
                        subset.Rows.Add(newRow);
                    }

                    ws.Cells["A1"].LoadFromDataTable(subset, true, TableStyles.None);

                    // Ensure numeric values are not stored as text
                    for (int colIndex = 2; colIndex <= ws.Dimension.End.Column; colIndex++)
                    {
                        for (int rowIndex = 2; rowIndex <= ws.Dimension.End.Row; rowIndex++)
                        {
                            if (int.TryParse(ws.Cells[rowIndex, colIndex].Text, out int result))
                            {
                                ws.Cells[rowIndex, colIndex].Value = result;
                                ws.Cells[rowIndex, colIndex].Style.Numberformat.Format = "0";
                            }
                            else if (double.TryParse(ws.Cells[rowIndex, colIndex].Text, out double result2))
                            {
                                ws.Cells[rowIndex, colIndex].Value = result2;
                                ws.Cells[rowIndex, colIndex].Style.Numberformat.Format = "0.000000000";
                            }
                        }
                    }

                    // Auto-fit columns
                    ws.Cells[ws.Dimension.Address].AutoFitColumns();
                }

                FileInfo file = new FileInfo(filePath);
                pck.SaveAs(file);
            }
        }
    }
}
