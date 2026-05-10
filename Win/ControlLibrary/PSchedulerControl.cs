using DevExpress.XtraScheduler.Drawing;
using EBAP.Core.Info;
using EBAP.Core.Interface;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace EBAP.Win.ControlLibrary
{
    /// <summary>
    /// Scheduler Control 입니다.
    /// </summary>
    /// <remarks>
    /// 2015-04-12 최초생성 : 오인봉
    /// 변경내역
    /// 
    /// </remarks>
    [ToolboxItem(true)]
    public partial class PSchedulerControl : DevExpress.XtraScheduler.SchedulerControl, IPrint
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// SchedulerControl을 생성합니다.
        /// </summary>
        public PSchedulerControl()
        {
            InitializeComponent();
        }

        #endregion

        #region :: 전역변수 ::

        //private const string defaultLabelIdMappedName = "ID";
        //private const string defaultLabelColorMappedName = "COLOR";
        //private const string defaultLabelDisplayNameMappedName = "CAPTION";

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Interface 구현
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region IPrint 멤버

        /// <summary>
        /// 
        /// </summary>
        public void PrintPreview()
        {
            base.ShowPrintPreview();
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: LabelsDataSource :: Label을 표현하는 Datasource 입니다.

        private DataSet labelsDataSource;

        /// <summary>
        /// Label을 표현하는 Datasource 입니다.
        /// </summary>
        [AttributeProvider(typeof(IListSource))]
        [Category("Data")]
        public DataSet LabelsDataSource
        {
            get { return labelsDataSource; }
            set
            {
                labelsDataSource = value;
                PopulateLabelsStorage();
                Refresh();
            }
        }

        /// <summary>
        /// Label Datasource로 Labe을 생성합니다.
        /// </summary>
        public void PopulateLabelsStorage()
        {
            if (DataStorage == null || LabelsDataSource == null)
                return;

            DataStorage.Appointments.Labels.Clear();

            foreach (DataRow dr in LabelsDataSource.Tables[0].Rows)
            {
                object labelId = dr[LabelIdMappedName];
                string labelDisplayName = dr[LabelDisplayNameMappedName].ToString();
                Color labelColor;

                if (LabelColorMappedName == "")
                    labelColor = Color.Transparent;
                else
                    labelColor = Color.FromName(dr[LabelColorMappedName].ToString());

                DataStorage.Appointments.Labels.Add(labelDisplayName, labelDisplayName);
            }
        }

        #endregion

        #region :: MappedName :: ID, NAME, COLOR MAPPING 명을 설정합니다.

        /// <summary>
        /// ID MAPPING 명을 설정합니다.
        /// </summary>
        [Category("Data")]
        [Description("ID MAPPING 명을 설정합니다.")]
        public string LabelIdMappedName { get; set; }

        /// <summary>
        /// COLOR MAPPING 명을 설정합니다.
        /// </summary>
        [Category("Data")]
        [Description("COLOR MAPPING 명을 설정합니다.")]
        public string LabelColorMappedName { get; set; }

        /// <summary>
        /// Display MAPPING 명 설정합니다.
        /// </summary>
        [Category("Data")]
        [Description("Display MAPPING 명을 설정합니다.")]
        public string LabelDisplayNameMappedName { get; set; }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: FillAppointment(+1 Overloading) :: 데이터를 채웁니다.

        /// <summary>
        /// 데이터를 채웁니다.
        /// </summary>
        /// <param name="ds">DataSource</param>
        /// <remarks>
        /// 2011-04-12 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void FillAppointment(DataSet ds)
        {
            FillAppointment(ds, ds.Tables[0].TableName);
        }

        /// <summary>
        /// 데이터를 채웁니다.
        /// </summary>
        /// <param name="ds">DataSource</param>
        /// <param name="tableName">DataTable 이름</param>
        /// <remarks>
        /// 2011-04-12 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void FillAppointment(DataSet ds, string tableName)
        {
            DataStorage.Appointments.DataSource = ds;
            DataStorage.Appointments.DataMember = ds.Tables[tableName].TableName;
        }

        #endregion

        #region :: FillResource(+1 Overloading) :: Resource 데이터를 채웁니다.

        /// <summary>
        /// 데이터를 채웁니다.
        /// </summary>
        /// <param name="ds">DataSource</param>
        /// <remarks>
        /// 2011-04-12 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void FillResource(DataSet ds)
        {
            FillResource(ds, ds.Tables[0].TableName);
        }

        /// <summary>
        /// 데이터를 채웁니다.
        /// </summary>
        /// <param name="ds">DataSource</param>
        /// <param name="tableName">DataTable 이름</param>
        /// <remarks>
        /// 2011-04-12 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public void FillResource(DataSet ds, string tableName)
        {
            DataStorage.Resources.DataSource = ds;
            DataStorage.Resources.DataMember = ds.Tables[tableName].TableName;
        }

        #endregion

        #region :: FillLabel :: Label 데이터를 채웁니다.

        /// <summary>
        /// Label 데이터를 채웁니다.
        /// </summary>
        /// <param name="ds"></param>
        public void FillLabel(DataSet ds)
        {
            LabelsDataSource = ds;
        }

        #endregion

        #region :: InitAppointmentMapping :: 데이터와 데이터소스를 Mapping 합니다.

        /// <summary>
        /// 데이터와 데이터소스를 Mapping 합니다.
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="location"></param>
        /// <param name="label"></param>
        /// <param name="resourceId"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="description"></param>
        /// <param name="allday"></param>
        /// <param name="status"></param>
        /// <param name="type"></param>
        public void InitAppointmentMapping(string subject, string location, string label,
                                        string resourceId, string start, string end,
                                        string description, string allday, string status, string type)
        {
            DataStorage.Appointments.Mappings.Subject = subject;
            DataStorage.Appointments.Mappings.Location = location;
            DataStorage.Appointments.Mappings.Label = label;
            DataStorage.Appointments.Mappings.ResourceId = resourceId;
            DataStorage.Appointments.Mappings.Start = start;
            DataStorage.Appointments.Mappings.End = end;
            DataStorage.Appointments.Mappings.Description = description;
            DataStorage.Appointments.Mappings.AllDay = allday;
            DataStorage.Appointments.Mappings.Status = status;
            DataStorage.Appointments.Mappings.Type = type;
        }

        #endregion

        #region :: InitLabelMapping :: LABEL과 데이터소스를 Mapping 합니다.

        /// <summary>
        /// LABEL과 데이터소스를 Mapping 합니다.
        /// </summary>
        /// <param name="id">ID 열 이름</param>
        /// <param name="caption">캡션 열 이름</param>
        /// <param name="color">색상 열 이름</param>    
        public void InitLabelMapping(string id, string caption, string color)
        {
            LabelIdMappedName = id;
            LabelDisplayNameMappedName = caption;
            LabelColorMappedName = color;
        }

        #endregion

        #region :: InitResourceMapping :: 리소스와 데이터소스를 Mapping 합니다.

        /// <summary>
        /// 리소스와 데이터소스를 Mapping 합니다.
        /// </summary>
        /// <param name="id">ID 열 이름</param>
        /// <param name="caption">캡션 열 이름</param>
        /// <param name="color">색상 열 이름</param>    
        public void InitResourceMapping(string id, string caption, string color)
        {
            DataStorage.Resources.Mappings.Id = id;
            DataStorage.Resources.Mappings.Caption = caption;
            DataStorage.Resources.Mappings.Color = color;
        }

        #endregion

        #region :: GetDataTableByDataSource :: DataSource를 DataTable로 반환합니다.

        /// <summary>
        /// DataSource를 DataTable로 반환합니다.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public DataTable GetDataTableByDataSource()
        {
            DataTable dt = (DataStorage.Appointments.DataSource as DataSet).Tables[0];

            return dt ?? null;
        }

        #endregion

        #region :: GetAddedModifedData :: 캘린더에서 추가 및 수정된 데이터를 가져옵니다.

        /// <summary>
        /// 캘린더에서 추가 및 수정된 데이터를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 2016-05-17 최초생성 : 오인봉
        /// 변경내역
        /// 
        /// </remarks>
        public DataTable GetAddedModifedData()
        {
            DataSet ds = (DataStorage.Appointments.DataSource as DataSet);

            if (ds == null) return null;

            DataTable dt = ds.Tables[0].Clone();

            IFrameUI uiForm = FindForm() as IFrameUI;

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr.RowState == DataRowState.Added || dr.RowState == DataRowState.Modified || dr.RowState == DataRowState.Detached)
                {
                    if (uiForm != null && uiForm.AddCommomParam)
                    {
                        if (dr.Table.Columns.Contains("VENDORCODE") && dr["VENDORCODE"].ToString() == string.Empty)
                            dr["VENDORCODE"] = uiForm.CurrentUser.VENDORCODE;

                        if (dr.Table.Columns.Contains("PLANTCODE") && dr["PLANTCODE"].ToString() == string.Empty)
                            dr["PLANTCODE"] = uiForm.CurrentUser.PLANTCODE;
                    }
                    if (uiForm != null && dr.Table.Columns.Contains(AppConfig.USERCOLUMNNAME))
                        dr[AppConfig.USERCOLUMNNAME] = uiForm.CurrentUser.USERID;

                    if (dr.Table.Columns.Contains(AppConfig.DATECOLUMNNAME))
                        dr[AppConfig.DATECOLUMNNAME] = DateTime.Now;

                    dt.ImportRow(dr);
                }
            }

            return dt;
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Control Event Handler
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: PSchedulerControl_CustomDrawTimeCell :: 토요일/일요일 색을 변경합니다.

        /// <summary>
        /// 토요일/일요일 색을 변경합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PSchedulerControl_CustomDrawTimeCell(object sender, DevExpress.XtraScheduler.CustomDrawObjectEventArgs e)
        {
            TimeCell cell = e.ObjectInfo as TimeCell;

            if (cell == null) return;

            DayOfWeek currentDayOfWeek = cell.Interval.Start.DayOfWeek;

            if (currentDayOfWeek == DayOfWeek.Sunday)
                cell.Appearance.BackColor = Color.IndianRed;
            else if (currentDayOfWeek == DayOfWeek.Saturday)
                cell.Appearance.BackColor = Color.AliceBlue;
        }

        #endregion
    }
}