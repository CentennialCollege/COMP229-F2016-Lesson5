using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// using statements that are required to connect to EF DB
using COMP229_F2016_Lesson5.Models;
using System.Web.ModelBinding;

namespace COMP229_F2016_Lesson5
{
    public partial class Students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if loading the page for the first time
            // populate the student grid
            if (!IsPostBack)
            {
                // Get the student data
                this.GetStudents();
            }
        }

        /// <summary>
        /// This method gets the student data from the DB
        /// </summary>
        private void GetStudents()
        {
            // connect to EF DB
            using (ContosoContext db = new ContosoContext())
            {
                // query the Student Table using EF and LINQ
                var Students = (from allStudents in db.Students
                                select allStudents);

                // bind the result to the Students GridView
                StudentsGridView.DataSource = Students.ToList();
                StudentsGridView.DataBind();
            }
        }
    }
}