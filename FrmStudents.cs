using Evaluation_Manager.Models;
using Evaluation_Manager.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evaluation_Manager
{
    public partial class FrmStudents : Form
    {

        private Student student;
		private object cboActivities;

		public FrmStudents(Student selectedStudent)
        {
            InitializeComponent();
            student = selectedStudent;
        }

        private void FrmStudents_Load(object sender, EventArgs e)
        {
			Text = student.FirstName + " " + student.LastName;
            List<Activity> activites = ActivityRepository.GetActivities();
            cboActivities.DataSource = activites;
        }

        private void ShowStudents()
        {
            var students = StudentRepository.GetStudents();
            dgvStudents.DataSource = students;

            dgvStudents.Columns["Id"].DisplayIndex = 0;
            dgvStudents.Columns["FirstName"].DisplayIndex = 1;
            dgvStudents.Columns["LastName"].DisplayIndex = 2;
            dgvStudents.Columns["Grade"].DisplayIndex = 3;
        }

		private void button1_Click(object sender, EventArgs e)
		{
			Student selectedStudents = dgv.CurrentRow.DataBoundItem as Student;
            if (selectedStudents != null)
			{
				FrmEvaluation frmEvaluation = new FrmEvaluation(selectedStudents);
                frmEvaluation.ShowDialog();
			}
		}
	}
}
