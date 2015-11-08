using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace assignmetnt3q3
{
    
    public partial class EditForm : newContact
    {
        private ListViewItem lvItem;
        private mainView masterForm;
        public EditForm(mainView masterForm, ListViewItem lvitem) : base(masterForm)
        {
            InitializeComponent();
            this.lvItem = lvitem;
            this.masterForm = masterForm;
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            // Fill textboxes with selected entry (Assumption: There is a selected entry)

            // Set text for boxes based on ListView Elements
            firstNameBox.Text = lvItem.SubItems[0].Text;
            lastNameBox.Text = lvItem.SubItems[1].Text;
            textBox1.Text = lvItem.SubItems[2].Text;
            genderCombo.Text = lvItem.SubItems[3].Text;
            yearCombo.Text = lvItem.SubItems[4].Text;
            textBox2.Text = lvItem.SubItems[5].Text;
            textBox3.Text = lvItem.SubItems[6].Text;
        }

        protected override void createButton_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"a2entries.xml");

            XmlNodeList nodes = doc.GetElementsByTagName("entry");
            XmlNode toChange;


            for (int i = 0; i < masterForm.listView2.Items.Count; i++)
            {
                if(masterForm.listView2.Items[i].Selected)
                {
                    lvItem.SubItems[0].Text = firstNameBox.Text;
                    lvItem.SubItems[1].Text = lastNameBox.Text;
                    lvItem.SubItems[2].Text = textBox1.Text;
                    lvItem.SubItems[3].Text = genderCombo.Text;
                    lvItem.SubItems[4].Text = yearCombo.Text;
                    lvItem.SubItems[5].Text = textBox2.Text;
                    lvItem.SubItems[6].Text = textBox3.Text;

                    toChange = nodes[i];
                    
                    XmlNode insert = doc.CreateNode(XmlNodeType.Element, "entry", null);
                    XmlNode elem;

                    elem = doc.CreateElement("firstName");
                    elem.InnerText = firstNameBox.Text;
                    insert.AppendChild(elem);

                    elem = doc.CreateElement("lastName");
                    elem.InnerText = lastNameBox.Text;
                    insert.AppendChild(elem);

                    elem = doc.CreateElement("age");
                    elem.InnerText = textBox1.Text;
                    insert.AppendChild(elem);

                    elem = doc.CreateElement("gender");
                    elem.InnerText = genderCombo.Text;
                    insert.AppendChild(elem);

                    elem = doc.CreateElement("year");
                    elem.InnerText = yearCombo.Text;
                    insert.AppendChild(elem);

                    elem = doc.CreateElement("phone");
                    elem.InnerText = textBox2.Text;
                    insert.AppendChild(elem);

                    elem = doc.CreateElement("address");
                    elem.InnerText = textBox3.Text;
                    insert.AppendChild(elem);

                    toChange.ParentNode.ReplaceChild(insert, toChange);
                    doc.Save(@"./a2entries.xml");
                }
            }

            Close();

        }

        
    }
}
