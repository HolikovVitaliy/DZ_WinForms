using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DZ_5
{ 
    public partial class Form1 : Form
    {
        BottonName rusBotton;
        BottonName engBotton;
        string DocName = "";//название документа
        string textFilter = "";//строка с фильтром на открытие/сохранение
        string textSave = "";//Сохранить документ?
        string textBooffer = "";//Буфер пустой!
        OpenFileDialog open;
        SaveFileDialog save;
        string BufferText;
        //значения настроек по умолчанию:
        Color bColorDefault;
        Color fontColorDefault;
        Font fontDefault;

        public Form1() {
            InitializeComponent();
            rusBotton = new BottonName
            (
                "Файл", "Создать", "Открыть...", "Сохранить", "Сохранить как...", "Выйти",
                "Правка", "Отменить", "Повторить", "Выделить всё", "Удалить", "Копировать",
                "Вырезать", "Вставить", "Формат", "По умолчанию", "Шрифт", "Цвет фона",
                "О программе", "Очистить", "Язык ", "Файл: ", "Все файлы |*.*|Текстовые файлы |*.txt||",
                "Сохранить документ?", "Буфер пустой!"
            );
            engBotton = new BottonName
            (
                "Fail", "New", "Open...", "Save", "Save As...", "Exit", "Edit", "Undo", "Redo",
                "Select All", "Delete", "Copy", "Cut", "Paste", "Format", "Defaulte", "Font",
                "Background color", "Info", "Clear", "Language ", "Fail: ", "All Files|*.*|Text Fail|*.txt||",
                "Document save?", "Buffer null!"
            );
            StartPosition = FormStartPosition.CenterScreen;
            colorToolStripMenuItem.Click += colorToolStripMenuItem_Click;
            defaltToolStripMenuItem.Click += defaltToolStripMenuItem_Click;
            richTextBox1.AllowDrop = true;
            richTextBox1.DragEnter += new DragEventHandler(richTextBox1_DragEnter);
            richTextBox1.DragDrop += new DragEventHandler(richTextBox1_DragDrop);
            bColorDefault = richTextBox1.BackColor;
            fontColorDefault = richTextBox1.SelectionColor;
            fontDefault = richTextBox1.SelectionFont;
            MenuLang(rusBotton);
            strSosToolStripMenuItem.Checked = true;
            //strSosToolStripMenuItem.Click += strSosToolStripMenuItem_Click;
        }

        private void Form1_Load( object sender, EventArgs e ) {

        }
        //создать новый файл
        private void newToolStripMenuItem_Click( object sender, EventArgs e ) {
            if (richTextBox1.Text != "") {
                if (MessageBox.Show(textSave, "", MessageBoxButtons.YesNo ) == DialogResult.Yes) {
                    saveAsToolStripMenuItem_Click( saveAsToolStripMenuItem, e );
                }                
            }
            richTextBox1.Text = "";
            toolStripStatusLabel1.Text = "No DocName";
            if (MessageBox.Show(textSave, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                saveAsToolStripMenuItem_Click(saveAsToolStripMenuItem, e);
            }
            //saveAsToolStripMenuItem_Click( sender, e );
        }
        //открыть файл
        private void openToolStripMenuItem_Click( object sender, EventArgs e ) {
            open = new OpenFileDialog();
            open.Filter = textFilter;
            open.FilterIndex = 1;
            if (open.ShowDialog() == DialogResult.OK) {
                StreamReader reader = File.OpenText( open.FileName );
                richTextBox1.Text = reader.ReadToEnd();
                reader.Close();
                DocName = open.FileName.ToString();
                toolStripStatusLabel1.Text = Path.GetFileName(DocName);
                }
        }
        //сохранить
        private void saveToolStripMenuItem_Click( object sender, EventArgs e ) {
            if (DocName == "No DocName") {
                saveAsToolStripMenuItem_Click( sender, e);
                return;
                }
            else {
                StreamWriter sw = new StreamWriter( DocName );
                sw.WriteLine( richTextBox1.Text );
                sw.Close();
            }
        }
        //сохранить как
        private void saveAsToolStripMenuItem_Click( object sender, EventArgs e ) {
            save = new SaveFileDialog();
            save.Filter = textFilter;
            save.FilterIndex = 2;
            save.FileName = ".txt";
            if (save.ShowDialog() == DialogResult.OK) {
                StreamWriter sw = new StreamWriter( save.FileName );
                sw.WriteLine( richTextBox1.Text );
                sw.Close();
                toolStripStatusLabel1.Text = save.FileName;
            }
        }
        //выйти
        private void exitToolStripMenuItem_Click( object sender, EventArgs e ) {
            if (richTextBox1.Text != "") {
                if (MessageBox.Show(textSave, "", MessageBoxButtons.YesNo ) == DialogResult.Yes) {
                    saveAsToolStripMenuItem_Click( saveAsToolStripMenuItem, e );
                }
            }
            Close();
        }
        //отменить
        private void undoToolStripMenuItem_Click( object sender, EventArgs e ) {
            if (richTextBox1.CanUndo)
                richTextBox1.Undo();
        }
        private void undoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            undoToolStripMenuItem_Click(sender, e);
        }
        //повторить
        private void redoToolStripMenuItem_Click( object sender, EventArgs e ) {
            if (richTextBox1.CanRedo)
                richTextBox1.Redo();
        }

        private void redoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            redoToolStripMenuItem_Click( sender, e);
        }
        //очистить весь документ
        private void clearToolStripMenuItem_Click( object sender, EventArgs e ) {
            richTextBox1.Clear();
        }
        private void clearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            clearToolStripMenuItem_Click(sender, e);
        }
        //выделить всё
        private void selectAllToolStripMenuItem_Click( object sender, EventArgs e ) {
            richTextBox1.SelectAll();
        }
        private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectAllToolStripMenuItem_Click(sender, e);
        }
        //удалить выделенное
        private void deleteToolStripMenuItem_Click( object sender, EventArgs e ) {
            richTextBox1.SelectedText = "";
            BufferText = "";
        }
        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            deleteToolStripMenuItem_Click(sender, e);
        }
        //копировать
        private void copyToolStripMenuItem_Click( object sender, EventArgs e ) {
            BufferText = richTextBox1.SelectedText;
        }
        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            copyToolStripMenuItem_Click( sender, e);
        }
        //вырезать
        private void cutToolStripMenuItem_Click( object sender, EventArgs e ) {
            BufferText = richTextBox1.SelectedText;
            richTextBox1.SelectedText = "";
        }
        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cutToolStripMenuItem_Click(sender, e);
        }
        //вставить
        private void pasteToolStripMenuItem_Click( object sender, EventArgs e ) {
            if (BufferText != "")
                richTextBox1.SelectedText = BufferText;
            else MessageBox.Show(textBooffer);
        }
        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pasteToolStripMenuItem_Click(sender, e); 
        }
        //русское меню
        private void MenuLang(BottonName lang)
        {
            fileStripMenuItem1.Text = lang.FileStripMenuItem1;
            newToolStripMenuItem.Text = lang.NewToolStripMenuItem;
            openToolStripMenuItem.Text = lang.OpenToolStripMenuItem;
            saveToolStripMenuItem.Text = lang.SaveToolStripMenuItem;
            saveAsToolStripMenuItem.Text = lang.SaveAsToolStripMenuItem;
            exitToolStripMenuItem.Text = lang.ExitToolStripMenuItem;
            editStripMenuItem.Text = lang.EditStripMenuItem;
            undoToolStripMenuItem1.Text = undoToolStripMenuItem.Text = lang.UondoToolStripMenuItem;
            redoToolStripMenuItem1.Text = redoToolStripMenuItem.Text = lang.RedoToolStripMenuItem;
            selectAllToolStripMenuItem1.Text = selectAllToolStripMenuItem.Text = lang.SelectAllToolStripMenuItem;
            deleteToolStripMenuItem1.Text = deleteToolStripMenuItem.Text = lang.DeleteToolStripMenuItem;
            copyToolStripMenuItem1.Text = copyToolStripMenuItem.Text = lang.CopyToolStripMenuItem;
            cutToolStripMenuItem1.Text = cutToolStripMenuItem.Text = lang.CutToolStripMenuItem;
            pasteToolStripMenuItem1.Text = pasteToolStripMenuItem.Text = lang.PasteToolStripMenuItem;
            optionStripMenuItem.Text = lang.OptionStripMenuItem;
            defaltToolStripMenuItem.Text = lang.DefaltToolStripMenuItem;
            font1ToolStripMenuItem.Text = lang.Font1ToolStripMenuItem;
            colorToolStripMenuItem.Text = lang.ColorToolStripMenuItem;
            questionStripMenuItem1.ToolTipText = lang.QuestionStripMenuItem1;
            toolStripStatusLabLang.Text = lang.ToolStripStatusLabLang;
            toolStripStatusLabFile.Text = lang.ToolStripStatusLabFile;
            textFilter = lang.TextFilter;
            textSave = lang.TextSave;
            clearToolStripMenuItem.Text = lang.ClearToolStripMenuItem;
            textBooffer = lang.TextBooffer;
        }
        //вернуть настройки по умолчанию
        private void defaltToolStripMenuItem_Click( object sender, EventArgs e ) {
            MenuLang(rusBotton);
            richTextBox1.BackColor = bColorDefault;
                richTextBox1.SelectAll();
                richTextBox1.SelectionFont = fontDefault;
                richTextBox1.SelectionColor = fontColorDefault;
                richTextBox1.Select( 0, 0 );
        }
        //окно о программе
        private void questionStripMenuItem1_Click( object sender, EventArgs e ) {
            AboutDlg dlg = new AboutDlg();
            dlg.Show();
        }
        //шрифт
        private void font1ToolStripMenuItem_Click( object sender, EventArgs e ) {
            fontDialog1.ShowColor = true;
            fontDialog1.Font = richTextBox1.SelectionFont;
            fontDialog1.Color = richTextBox1.SelectionColor;
            richTextBox1.SelectAll();
            if (fontDialog1.ShowDialog() == DialogResult.OK) {
                richTextBox1.SelectionFont = fontDialog1.Font;
                richTextBox1.SelectionColor = fontDialog1.Color;
                }
            richTextBox1.Select( 0, 0 );
            }
        //цвет фона редактора
        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
            {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                richTextBox1.BackColor = colorDialog1.Color;                
            }
        //DragAndDrop
        private void richTextBox1_DragEnter( object sender, DragEventArgs e ) {
            if (e.Data.GetDataPresent( DataFormats.FileDrop ))
                e.Effect = DragDropEffects.Copy;
        }

        private void richTextBox1_DragDrop( object sender, DragEventArgs e ) {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            StreamReader str = new StreamReader(files[0]);
            richTextBox1.Text = str.ReadToEnd();
        }
        //английское меню
        private void englishToolStripMenuItem_Click(object sender, EventArgs e) {
            MenuLang(engBotton);
        }
        //русское меню
        private void rusToolStripMenuItem_Click_1( object sender, EventArgs e ) {
            MenuLang(rusBotton);
        }

        private void strSosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem it = (ToolStripMenuItem)sender;
            if(it.Checked == true)
                {
                statusStrip1.Visible = true;
                it.Checked = false;
                richTextBox1.Height -= statusStrip1.Height;
            }
            else
            {
                statusStrip1.Visible = false;
                it.Checked = true;
                richTextBox1.Height += statusStrip1.Height;
            }
        }
    }
}