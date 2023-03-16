using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organizer
{
    public partial class OrganizerForm : Form
    {
        
                
        public Organizer organizer = new Organizer();
        public OrganizerForm()
        {
            InitializeComponent();
        }

        private void OrganizerForm_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add(EventType.MEETING.ToString());
            comboBox1.Items.Add(EventType.TASK.ToString());
            comboBox1.Select(0, 1);
        }

        private void OrganizerForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void OrganizerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddEventForm eventForm = new AddEventForm();
            eventForm.Show();
            eventForm.setOrganize(ref organizer);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            refreshDataGridView();
        }
        public void refreshDataGridView()
        {
            dataGridView1.Rows.Clear();
            organizer.List.ForEach(item =>
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Cells.Add((new DataGridViewTextBoxCell
                {
                    Value = String.Format("{0}-{1}-{2}",
                    item.Date.Year,
                    (item.Date.Month < 10 ? "0" + item.Date.Month : item.Date.Month),
                    (item.Date.Day < 10 ? "0" + item.Date.Day : item.Date.Day)
                )
                }));
                   
                row.Cells.Add((new DataGridViewTextBoxCell
                {
                    Value = String.Format ("{0}:{1}:{2}",
                    (item.Time.Hours < 10 ? "0" + item.Time.Hours : item.Time.Hours),
                    (item.Time.Minutes < 10 ? "0" + item.Time.Minutes : item.Time.Minutes),
                    (item.Time.Seconds < 10 ? "0" + item.Time.Seconds : item.Time.Seconds)
                    )
                                        
                }));
                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.Event });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.eventType.ToString(),
                    Style = new DataGridViewCellStyle { BackColor = item.eventType==EventType.TASK?Color.Red:Color.Green }
                });

                dataGridView1.Rows.Add(row);
            });
        }

        private void OrganizerForm_Activated(object sender, EventArgs e)
        {
            refreshDataGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = !groupBox3.Visible;
            button2.Text = groupBox3.Visible ? "Скрыть поиск" : "Найти";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            List<Data> tmp = organizer.findByText(textBox1.Text);
            dataGridView1.Rows.Clear();
            tmp.ForEach(item =>

            {
                DataGridViewRow row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = String.Format("{0}-{1}-{2}",
                 item.Date.Year,
                 (item.Date.Month < 10 ? "0" + item.Date.Month : item.Date.Month),
                 (item.Date.Day < 10 ? "0" + item.Date.Day : item.Date.Day)
                 )
                });

                row.Cells.Add((new DataGridViewTextBoxCell
                {
                    Value = String.Format("{0}-{1}-{2}",

                 (item.Time.Hours < 10 ? "0" + item.Time.Hours : item.Time.Hours),
                 (item.Time.Minutes < 10 ? "0" + item.Time.Minutes : item.Time.Minutes),
                 (item.Time.Seconds < 10 ? "0" + item.Time.Seconds : item.Time.Seconds)
                 )               
                
                }));

                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.Event });
                dataGridView1.Rows.Add(row);
            });
        }

        private void button4_Click(object sender, EventArgs e)
        {
            refreshDataGridView();
            organizer.sortByTime(0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            refreshDataGridView();
            organizer.sortByTime(1);
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            List<Data> tmp = organizer.findByCategory((EventType)Enum.Parse(typeof(EventType),
                comboBox1.Text,true));
                        
            dataGridView1.Rows.Clear();
            tmp.ForEach(item =>

            {
                DataGridViewRow row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell
                {
                    Value = String.Format("{0}-{1}-{2}",
                 item.Date.Year,
                 (item.Date.Month < 10 ? "0" + item.Date.Month : item.Date.Month),
                 (item.Date.Day < 10 ? "0" + item.Date.Day : item.Date.Day)
                 )
                });

                row.Cells.Add((new DataGridViewTextBoxCell
                {
                    Value = String.Format("{0}-{1}-{2}",

                 (item.Time.Hours < 10 ? "0" + item.Time.Hours : item.Time.Hours),
                 (item.Time.Minutes < 10 ? "0" + item.Time.Minutes : item.Time.Minutes),
                 (item.Time.Seconds < 10 ? "0" + item.Time.Seconds : item.Time.Seconds)
                 )

                }));

                row.Cells.Add(new DataGridViewTextBoxCell { Value = item.Event });
                dataGridView1.Rows.Add(row);
            });


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            refreshDataGridView();
        }

        
    }
}
