using DevExpress.XtraCharts;
using EBAP.Core.Interface;
using System.ComponentModel;
using System.Data;

namespace EBAP.Win.ControlLibrary
{
    /// <summary>
    /// Chart Control 입니다.
    /// DevExpress ChartControl을 Wrapping 하여 사용합니다.
    /// </summary>
    /// <remarks>
    /// 2023-02-01 최초생성 : 오인봉
    /// 변경내역
    ///
    /// </remarks>
    [ToolboxItem(true)]
    public partial class PChart : DevExpress.XtraCharts.ChartControl, IFillData, IPrint
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// 
        /// </summary>
        public PChart()
        {
            InitializeComponent();
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Interface 구현
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region IFillData 멤버

        /// <summary>
        /// GridControl의 데이터를 채웁니다.
        /// </summary>
        public void FillData()
        {
            DataSource = null;
        }

        /// <summary>
        /// GridControl의 데이터를 채웁니다.
        /// </summary>
        /// <param name="ds"></param>
        public void FillData(DataSet ds)
        {
            FillData(ds, ds.Tables[0].TableName);
        }

        /// <summary>
        /// GridControl의 데이터를 채웁니다.
        /// </summary>
        /// <param name="dt"></param>
        public void FillData(DataTable dt)
        {
            FillData(dt.DataSet, dt.TableName);
        }

        /// <summary>
        /// GridControl의 데이터를 채웁니다.
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        public void FillData(DataSet ds, string tableName)
        {
            DataSource = ds.Tables[tableName];
        }

        #endregion

        #region IPrint 멤버

        /// <summary>
        /// 
        /// </summary>
        public void PrintPreview()
        {
            base.ShowRibbonPrintPreview();
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: LineMarkerVisible :: Line Marker의 숨김/보임을 설정합니다.

        /// <summary>
        /// Line Marker의 숨김/보임을 설정합니다.
        /// </summary>
        [Category("EBAP"), DefaultValue(false), Browsable(true)]
        [Description("Line Marker의 숨김/보임을 설정합니다.")]
        public bool LineMarkerVisible
        {
            get;
            set;
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: InitSeries(+1 Overloading) :: Series를 초기화합니다.

        /// <summary>
        /// Series를 초기화합니다.
        /// </summary>
        /// <param name="name">Series 이름</param>
        /// <param name="argumentDataMember">Argument DataMember</param>
        /// <param name="valueDataMembers">Value DataMembers</param>
        public void InitSeries(string name, string argumentDataMember, string[] valueDataMembers)
        {
            InitSeries(name, argumentDataMember, valueDataMembers, ViewType.Line, false);
        }

        /// <summary>
        /// Series를 초기화합니다.
        /// </summary>
        /// <param name="name">Series 이름</param>
        /// <param name="argumentDataMember">Argument DataMember</param>
        /// <param name="valueDataMembers">Value DataMembers</param>
        /// <param name="type">Series Type</param>
        /// <param name="labelVisible">Label 숨김/보임</param>
        public void InitSeries(string name, string argumentDataMember, string[] valueDataMembers, ViewType type, bool labelVisible)
        {
            Series series = new Series(name, type)
            {
                ArgumentDataMember = argumentDataMember
            };
            series.ValueDataMembers.AddRange(valueDataMembers);
            series.ShowInLegend = true;
            //series.ValueScaleType = ScaleType.Numerical;
            //series.ArgumentScaleType = ScaleType.Numerical;

            switch (type)
            {
                case ViewType.Line:
                case ViewType.Line3D:
                    break;
            }

            Series.Add(series);
        }

        /// <summary>
        /// Series를 초기화합니다.
        /// </summary>
        /// <param name="name">Series 이름</param>
        /// <param name="argumentDataMember">Argument DataMember</param>
        /// <param name="valueDataMember">Value DataMembers</param>
        public void InitSeries(string name, string argumentDataMember, string valueDataMember)
        {
            InitSeries(name, argumentDataMember, valueDataMember, ViewType.Line, false);
        }

        /// <summary>
        /// Series를 초기화합니다.
        /// </summary>
        /// <param name="name">Series 이름</param>
        /// <param name="argumentDataMember">Argument DataMember</param>
        /// <param name="valueDataMember">Value DataMembers</param>
        /// <param name="type">Series Type</param>
        /// <param name="labelVisible">Label 숨김/보임</param>
        public void InitSeries(string name, string argumentDataMember, string valueDataMember, ViewType type, bool labelVisible)
        {
            Series series;

            bool existSeries = Series[name] == null ? false : true;

            series = existSeries ? Series[name] : new Series(name, type);

            series.ArgumentDataMember = argumentDataMember;
            series.ValueDataMembersSerializable = valueDataMember;
            series.ShowInLegend = true;

            switch (type)
            {
                case ViewType.Line:
                case ViewType.Line3D:
                    break;
            }

            if (!existSeries) Series.Add(series);
        }

        #endregion

        /// <summary>
        /// 자동 템플릿 기능을 사용하여 차트를 초기화 합니다.
        /// </summary>
        /// <param name="seriesMember"></param>
        /// <param name="argumentMember"></param>
        /// <param name="valueMemeber"></param>
        public void InitSeriesTemplate(string seriesMember, string argumentMember, string valueMemeber)
        {
            SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            SeriesDataMember = seriesMember;
            SeriesTemplate.ArgumentDataMember = argumentMember;
            SeriesTemplate.ValueDataMembersSerializable = valueMemeber;
        }

        /// <summary>
        /// BAR Series를 생성합니다.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="argumentMember"></param>
        /// <param name="valueMemeber"></param>
        /// <param name="chartData"></param>
        public void InitBarSeries(string name, string argumentMember, string valueMemeber, DataTable chartData)
        {
            DevExpress.XtraCharts.Series barSeries = new DevExpress.XtraCharts.Series();
            barSeries.Name = name;
            barSeries.DataSource = chartData;
            barSeries.ArgumentDataMember = argumentMember;
            barSeries.ValueDataMembersSerializable = valueMemeber;

            Series.Add(barSeries);
        }
    }
}
