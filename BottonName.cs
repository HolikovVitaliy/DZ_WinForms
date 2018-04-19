using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_5
{
    public class BottonName
    {
        public string FileStripMenuItem1 { get; set; }//Файл
        public string NewToolStripMenuItem { get; set; }//Создать
        public string OpenToolStripMenuItem { get; set; }//Открыть...
        public string SaveToolStripMenuItem { get; set; }//Сохранить
        public string SaveAsToolStripMenuItem { get; set; }//Сохранить как...
        public string ExitToolStripMenuItem { get; set; }//Выйти
        public string EditStripMenuItem { get; set; }//Правка
        public string UondoToolStripMenuItem { get; set; }//Отменить
        public string RedoToolStripMenuItem { get; set; }//Повторить
        public string SelectAllToolStripMenuItem { get; set; }//Выделить всё
        public string DeleteToolStripMenuItem { get; set; }//Удалить
        public string CopyToolStripMenuItem { get; set; }//Копировать
        public string CutToolStripMenuItem { get; set; }//Вырезать
        public string PasteToolStripMenuItem { get; set; }//Вставить
        public string OptionStripMenuItem { get; set; }//Опции
        public string DefaltToolStripMenuItem { get; set; }//По умолчанию
        public string Font1ToolStripMenuItem { get; set; }//Шрифт
        public string ColorToolStripMenuItem { get; set; }//Цвет фона
        public string QuestionStripMenuItem1 { get; set; }//О программе
        public string ClearToolStripMenuItem { get; set; }//Очистить
        public string ToolStripStatusLabLang { get; set; }//Язык
        public string ToolStripStatusLabFile { get; set; }//Файл:
        public string TextFilter { get; set; }//Все файлы |*.*|Текстовые файлы |*.txt||
        public string TextSave { get; set; }//Сохранить документ?
        public string TextBooffer { get; set; }//Буфер пустой!
        public BottonName() { }
        public BottonName(string FileTool, string NewTool, string OpenTool, string SaveTool,
            string SaveAsTool, string ExitTool, string EditStrip, string UondoTool,
            string RedoTool, string SelectAll, string DeleteTool, string CopyTool,
            string CutTool, string PasteTool, string OptionStrip, string DefaltTool,
            string Font1Tool, string ColorTool, string QuestionStrip, string ClearTool,
            string StatusLabLang, string StatusLabFile, string textFilter, string textSave, string textBooffer)
        {
            FileStripMenuItem1 = FileTool;//Файл
            NewToolStripMenuItem = NewTool;//Создать
            OpenToolStripMenuItem = OpenTool;//Открыть
            SaveToolStripMenuItem = SaveTool;//Сохранить
            SaveAsToolStripMenuItem = SaveAsTool;//Сохранить как...
            ExitToolStripMenuItem = ExitTool;//Выйти
            EditStripMenuItem = EditStrip;//Правка
            UondoToolStripMenuItem = UondoTool;//Отменить
            RedoToolStripMenuItem = RedoTool;//Повторить
            SelectAllToolStripMenuItem = SelectAll;//Выделить всё
            DeleteToolStripMenuItem = DeleteTool;//Удалить
            CopyToolStripMenuItem = CopyTool;//Копировать
            CutToolStripMenuItem = CutTool;//Вырезать
            PasteToolStripMenuItem = PasteTool;//Вставить
            OptionStripMenuItem = OptionStrip;//Опции
            DefaltToolStripMenuItem = DefaltTool;//По умолчанию
            Font1ToolStripMenuItem = Font1Tool;//Шрифт
            ColorToolStripMenuItem = ColorTool;//Цвет фона
            QuestionStripMenuItem1 = QuestionStrip;//О программе
            ClearToolStripMenuItem = ClearTool;//Очистить
            ToolStripStatusLabLang = StatusLabLang;//Язык
            ToolStripStatusLabFile = StatusLabFile;//Файл:
            TextFilter = textFilter;//Все файлы |*.*|Текстовые файлы |*.txt||
            TextSave = textSave;//Сохранить документ?
            TextBooffer = textBooffer;//Буфер пустой!
        }
    }
}
