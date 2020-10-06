using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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


            Button btn = new Button();
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

                txt_box = new TextBox();
                txt_box.Multiline = true;
                txt_box.Text = "";
                txt_box.Location = new Point(300, 300);
                txt_box.Width = 200;
                txt_box.Height = 100;
            }
        }


        private void RadioButton_Changed(object sender, EventArgs e)
        {
            if (r1.Checked)
            {
                btn.Location = new Point(300, 200);
            }
            else if (r2.Checked)
            {
                btn.Location = new Point(400, 100);
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
            if(box_lbl.Checked)
            {
                this.Controls.Add(lbl);
            }
            else
            {
                Controls.Remove(lbl);
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
