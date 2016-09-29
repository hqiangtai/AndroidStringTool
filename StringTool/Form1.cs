using StringTool.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StringTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
              SaveFileDialog sfd = new SaveFileDialog();
              sfd.Title = "请选择文件存放路径";
              sfd.FileName = "导出数据";
              sfd.Filter = "Excel2003文档(*.xls)|*.xls|Excel2007文档(*.xlsx)|*.xlsx";
              DialogResult result = sfd.ShowDialog();
              if (result != DialogResult.OK){
                  return;
              }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog pathDialog = new FolderBrowserDialog();
            pathDialog.SelectedPath = @"E:\TCL_work\APP5.4.8\apps\oStore\src\main\res";
            pathDialog.ShowNewFolderButton = false;
             
            DialogResult result = pathDialog.ShowDialog();
            if (result == DialogResult.OK)
            {

                textBox_resflode.Text = pathDialog.SelectedPath;
                createColumArray();
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.ReadOnlyChecked = true;
            fileDialog.Filter = "Excel2003文档(*.xls)|*.xls|Excel2007文档(*.xlsx)|*.xlsx";
            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.OK) {
                textBox3.Text = fileDialog.FileName;
            }
           
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private bool checkFileAndFlode() {
           
            string orgFlode = textBox_resflode.Text.Trim();
            if ( orgFlode.Length>0 && Directory.Exists(orgFlode))
            {
              
                    return true;
            }
        
            return false;
        }
        bool pointInPolygon(int polyCorners,int x,int y)
        {
            int[] polyY=null,polyX=null;
            int i, j = polyCorners - 1;
            bool oddNodes = false;

            for (i = 0; i < polyCorners; i++)
            {
                if (polyY[i] < y && polyY[j] >= y
                || polyY[j] < y && polyY[i] >= y)
                {
                    if (polyX[i] + (y - polyY[i]) / (polyY[j] - polyY[i]) * (polyX[j] - polyX[i]) < x)
                    {
                        oddNodes = !oddNodes;
                    }
                }
                j = i;
            }

            return oddNodes;
        }

        private void changExportVisual() {
            export_button.Visible = checkFileAndFlode();
        }
        private AboutBox1 aboutBox;
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(aboutBox==null )
              aboutBox = new AboutBox1();

            aboutBox.ShowDialog();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        private void createDefaultColum() {
            DataGridViewTextBoxColumn acCode = new DataGridViewTextBoxColumn();
            acCode.Name = "default_value";
            acCode.DataPropertyName = "default_value";
            acCode.HeaderText = " 默认资源";
           
            dataGridView_preview.Columns.Add(acCode);
        }

        private void dataGridView_preview_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
              var dgv = (DataGridView)sender;
             if (dgv.RowHeadersVisible)
              {
                  Rectangle rect = new Rectangle(e.RowBounds.Left, e.RowBounds.Top,
                                                 dgv.RowHeadersWidth, e.RowBounds.Height);
                  rect.Inflate(-2, -2);
                  TextRenderer.DrawText(e.Graphics,
                     (e.RowIndex + 1).ToString(),
                     e.InheritedRowStyle.Font,
                     rect, e.InheritedRowStyle.ForeColor,
                     TextFormatFlags.Left | TextFormatFlags.VerticalCenter
                     );
             }
        }
        private void createColum(string colName,string headerTxt ) {
            DataGridViewTextBoxColumn acCode = new DataGridViewTextBoxColumn();
            acCode.Name = colName;
            acCode.DataPropertyName = colName;
            acCode.HeaderText = headerTxt;
            dataGridView_preview.Columns.Add(acCode);
        }
        private void createColumArray() {
            if (checkFileAndFlode())
            {
                List<DirectoryInfo> dirList = FileUtils.getDirs(textBox_resflode.Text.Trim(),  "values*");
                if (dirList.Count <= 0)
                {
                    MessageBox.Show("该资源文件夹内不存在资源文件");
                }
                else
                {
                    foreach(DirectoryInfo dir in dirList){
                        if (dir.Name.Equals("values"))
                        {
                            createColum(dir.Name,"默认资源"); 
                        }
                        else { 
                            createColum(dir.Name, dir.Name); 
                        }
                        
                    }
                    
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
