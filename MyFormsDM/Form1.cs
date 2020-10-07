using Microsoft.VisualBasic;
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

namespace MyFormsDM
{
    public partial class Form1 : Form
    {
        TreeView tree;
        Button btn;
        Label lbl;
        CheckBox box_lbl, box_btn;
        RadioButton r1, r2;
        TextBox txt_box;
        PictureBox picture;
        TabControl tabControl;
        TabPage page1, page2, page3;
        public Form1()
        {
            this.Height = 500;
            this.Width = 600;
            this.Text = "Vorm elementiga";
            tree = new TreeView();
            tree.Dock = DockStyle.Right;
            tree.AfterSelect += Tree_AfterSelect;
            TreeNode tn = new TreeNode("Elemendid");
            tn.Nodes.Add(new TreeNode("Nupp - Button"));


            btn = new Button();
            btn.Text = "Vajuta siia";
            btn.Location = new Point(50, 10);
            btn.Height = 50;
            btn.Width = 150;
            btn.Click += Btn_Click;


            tn.Nodes.Add(new TreeNode("silt - Label"));


            lbl = new Label();
            lbl.Text = "Tarkvara";
            lbl.Size = new Size(150, 50);
            lbl.Location = new Point(110, 120);


            tn.Nodes.Add(new TreeNode("Märkeruut - CheckBox"));
            tn.Nodes.Add(new TreeNode("Radionupp - Radiobutton"));
            tn.Nodes.Add(new TreeNode("Tekstkast - TextBox"));
            tn.Nodes.Add(new TreeNode("Pildicast - PictureBox"));
            tn.Nodes.Add(new TreeNode("kaart - TabControl"));
            tn.Nodes.Add(new TreeNode("MessageBox"));
            tree.Nodes.Add(tn);
            this.Controls.Add(tree);
            

        }

        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Nupp - Button")
            {
                this.Controls.Add(btn);

            }
            else if (e.Node.Text == "silt - Label")
            {
                this.Controls.Add(lbl);
            }
            else if (e.Node.Text == "Märkeruut - CheckBox")
            {
                box_btn = new CheckBox();
                box_btn.Text = "Näita Button";
                box_btn.Location = new Point(230, 30);
                this.Controls.Add(box_btn);
                box_lbl = new CheckBox();
                box_lbl.Text = "Näita Label";
                box_lbl.Location = new Point(230, 50);
                this.Controls.Add(box_lbl);
                box_lbl.CheckedChanged += Box_lbl_CheckedChanged;
                box_btn.CheckedChanged += Box_btn_CheckedChanged;
            }
            else if (e.Node.Text == "Radionupp - Radiobutton")
            {
                r1 = new RadioButton();
                r1.Text = "nupp Vasakule";
                r1.Location = new Point(350, 30);
                r1.CheckedChanged += new EventHandler(RadioButton_Changed);
                r2 = new RadioButton();
                r2.Text = "nupp paremale";
                r2.Location = new Point(350, 50);
                r2.CheckedChanged += new EventHandler(RadioButton_Changed);

                this.Controls.Add(r1);
                this.Controls.Add(r2);

            }
            else if (e.Node.Text == "Tekstkast - TextBox")
            {
                string text;
                try
                {
                    text = File.ReadAllText(path: "text.txt");
                }
                catch (FileNotFoundException exception)
                {
                    text = "tekst puudub";
                }
                txt_box = new TextBox();
                txt_box.Multiline = true;
                txt_box.Text = text;
                txt_box.Location = new Point(50, 300);
                txt_box.Width = 200;
                txt_box.Height = 100;
            }
            else if(e.Node.Text == "Pildicast - PictureBox")
            {
                picture = new PictureBox();
                picture.Image = new Bitmap("cic.png");
                picture.Location = new Point(300, 450);
                picture.Size = new Size (100, 100);
                picture.SizeMode = PictureBoxSizeMode.Zoom;
                picture.BorderStyle = BorderStyle.Fixed3D;
                this.Controls.Add(picture);
            }
            else if(e.Node.Text == "kaart - TabControl")
            {
                tabControl = new TabControl();
                tabControl.Location = new Point(50, 400);
                tabControl.Size = new Size(100, 100);
                page1 = new TabPage("Esimene");
                page1.ImageIndex = 1;
                page2 = new TabPage("Teine");
                page2.ImageIndex = 2; 
                page3 = new TabPage("Kolmas");


                tabControl.Controls.Add(page1);
                tabControl.Controls.Add(page2);
                tabControl.Controls.Add(page3);
                tabControl.SelectedIndex = 2;
                this.Controls.Add(tabControl);
            }
            else if(e.Node.Text == "MessageBox")
            {
                MessageBox.Show("MessageBox", "Kõige lihtsam aken");
                var answer=MessageBox.Show("Tahad inpudBoxi näha?", "Aken koos nupudega" ,MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {

                    string text = Interaction.InputBox("Sisesta siia mingi tekst", "InputBox", "Mingi tekst");

                    if (MessageBox.Show("Kas tahad tekst saada Tekskastisse?", "Teksti salvestamine", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        lbl.Text = text;
                        Controls.Add(lbl);
                    }
                    else if(tabControl.SelectedIndex == 2)
                    {
                        page1.BackColor = Color.Red;
                    }
                }

            }
        }

        private void Box_lbl_CheckedChanged(object sender, EventArgs e)
        {
            if (box_lbl.Checked)
            {
                this.Controls.Add(lbl);
            }
            else
            {
                Controls.Remove(lbl);
            }
        }

        private void RadioButton_Changed(object sender, EventArgs e)
        {
            if (r1.Checked)
            {
                btn.Location = new Point(10, 3);
                lbl.Location = new Point(10, 2);
            }
            else if (r2.Checked)
            {
                btn.Location = new Point(10, 100);
                lbl.Location = new Point(10, 50);
            }
        }

        private void Box_btn_CheckedChanged(object sender, EventArgs e)
        {
            if(box_btn.Checked)
            {
                this.Controls.Add(btn);
            }
            else
            {
                Controls.Remove(btn);
            }
        }

        private void Btn_Click(object sender, EventArgs e)

        {
            if (btn.BackColor == Color.Red)
            {
                btn.BackColor = Color.Blue;
                lbl.BackColor = Color.GreenYellow;
                lbl.ForeColor = Color.DarkCyan;
            }
            else
            {
                btn.BackColor = Color.Red;
                lbl.BackColor = Color.DarkCyan;
                lbl.ForeColor = Color.GreenYellow; 
            }
        }
    }
}
