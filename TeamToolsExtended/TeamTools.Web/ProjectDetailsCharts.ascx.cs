using AjaxControlToolkit;
using System;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails;
using TeamTools.Logic.Mvp.Profile.MyProjectDetails.Contracts;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace TeamTools.Web
{
    [PresenterBinding(typeof(ProjectDetailsChartPresenter))]
    public partial class ProjectDetailsCharts : MvpUserControl<ProjectDetailsViewModel>, IProjectDetailsChartView
    {
        private const string RedirectUrl = "~/organizations.aspx";
        private int projectId;

        public event EventHandler<ProjectDetailsEventArgs> LoadProject;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["id"] == null)
            {
                Response.Redirect(RedirectUrl);
            }
            else
            {
                try
                {
                    int paramId = int.Parse(Request.Params["id"]);
                    this.projectId = paramId;

                    this.LoadProject?.Invoke(sender, new ProjectDetailsEventArgs(this.projectId));

                    this.LineChart.CategoriesAxis = this.Model.AllDays;
                    this.LineChart.Series.Add(new LineChartSeries() { Name = "Days", Data = this.Model.AllCosts });
                }
                catch (FormatException)
                {
                    Response.Redirect(RedirectUrl);
                }
            }
        }
    }
}